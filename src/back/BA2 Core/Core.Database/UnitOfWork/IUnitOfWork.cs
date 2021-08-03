using Core.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository userRepository { get; set; }
    }
}
