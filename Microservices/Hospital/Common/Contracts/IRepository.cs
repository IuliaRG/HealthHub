using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object Id);
        void Save();
    }
}
