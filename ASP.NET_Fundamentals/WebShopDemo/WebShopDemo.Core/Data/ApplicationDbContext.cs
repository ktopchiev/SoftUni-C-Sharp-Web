using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopDemo.Core.Data
{
	/// <summary>
	/// Application Db Context class
	/// </summary>
	public class ApplicationDbContext : IdentityDbContext
	{
		/// <summary>
		/// Initialize Application Db Context
		/// </summary>
		/// <param name="options"></param>
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{

		}
	}
}
