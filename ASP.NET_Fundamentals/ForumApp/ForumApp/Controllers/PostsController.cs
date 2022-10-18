﻿using ForumApp.Data;
using ForumApp.Data.Entities;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers;

public class PostsController : Controller
{
    private readonly ForumAppDbContext data;

    public PostsController(ForumAppDbContext data)
    {
        this.data = data;
    }

    public IActionResult All()
    {
        var posts = data.Posts
            .Select(p => new PostViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content
            })
            .ToList();

        return View(posts);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(PostFormModel model)
    {
        var post = new Post()
        {
            Title = model.Title,
            Content = model.Content
        };

        this.data.Posts.Add(post);
        this.data.SaveChanges();

        return RedirectToAction(nameof(All));
    }
}