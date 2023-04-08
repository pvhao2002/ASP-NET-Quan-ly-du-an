using QuanLyDuAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Controllers
{
	public class TaskController : Controller
	{
		// GET: Task
		public ActionResult Index()
		{
			TaskViewModel t = new TaskViewModel();
			return View(t);
		}


		public ActionResult Add()
		{
			TaskViewModel t = new TaskViewModel();
			return View(t);
		}

		[HttpPost]
		public ActionResult Add(TaskViewModel t, FormCollection form)
		{
			using (DBContext db = new DBContext())
			{
				if (ModelState.IsValid)
				{
					var id = form["project_id"];
					if (id != null)
					{
						t.task.project_id = int.Parse(id.ToString());
					}
					db.task.Add(t.task);
					db.SaveChanges();
					ViewBag.message = "success";
				}
				else
				{
					ViewBag.message = "error";
				}
			}
			return View("Add", new TaskViewModel());
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			using (DBContext db = new DBContext())
			{
				var taskViewModel = new TaskViewModel();
				var task = db.task.FirstOrDefault(m => m.task_id == id);
				taskViewModel.task = task;
				return View(taskViewModel);
			}
		}

		[HttpPost]
		public ActionResult Edit(TaskViewModel t, FormCollection form)
		{
			//string tmp = "<script>alert('123: " + t.task.task_id + "')</script>";
			//Response.Write(tmp);
			using (DBContext context = new DBContext())
			{
				if (ModelState.IsValid)
				{
					var item = context.task.FirstOrDefault(m => m.task_id == t.task.task_id);
					var id = form["project_id"];
					if (id != null && item != null)
					{
						item.task_name = t.task.task_name;
						item.start_date = t.task.start_date;
						item.end_date = t.task.end_date;
						item.status = t.task.status;
						item.project_id = int.Parse(id.ToString());
						context.SaveChanges();
					}
				}
			}
			return View("Index", new TaskViewModel());
		}


		[HttpGet]
		public ActionResult Delete(int id)
		{
			using (DBContext context = new DBContext())
			{
				var item = context.task.FirstOrDefault(m => m.task_id == id);
				if (item != null)
				{
					context.task.Remove(item);
					context.SaveChanges();
				}
			}
			return RedirectToAction("Index");
		}
	}
}