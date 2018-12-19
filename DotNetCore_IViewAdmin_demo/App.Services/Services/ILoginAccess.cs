using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Dto;

namespace App.Services
{
    public interface ILoginAccess
    {
        UserInfoDto Login(string loginId, string password);

        UserInfoDto GetDto(int Id);

        UserInfoDto GetDto(string loginId);

        bool ChangePwd(string loginId, string password);

    }
}
