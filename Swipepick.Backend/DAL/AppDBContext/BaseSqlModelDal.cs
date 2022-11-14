﻿using DAL.Entities.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AppDBContext
{
    public class BaseSqlModelDal<TType> : IDalModel<TType>
    {
        public TType Id { get; init; }
    }
}
