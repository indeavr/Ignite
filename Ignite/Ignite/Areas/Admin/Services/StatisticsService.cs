﻿using Ignite.Areas.Admin.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ignite.Areas.Admin.ViewModels.statistics;
using Ignite.Data;
using Ignite.Data.Models;
using Ignite.Data.Enums;
using Newtonsoft.Json;
using Ignite.Areas.Admin.ViewModels;

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
                    Id = i,
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

        private IList<ApplicationUser> Filtrator(string propertyName, string shortOp, string inputField, IList<ApplicationUser> users)
        {
            var result = new List<ApplicationUser>();

            switch (propertyName)
            {
                case "Username":
                    result.AddRange(users.Where(x => x.UserName.Contains(inputField)).ToList());

                    break;
                case "State":
                    var state = (AssignmentState)Enum.Parse(typeof(AssignmentState), inputField);
                    result.AddRange(users.Where(u => u.Assignments.Select(a => a.State).Contains(state)));

                    break;
                case "Coursename":
                    result.AddRange(users.Where(x => x.Assignments.Select(y => y.Course.Name).Contains(inputField)));

                    break;
            }

            return result;
        }

        public object SearchAndGetData(string filters)
        {
            var parsedFilters = JsonConvert.DeserializeObject<GridRequestViewModel>(filters);
            var counter = 1;

            var users = context.Users.ToList();

            var propertyName = parsedFilters.rules.First().field;
            var shortenedOperator = parsedFilters.rules.First().op;
            var inputedField = parsedFilters.rules.First().data;
            var result = new List<AssignmentViewModel>();

            foreach (var user in this.Filtrator(propertyName, shortenedOperator, inputedField, users))
            { 
                foreach (var courses in user.Assignments)
                {
                    if (courses.DueDate < DateTime.Now)
                    {
                        courses.State = AssignmentState.Overdue;
                    }
                    result.Add(new AssignmentViewModel()
                    {
                        Id = counter,
                        Username = user.UserName,
                        CourseName = courses.Course.Name,
                        DateOfAssignment = courses.DateOfAssignment,
                        DueDate = courses.DueDate,
                        State = courses.State
                    });
                }
            }

            var needed = new { total = 1, page = 1, records = result.Count, rows = result };

            return needed;
        }
    }
}