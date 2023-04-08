using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyDuAn.Models
{
	public partial class DBContext : DbContext
	{
		public DBContext()
			: base("name=DBContext")
		{
		}

		public virtual DbSet<assignment> assignment { get; set; }
		public virtual DbSet<project> project { get; set; }
		public virtual DbSet<project_manager> project_manager { get; set; }
		public virtual DbSet<task> task { get; set; }
		public virtual DbSet<users> users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<project_manager>()
				.HasMany(e => e.project)
				.WithOptional(e => e.project_manager)
				.HasForeignKey(e => e.project_manager_id);
		}
	}
}
