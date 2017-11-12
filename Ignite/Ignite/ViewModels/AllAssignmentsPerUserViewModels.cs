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
            this.Pending = new List<AssignmentViewModel>();
            this.Started = new List<AssignmentViewModel>();
            this.Completed = new List<AssignmentViewModel>();
        }

        public List<AssignmentViewModel> Pending { get; set; }
        public List<AssignmentViewModel> Started { get; set; }
        public List<AssignmentViewModel> Completed { get; set; }

    }
}