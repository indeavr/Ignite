using Ignite.Data.Enums;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Data
{
    public class Listener : IJob
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

        //public Listener(ApplicationDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}

        public void Execute(IJobExecutionContext context)
        {
            var assignments = this.dbContext.Assignments.ToList();
            for (int i = 0; i < assignments.Count; i++)
            {
                if (assignments[i].DueDate < DateTime.Now && assignments[i].State != AssignmentState.Overdue)
                {
                    assignments[i].State = AssignmentState.Overdue;
                }
            }
            this.dbContext.SaveChanges();
        }
    }
}
