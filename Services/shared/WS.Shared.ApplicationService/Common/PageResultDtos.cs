﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Shared.ApplicationService.Common
{
    public class PageResultDtos<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItem { get; set; }

    }
}
