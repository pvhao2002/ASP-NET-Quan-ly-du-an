using QuanLyDuAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Controllers
{
	public class ProjectController : Controller
	{
		// GET: Project
		public ActionResult Index()
		{
			return View(new ProjectViewModel());

		}

		[HttpGet]
		public ActionResult AddProject()
		{
			using (DBContext db = new DBContext())
			{
				ProjectViewModel projectViewModel = new ProjectViewModel();
				return View(projectViewModel);

			}
		}

		[HttpPost]
		public ActionResult Add(ProjectViewModel projectViewModel, FormCollection form)
		{
			using (DBContext db = new DBContext())
			{
				if (ModelState.IsValid)
				{
					var id = form["project_manager_id"];
					if (id != null)
					{
						projectViewModel.project.project_manager_id = int.Parse(id.ToString());
					}
					db.project.Add(projectViewModel.project);
					db.SaveChanges();
					ViewBag.message = "success";
				}
				else
				{
					ViewBag.message = "error";
				}
			}
			return View("AddProject", new ProjectViewModel());
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			using (DBContext db = new DBContext())
			{
				var projectViewModel = new ProjectViewModel();
				var project = db.project.FirstOrDefault(m => m.project_id == id);
				projectViewModel.project = project;
				return View(projectViewModel);
			}
		}

		[HttpPost]
		public ActionResult Edit(ProjectViewModel projectViewModel, FormCollection form)
		{
			//string tmp = "<script>alert('123: " + projectViewModel.project.project_name + "')</script>";
			//Response.Write(tmp);
			using (DBContext context = new DBContext())
			{
				if (ModelState.IsValid)
				{
					var item = context.project.FirstOrDefault(m => m.project_id == projectViewModel.project.project_id);
					var id = form["project_manager_id"];
					if (id != null && item != null)
					{
						item.project_name = projectViewModel.project.project_name;
						item.start_date = projectViewModel.project.start_date;
						item.end_date = projectViewModel.project.end_date;
						item.project_manager_id = int.Parse(id.ToString());
						context.SaveChanges();
					}
				}
			}
			return View("Index",new ProjectViewModel());
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			using(DBContext context = new DBContext())
			{
				var item = context.project.FirstOrDefault(m => m.project_id == id);
				if (item != null)
				{
					context.project.Remove(item);
					context.SaveChanges();
				}
			}
			return RedirectToAction("Index");
		}
	}
}