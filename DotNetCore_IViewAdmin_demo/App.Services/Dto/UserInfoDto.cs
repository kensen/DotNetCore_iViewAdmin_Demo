using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Dto
{
    public class UserInfoDto
    {
        public  int Id { get; set; }
        public string UserName { get; set; }
        public string LoginId { get; set; }
        public byte? UserType { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string Authority { get; set; }
        public DateTime CreatedTime { get; set; }

}
}
