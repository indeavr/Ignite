using Ignite.Areas.Admin.ViewModels;
using Ignite.Areas.Admin.ViewModels.statistics;
using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.Areas.Admin.Services.Interfaces
{
    public interface IStatisticsService
    {
        List<OverdueCourse> GetAllOverdue();

        List<AssignmentViewModel> GetDataFromServer();

        object SearchAndGetData(string filters);
    }
}