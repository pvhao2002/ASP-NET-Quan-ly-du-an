using QuanLyDuAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var user = Session["user"];
			if(user == null)
			{
				return RedirectToAction("Index", "Login");
			}
			DBContext db = new DBContext();
			return View(db);
		}

	}
}