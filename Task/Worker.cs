using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Worker
    {
        private string name;
        private object obj;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public Worker(string name)
        {
            this.name = name;
        }
        public void CreateTask(string taskDescription, DateTime deadline)
        {
            if ((obj as Project != null) && ((obj as Project).Status == ProjectStatus.Проект))
            {
                Task task = new Task(taskDescription, deadline, this, TaskStatus.Назначена, obj as Project);
                (obj as Project).AddTask(task);
            }
        }
        public void AddTask(object obj2)
        {
            if ((obj2 as Project != null) && (obj == null) && ((obj2 as Project).TeamLead == null) && ((obj2 as Project).Status == ProjectStatus.Проект))
            {
                obj = obj2 as Project;
            }
        }
        public void DeleteTask(Task task)
        {
            if ((obj as Project != null) && ((obj as Project).Status == ProjectStatus.Проект))
            {
                (obj as Project).RemoveTask(task);
            }
        }
        public void TakeTask()
        {
            if ((obj as Task != null) && ((obj as Task).ActiveProject != null) && ((obj as Task).ActiveProject.Status == ProjectStatus.Проект))
            {
                (obj as Task).StartTask();
                (obj as Task).ActiveProject.ProjectExecution();
            }
        }
        public void DelegateTask(Worker executor)
        {
            if ((obj as Task != null) && ((obj as Task).ActiveProject != null) && ((obj as Task).ActiveProject.Status == ProjectStatus.Проект))
            {
                (obj as Task).AddExecutor(executor);
                obj = null;
                executor.obj = obj as Task;
            }
        }
        public void AbandonTask()
        {
            if ((obj as Task != null) && ((obj as Task).ActiveProject != null) && ((obj as Task).ActiveProject.Status == ProjectStatus.Проект))
            {
                (obj as Task).RemoveExecutor();
                obj = null;
            }
        }
        public void AssignTask(Task task, Worker executor)
        {
            if ((obj as Project != null) && (task.Executor == null) && (executor.obj == null) && ((obj as Project).Status == ProjectStatus.Проект))
            {
                executor.AddTask(task);
                task.AddExecutor(executor);
            }
        }
        public Report CreateReport(string reportText, DateTime datePerfomance)
        {
            if ((obj as Task != null) && ((obj as Task).Status == TaskStatus.В_работе))
            {
                Report report = new Report(reportText, datePerfomance, this, obj as Task);
                return report;
            }
            return null;
        }
        public bool CheckReport(Report report)
        {
            if (report.ReportedTask.Initiator == this.obj)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
