﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Function.App.Data.DatabaseManager.Interfaces
{
    public interface IClientContextStrategy<T> : IRepository<T> where T : class
    {
    }
}