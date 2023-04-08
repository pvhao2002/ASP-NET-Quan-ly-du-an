using QuanLyDuAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Controllers
{
	public class ProjectManagerController : Controller
	{
		// GET: ProjectManager
		public ActionResult Index()
		{
			using (DBContext db = new DBContext())
			{
				return View(db.project_manager.ToList());

			}
		}


		[HttpGet]
		public ActionResult AddProjectManager()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(project_manager _Manager)
		{
			if (ModelState.IsValid)
			{
				using (DBContext dbContext = new DBContext())
				{
					var item = new project_manager();
					item.manager_name = _Manager.manager_name;
					dbContext.project_manager.Add(item);
					dbContext.SaveChanges();
					ViewBag.message = "success";
				}
			}
			else
			{
				ViewBag.message = "error";
			}
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			using (DBContext dB = new DBContext())
			{
				var item = dB.project_manager.FirstOrDefault(m => m.manager_id == id);
				return View(item);
			}
		}

		[HttpPost]
		public ActionResult Edit(project_manager manager)
		{
			using (DBContext dbContext = new DBContext())
			{
				var item = dbContext.project_manager.FirstOrDefault(m => m.manager_id == manager.manager_id);
				if (item != null)
				{
					item.manager_name = manager.manager_name;
					dbContext.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			return View("Edit", new { manager.manager_id });
		}

		[HttpGet]
		public ActionResult delete(int id)
		{
			using(DBContext dB = new DBContext())
			{
				var item = dB.project_manager.FirstOrDefault(m=>m.manager_id==id);
				if(item != null)
				{
					dB.project_manager.Remove(item);
					dB.SaveChanges();
				}
			}
			return RedirectToAction("Index");

		}
	}
}