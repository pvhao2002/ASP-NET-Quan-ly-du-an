using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Models
{
	public class AssignmentViewModel
	{
		public List<assignment> listAssignment { get; set; }
		public List<task> listTask { get; set; }
		public List<users> listUser { get; set; }
		public assignment assign { get; set; }

		public AssignmentViewModel()
		{
			using(DBContext db = new DBContext())
			{
				listAssignment = db.assignment.ToList();
				listTask = db.task.ToList();
				listUser = db.users.ToList();
				assign = new assignment();
			}
		}

		public string getTaskName(int? task_id)
		{
			if (task_id == null) return "";
			return listTask.FirstOrDefault(m=>m.task_id==task_id).task_name;
		}

		public string getUsername(int? user_id)
		{
			if (user_id == null) return "";
			return listUser.FirstOrDefault(m => m.user_id == user_id).user_name;
		}
	}
}