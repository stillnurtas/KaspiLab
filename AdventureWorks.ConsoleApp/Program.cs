﻿using AdventureWorks.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Types;
using AdventureWorks.Repository.UnitOfWork;

namespace AdventureWorks.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AWUnitOfWork(new AWContext()))
            {
                var t = db.Address.GetAll();
            }
        }
    }
}