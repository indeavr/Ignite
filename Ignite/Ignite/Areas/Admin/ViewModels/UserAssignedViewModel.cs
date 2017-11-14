using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.Areas.Admin.ViewModels
{
    public class UserAssignedViewModel
    {
        public string Username { get; set; }

        public string UserId { get; set; }

        public bool Checked { get; set; }
    }
}