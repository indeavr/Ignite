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
            this.Pending = new List<Assignment>();
            this.Started = new List<Assignment>();
            this.Completed = new List<Assignment>();
        }

        public List<Assignment> Pending { get; set; }
        public List<Assignment> Started { get; set; }
        public List<Assignment> Completed { get; set; }

    }
}