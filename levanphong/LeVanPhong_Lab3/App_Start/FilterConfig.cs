﻿using System.Web;
using System.Web.Mvc;

namespace LeVanPhong_Lab3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}