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
            this.Pending = new List<DisplayAssignmentsViewModel>();
            this.Started = new List<DisplayAssignmentsViewModel>();
            this.Completed = new List<DisplayAssignmentsViewModel>();
            this.Overdue = new List<DisplayAssignmentsViewModel>();
        }

        public List<DisplayAssignmentsViewModel> Pending { get; set; }
        public List<DisplayAssignmentsViewModel> Started { get; set; }
        public List<DisplayAssignmentsViewModel> Completed { get; set; }
        public List<DisplayAssignmentsViewModel> Overdue { get; set; }

    }
}