using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Dtos;
using Common.Entities;
using System.Linq;
using AutoMapper;

namespace BusinessLogic
{
    public class UserService : IUserService
    {
        protected IRepository<User> userRepository;
        protected  IMapper _mapper;
        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            _mapper = mapper;


        }
        public void AddOrUpdateUser(UserDto user)
        {
            User entityUser = null;
            if (user.Id == null)
            {
                entityUser = userRepository.GetAll().FirstOrDefault(it => it.Id == user.Id);
                var actionItemAreasModels = _mapper
                .Map<User>(user);
               // entityUser.FromApplicationUserDto(user);
                userRepository.Insert(actionItemAreasModels);
            }
            else
            {
                user.UserName = user.FirstName;
                entityUser = userRepository.GetAll().FirstOrDefault(it => it.UserName == user.UserName);
                var actionItemAreasModels = _mapper
                .Map<User>(user);
                userRepository.Update(actionItemAreasModels);
            }
            userRepository.Save();
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var userEnitiy = userRepository.GetAll().ToList();
            
           
            var actionItemAreasModels = _mapper
              .Map<IEnumerable<UserDto>>(userEnitiy);

            return actionItemAreasModels;
        }
    }
}
