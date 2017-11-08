using Ignite.Areas.Admin.ViewModels.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.Areas.Admin.Services.Interfaces
{
    public interface IStatisticsService
    {
        List<AssignmentViewModel> GetDataFromServer();
    }
}