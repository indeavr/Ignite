using Ignite.Areas.Admin.Services.Interfaces;
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

        public void CheckForOverdueAndUpdate()
        {
            var assignments = this.context.Assignments.ToList();

            foreach (var assignment in assignments)
            {
                if (assignment.DueDate < DateTime.Now)
                {
                    assignment.State = AssignmentState.Overdue;
                    int id = assignment.Id;
                    this.context.Assignments.First(a => a.Id == id).State = AssignmentState.Overdue;
                    this.context.SaveChanges();
                }
            }
        }

        public List<OverdueCourse> GetAllOverdue()
        {
            var users = this.context.Users
                .Where(u => u.Assignments.Where(a => a.State == AssignmentState.Overdue).Count() > 0)
                .ToList();

            var allOverdue = new List<OverdueCourse>();
            foreach (var user in users)
            {
                var assignmentOverdue = user.Assignments
                    .Where(a => a.State == AssignmentState.Overdue);

                foreach (var assignOverdue in assignmentOverdue)
                {
                    var overdueCourse = new OverdueCourse();
                    overdueCourse.Username = user.UserName;
                    overdueCourse.CourseName = assignOverdue.Course.Name;
                    overdueCourse.OverdueWith = DateTime.Now - assignOverdue.DueDate;
                    allOverdue.Add(overdueCourse);
                }
            }

            return allOverdue;
        }

        public Object GetDataFromServer(int rows, int page)
        {
            var assignmentsViewModel = new List<AssignmentViewModel>();

            var users = this.context.Users.ToList();

            for (int i = 0; i < users.Count; i++)
            {
                var assignments = users[i].Assignments;

                var counter = 1;
                foreach (var assignment in assignments)
                {
                    var courseName = assignment.Course.Name;
                    var username = users[i].UserName;


                    assignmentsViewModel.Add(new AssignmentViewModel()
                    {
                        Id = counter,
                        Username = username,
                        CourseName = courseName,
                        DueDate = assignment.DueDate,
                        DateOfAssignment = assignment.DateOfAssignment,
                        Type = assignment.Type,
                        State = assignment.State.ToString()
                    });
                    counter++;
                }
            }

            var result = new
            {
                total = assignmentsViewModel.Count / rows + 1,
                page = page,
                records = assignmentsViewModel.Count,
                rows = assignmentsViewModel.Skip((page - 1) * rows).Take(rows).ToList()
            };

            return result;
        }

        public IList<ApplicationUser> Filtrator(string propertyName, string shortOp, string inputField, IList<ApplicationUser> users)
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

                case "CourseName":
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
                        State = courses.State.ToString(),
                        Type = courses.Type
                    });
                }
            }

            var needed = new { total = 1, page = 1, records = result.Count, rows = result };

            return needed;
        }
    }
}