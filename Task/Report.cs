using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Report
    {
        private string reportText;
        private DateTime datePerfomance;
        private Worker executor;
        private Task reportedTask;
        public string ReportText
        {
            get
            {
                return reportText;
            }
        }
        public DateTime DatePerfomance
        {
            get
            {
                return datePerfomance;
            }
        }
        public Worker Executer
        {
            get
            {
                return executor;
            }
        }
        public Task ReportedTask
        {
            get
            {
                return reportedTask;
            }
        }
        public Report(string reportText, DateTime datePerfomance, Worker executor, Task reportedTask)
        {
            this.reportText = reportText;
            this.datePerfomance = datePerfomance;
            this.executor = executor;
            this.reportedTask = reportedTask;
        }
    }
}
