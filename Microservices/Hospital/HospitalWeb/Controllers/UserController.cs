using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.Dtos;
using Common.Contracts;

namespace CoreProject.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET api/values
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public void AddOrUpdate([FromBody] UserDto user)
        {
            _userService.AddOrUpdateUser(user);
        }
        [HttpGet]
        [Route("GetValues")]
        public IEnumerable<UserDto> Get()
        {
            return _userService.GetAllUsers();
        }

      
    }
}
