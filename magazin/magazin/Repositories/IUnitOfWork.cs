﻿namespace magazin.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        void SaveChanges();
    }
}
