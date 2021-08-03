using Core.Data.Repository.Classes;
using Core.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Core.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private CoreContext dataContext;


        public IUserRepository userRepository { get; set; }

        public UnitOfWork(IUnityContainer unityContainer)
        {
            InitializeContext(unityContainer);
            InitializeRepositories(unityContainer);
        }

        private void InitializeContext(IUnityContainer unityContainer)
        {
            dataContext = unityContainer.Resolve<CoreContext>();
        }

        private void InitializeRepositories(IUnityContainer unityContainer)
        {
            userRepository = InitializeRepository<IUserRepository, UserRepository>(unityContainer);
        }

        private T1 InitializeRepository<T1, T2>(IUnityContainer unityContainer)
            where T2 : T1
        {
            unityContainer.RegisterType<T1, T2>();
            return unityContainer.Resolve<T1>();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;

            if (disposing)
            {
                try
                {
                    if (dataContext.Database.GetDbConnection().State == System.Data.ConnectionState.Open)
                    {
                        dataContext.Database.CloseConnection();
                    }
                }
                catch (ObjectDisposedException)
                {
                    // Do nothing, the object has already been disposed
                }

                if (this.dataContext != null)
                {
                    this.dataContext.Dispose();
                    this.dataContext = null;
                }
            }

            this._disposed = true;
        }
    }
}
