using QuanLyDuAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Controllers
{
	public class UserController : Controller
	{
		// GET: User
		public ActionResult Index()
		{
			using (DBContext db = new DBContext())
			{
				return View(db.users.ToList());
			}
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(users u)
		{
			using (DBContext dbContext = new DBContext())
			{
				if (ModelState.IsValid)
				{
					var item = dbContext.users.FirstOrDefault(m => m.user_name.Equals(u.user_name));
					if (item != null)
					{
						ViewBag.message = "error";
					}
					else
					{
						dbContext.users.Add(u);
						dbContext.SaveChanges();
						ViewBag.message = "success";
					}
				}
			}
			return View("Add");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			using (DBContext db = new DBContext())
			{
				var item = db.users.FirstOrDefault(m => m.user_id.Equals(id));
				return View(item);
			}
		}

		[HttpPost]
		public ActionResult Edit(users u)
		{
			using (DBContext db = new DBContext())
			{
				if (ModelState.IsValid)
				{
					var item = db.users.FirstOrDefault(m => m.user_id == u.user_id);
					if (item != null)
					{
						item.email = u.email;
						item.password = u.password;
						db.SaveChanges();
						return RedirectToAction("Index");
					}
				}
			}
			return View("Edit", new { u.user_id });
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			using (DBContext db = new DBContext())
			{
				try
				{
					var item = db.users.FirstOrDefault(u => u.user_id == id);
					if (item != null)
					{
						db.users.Remove(item);
						db.SaveChanges();
					}
					return RedirectToAction("Index");
				}
				catch (Exception)
				{
					Response.Write("<script>alert('Người dùng này đang trong dự án khác.')</script>");
					return View("Index", db.users.ToList());
				}
			}
			
		}
	}
}