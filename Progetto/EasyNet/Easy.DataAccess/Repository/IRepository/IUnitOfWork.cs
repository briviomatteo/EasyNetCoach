﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNet.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
