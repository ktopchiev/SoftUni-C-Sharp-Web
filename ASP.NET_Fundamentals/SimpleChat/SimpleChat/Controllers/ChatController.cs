using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    //Warning: the code bellow holds the shared app data in a static field in the controller class.
    //This is just for the example, and it is generally a bad practice!
    //Use a database or other persistent storage to hold data,
    //which should survive between the app requests and should be shared between all app users.

    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> Messages = 
            new List<KeyValuePair<string, string>>();

        /// <summary>
        /// Show chat view with or without messages.
        /// </summary>
        /// <returns></returns>
        public IActionResult Show()
        {
            if (Messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                Messages = Messages
                    .Select(m => new MessageViewModel()
                    {
                        Sender = m.Key,
                        MessageText = m.Value
                    })
                    .ToList()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;

            Messages.Add(new KeyValuePair<string, string>
                (newMessage.Sender, newMessage.MessageText));

            return RedirectToAction("Show");
        }
    }
}
