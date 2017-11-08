using Ignite.Areas.Admin.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ignite.Areas.Admin.ViewModels.statistics;
using Ignite.Data;
using Ignite.Data.Models;
using Ignite.Data.Enums;

namespace Ignite.Areas.Admin.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext context;

        public StatisticsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<AssignmentViewModel> GetDataFromServer()
        {
            var assignmentsViewModel = new List<AssignmentViewModel>();

            var assignments = this.context.Assignments.ToList();


            for (int i = 0; i < assignments.Count; i++)
            {
                var courseName = assignments[i].Course.Name;
                var username = assignments[i].User.UserName;

                if (assignments[i].DueDate < DateTime.Now)
                    assignments[i].State = AssignmentState.Overdue;

                assignmentsViewModel.Add(new AssignmentViewModel()
                {
                    Id = assignments[i].Id,
                    Username = username,
                    CourseName = courseName,
                    DueDate = assignments[i].DueDate,
                    DateOfAssignment = assignments[i].DateOfAssignment,
                    Type = assignments[i].Type,
                    State = assignments[i].State
                });
            }
            assignmentsViewModel.Add(new AssignmentViewModel() { Username = "pesho" });

            return assignmentsViewModel;
        }
    }
}