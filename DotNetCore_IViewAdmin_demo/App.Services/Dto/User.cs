using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Dto
{
    public class User
    { 
        public string name { get; set; }
        public int user_id { get; set; }
        public string[] access { get;set;}

        public string token { get; set; }
        public string avator { get; set; }
    }


}
