﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Product.Dtos.ProductManagerModule.Common
{
    public class FilterDtos
    {
        [FromQuery(Name = "PageIndex")]
        public int PageIndex { get; set; } = 1;

        [FromQuery(Name = "PageSize")]
        public int PageSize { get; set; } = 5;

        private string _keyWord;
        [FromQuery(Name = "KeyWord")]
        public string? KeyWord
        {
            get => _keyWord;
            set => _keyWord = value?.Trim();
        }

        public int Skip()
        {
            return (PageIndex - 1) * PageSize;
        }

    }
}
