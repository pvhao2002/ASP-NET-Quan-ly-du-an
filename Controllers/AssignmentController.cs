using QuanLyDuAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Controllers
{
	public class AssignmentController : Controller
	{
		// GET: Assignment
		public ActionResult Index()
		{
			AssignmentViewModel assignment = new AssignmentViewModel();
			return View(assignment);
		}

		[HttpGet]
		public ActionResult Add()
		{
			AssignmentViewModel assignment = new AssignmentViewModel();
			return View(assignment);
		}

		[HttpPost]
		public ActionResult Add(FormCollection form)
		{
			try
			{
				using (DBContext dbContext = new DBContext())
				{
					var task = form["task_id"];
					var user = form["user_id"];
					var item = new assignment();
					item.task_id = int.Parse(task.ToString());
					item.user_id = int.Parse(user.ToString());
					dbContext.assignment.Add(item);
					dbContext.SaveChanges();
				}
				ViewBag.message = "success";
			}
			catch (Exception)
			{
				ViewBag.message = "error";
			}
			return View("Add", new AssignmentViewModel());

		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			try
			{
				AssignmentViewModel assignment = new AssignmentViewModel();
				using (DBContext dbContext = new DBContext())
				{
					var assign = dbContext.assignment.Find(id);
					assignment.assign = assign;
				}
				return View(assignment);
			}
			catch (Exception)
			{

				return RedirectToAction("Index");
			}

		}

		[HttpPost]
		public ActionResult Edit(FormCollection form)
		{
			try
			{
				using (DBContext dbContext = new DBContext())
				{
					var id = form["id"];
					var task_id = form["task_id"];
					var user_id = form["user_id"];
					if (id != null)
					{
						var item = dbContext.assignment.Find(id);
						item.task_id = int.Parse(task_id.ToString());
						item.user_id = int.Parse(user_id.ToString());
						dbContext.SaveChanges();
					}
				}
				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				ViewBag.message = "error";
				return View("Edit", new AssignmentViewModel());
			}
		}


		[HttpPost]
		public ActionResult Delete(int id)
		{
			using (DBContext context = new DBContext())
			{
				var item = context.assignment.FirstOrDefault(m => m.assignment_id == id);
				if (item != null)
				{
					context.assignment.Remove(item);
					context.SaveChanges();
				}
			}
			return RedirectToAction("Index");
		}
	}
}