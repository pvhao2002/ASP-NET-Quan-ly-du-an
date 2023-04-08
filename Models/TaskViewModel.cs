using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Models
{
	public class TaskViewModel
	{
		public List<task> listTask { get; set; }
		public List<project> listProject { get; set; }
		public task task { get; set; }
		public TaskViewModel()
		{
			using(DBContext db = new DBContext())
			{
				listTask = db.task.ToList();
				listProject = db.project.ToList();
				task = new task();
			}
		}

		public string getProjectName(int? project_id)
		{
			return listProject.FirstOrDefault(m => m.project_id == project_id).project_name;
		}
	}
}