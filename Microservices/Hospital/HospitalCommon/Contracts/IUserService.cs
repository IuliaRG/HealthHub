using HospitalCommon.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalCommon.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        void AddOrUpdateUser(UserDto user);
    }
}
