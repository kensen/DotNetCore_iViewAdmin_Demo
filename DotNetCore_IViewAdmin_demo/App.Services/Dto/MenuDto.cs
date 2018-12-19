using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace App.Services.Dto
{
    public class MenuDto
    {
        public string Name { get; set; }

        public string Icon => Meta.Icon??"";

        public string Href => Meta.Href ?? "";

        public Meta Meta { get; set; }

        public bool Show { get; set; }

        public List<MenuDto> Children { get; set; }
    }

    public class Meta
    {
        public string Title {get; set; }
        public string Icon { get; set; }
        public string Href { get; set; }
        public string[] Access { get; set; }
        public bool ShowAlways { get; set; }
    }
}
