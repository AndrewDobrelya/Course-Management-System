﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagementSystem.Models.LogicModels.ViewModels
{
    public class AjaxResponseModel
    {
        public int Length { get; set; }
        public string[] Data { get; set; }
        public string[] Value { get; set; }
    }
}