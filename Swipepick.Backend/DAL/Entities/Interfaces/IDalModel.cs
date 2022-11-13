﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Interfaces
{
    internal interface IDalModel<TType>
    {
        public TType Id { get; init; }
    }
}
