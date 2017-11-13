using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Ignite.Areas.Admin.ViewModels
{
    public class ManageUserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public bool IsAdmin { get; set; }

        public static Expression<Func<ApplicationUser, ManageUserViewModel>> Create
        {
            get
            {
                return u => new ManageUserViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName
                };
            }
        }

    }
}