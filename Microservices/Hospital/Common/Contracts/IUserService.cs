using Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        void AddOrUpdateUser(UserDto user);
    }
}
