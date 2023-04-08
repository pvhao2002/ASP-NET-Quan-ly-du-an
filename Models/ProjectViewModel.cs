using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Models
{
	public class ProjectViewModel
	{
		public List<project> listProject { get; set; }
		public project project { get; set; }
		public List<project_manager> listProjectManager { get; set; }

		public ProjectViewModel()
		{
			using(DBContext dbContext = new DBContext())
			{
				listProject = dbContext.project.ToList();
				listProjectManager = dbContext.project_manager.ToList();
				project = new project();
			}
		}

		public string getManagerName(int? manager_id)
		{
			return listProjectManager.FirstOrDefault(m => m.manager_id == manager_id).manager_name;
		}
	}
}