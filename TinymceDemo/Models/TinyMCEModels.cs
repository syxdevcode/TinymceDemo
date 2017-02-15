using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinymceDemo.Models
{
    public class TinyMCEModels
    {
        [AllowHtml]
        public string content { get; set; }
    }
}