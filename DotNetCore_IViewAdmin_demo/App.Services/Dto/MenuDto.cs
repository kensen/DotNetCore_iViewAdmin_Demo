using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace App.Services.Dto
{
    public class MenuDto
    {
        public string name { get; set; }

        public string icon => meta.icon??"";

        public string href => meta.href ?? "";

        public Meta meta { get; set; }

        public List<MenuDto> children { get; set; }
    }

    public class Meta
    {
        public string title {get; set; }
        public string icon { get; set; }
        public string href { get; set; }
        public string[] access { get; set; }
        public bool showAlways { get; set; }
    }
}
