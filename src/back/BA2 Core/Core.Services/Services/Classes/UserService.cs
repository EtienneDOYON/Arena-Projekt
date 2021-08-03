using AutoMapper;
using Core.Data.Repository.Interfaces;
using Core.Data.UnitOfWork;
using Core.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public UserService(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public bool DoesUserExist(string username, string password)
        {
            return uow.userRepository.IsUserValid(username, password);
        }
    }
}
