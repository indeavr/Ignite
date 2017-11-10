using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.Areas.Admin.ViewModels
{
    public class GridRequestViewModel
    {
        public string groupOp { get; set; }

        public List<RulesViewModel> rules { get; set; }
    }
}