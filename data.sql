CREATE DATABASE QuanLyDuAn;
GO
USE QuanLyDuAn;
GO
CREATE TABLE project_manager (
  manager_id INT IDENTITY PRIMARY KEY,
  manager_name NVARCHAR(255)
);
GO
CREATE TABLE project (
  project_id INT IDENTITY PRIMARY KEY,
  project_name NVARCHAR(255),
  start_date DATETIME,
  end_date DATETIME,
  project_manager_id INT,
  FOREIGN KEY (project_manager_id) REFERENCES project_manager(manager_id)
);
GO

CREATE TABLE task (
  task_id INT IDENTITY PRIMARY KEY,
  task_name NVARCHAR(255),
  start_date DATETIME,
  end_date DATETIME,
  status NVARCHAR(50),
  project_id INT,
  FOREIGN KEY (project_id) REFERENCES project(project_id)
);
GO

CREATE TABLE users (
  user_id INT IDENTITY PRIMARY KEY,
  user_name NVARCHAR(255),
  email NVARCHAR(255),
  password NVARCHAR(255)
);
GO
CREATE TABLE  assignment (
  assignment_id INT IDENTITY PRIMARY KEY,
  task_id INT,
  user_id INT,
  FOREIGN KEY (task_id) REFERENCES task(task_id),
  FOREIGN KEY (user_id) REFERENCES users(user_id)
);
