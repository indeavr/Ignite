﻿using Ignite.Data.Models;
using Ignite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Services.Contracts
{
    public interface IQuizService
    {
        List<QuizQuestion> GetTest(int courseId);
    }
}