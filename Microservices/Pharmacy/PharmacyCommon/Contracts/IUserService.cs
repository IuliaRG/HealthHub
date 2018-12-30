using PharmacyCommon.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyCommon.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        void AddOrUpdateUser(UserDto user);
    }
}
