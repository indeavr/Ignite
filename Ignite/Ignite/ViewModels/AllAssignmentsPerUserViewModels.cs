using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.ViewModels
{
    public class AllAssignmentsPerUserViewModels
    {
        public AllAssignmentsPerUserViewModels()
        {
            this.Pending = new Queue<Assignment>();
            this.Started = new Queue<Assignment>();
            this.Completed = new Queue<Assignment>();
        }

        public Queue<Assignment> Pending { get; set; }
        public Queue<Assignment> Started { get; set; }
        public Queue<Assignment> Completed { get; set; }

    }
}