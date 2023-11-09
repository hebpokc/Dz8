using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    enum ProjectStatus
    {
        Проект,
        Исполнение,
        Закрыт
    }
    class Project
    {
        private string projectDescription;
        private DateTime deadline;
        private Worker customer;
        private Worker teamLead;
        private List<Task> tasks = new List<Task>();
        private ProjectStatus status;
        public string ProjectDesription
        {
            get
            {
                return projectDescription;
            }
        }
        public DateTime Deadline
        {
            get
            {
                return deadline;
            }
        }
        public Worker Customer
        {
            get
            {
                return customer;
            }
        }
        public Worker TeamLead
        {
            get
            {
                return teamLead;
            }
        }
        public List<Task> Tasks
        {
            get
            {
                return tasks;
            }
        }
        public ProjectStatus Status
        {
            get
            {
                return status;
            }
        }
        public Project(string projectDescription, DateTime deadline, Worker customer)
        {
            this.projectDescription = projectDescription;
            this.deadline = deadline;
            this.customer = customer;
            teamLead = null;
            status = ProjectStatus.Проект;
        }
        public void AddTask(Task task)
        {
            if (Status == ProjectStatus.Проект)
            {
                tasks.Add(task);
            }
        }
        public void RemoveTask(Task task)
        {
            if (Status == ProjectStatus.Проект)
            {
                tasks.Remove(task);
            }
        }
        public void AssignTeamLead(Worker teamLead)
        {
            if (this.teamLead == null && Status == ProjectStatus.Проект)
            {
                this.teamLead = teamLead;
            }
        }
        public void ProjectExecution()
        {
            bool result = true;
            foreach (var task in tasks)
            {
                if (task.Status != TaskStatus.В_работе)
                {
                    result = false;
                    break;
                }
            }
            if (result)
            {
                status = ProjectStatus.Исполнение;
            }
        }
        public void ProjectClosing()
        {
            bool result = true;
            foreach (var task in tasks)
            {
                if (task.Status != TaskStatus.Выполнена)
                {
                    result = false;
                    break;
                }
            }
            if (result)
            {
                status = ProjectStatus.Закрыт;
            }
        }
    }
}
