using QuanLyDuAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Controllers
{
	public class LoginController : Controller
	{
		// GET: Login
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(users user)
		{
			if (ModelState.IsValid)
			{
				using (DBContext dbContext = new DBContext())
				{
					var item = dbContext.users.FirstOrDefault(m => m.user_name.Equals(user.user_name));
					if (item == null)
					{
						users u = new users();
						u.user_name = user.user_name;
						u.email = user.email;
						u.password = user.password;
						dbContext.users.Add(u);
						dbContext.SaveChanges();
						return RedirectToAction("Index");
					}
					else
					{
						ViewBag.message = "Tên tài khoản đã tồn tại.";
					}
				}
			}
			else
			{
				ViewBag.message = "Vui lòng nhập đầy đủ thông tin.";
			}
			return View("Index");
		}


		[HttpPost]
		public ActionResult SignIn(users user)
		{
			if (ModelState.IsValid)
			{
				using (DBContext ctx = new DBContext())
				{
					var item = ctx.users.FirstOrDefault(m => m.user_name.Equals(user.user_name) && m.password.Equals(user.password));
					if (item != null)
					{
						Session["user"] = item;
						return RedirectToAction("Index", "Home");
					}
					ViewBag.message = "Tên đăng nhập hoặc mật khẩu không đúng.";
				}
			}
			else
			{
				ViewBag.message = "Vui lòng nhập đầy đủ thông tin.";
			}
			return View("Index");
		}
	}
}