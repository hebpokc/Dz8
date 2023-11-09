using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    enum TaskStatus
    {
        Назначена,
        В_работе,
        На_проверке,
        Выполнена
    }
    class Task
    {
        private string taskDescription;
        private DateTime deadline;
        private Worker initiator;
        private Worker executor;
        private TaskStatus status;
        private List<Report> reports = new List<Report>();
        private Project activeProject;
        public string TaskDescription
        {
            get
            {
                return taskDescription;
            }
        }
        public DateTime Deadline
        {
            get
            {
                return deadline;
            }
        }
        public Worker Initiator
        {
            get
            {
                return initiator;
            }
        }
        public Worker Executor
        {
            get
            {
                return executor;
            }
        }
        public TaskStatus Status
        {
            get
            {
                return status;
            }
        }
        public List<Report> Reports
        {
            get
            {
                return reports;
            }
        }
        public Project ActiveProject
        {
            get
            {
                return activeProject;
            }
        }
        public Task(string taskDescription, DateTime deadline, Worker initiator, TaskStatus status, Project activeProject)
        {
            this.taskDescription = taskDescription;
            this.deadline = deadline;
            this.initiator = initiator;
            executor = null;
            this.status = status;
            this.activeProject = activeProject;
        }
        public void StartTask()
        {
            if (activeProject.Status == ProjectStatus.Проект)
            {
                status = TaskStatus.В_работе;
            }
        }
        public void CheckTask(Worker initiator)
        {
            if (this.initiator == initiator)
            {
                status = TaskStatus.На_проверке;
                CompleteTask();
            }
        }
        public void CompleteTask()
        {
            if (status == TaskStatus.На_проверке)
            {
                status = TaskStatus.Выполнена;
            }
        }
        public void AddReport(Report report)
        {
            reports.Add(report);
        }
        public void AddExecutor(Worker executor)
        {
            if (activeProject.Status == ProjectStatus.Проект)
            {
                this.executor = executor;
                status = TaskStatus.Назначена;
            }
        }
        public void RemoveExecutor()
        {
            if (activeProject.Status == ProjectStatus.Проект)
            {
                executor = null;
            }
        }
    }
}
