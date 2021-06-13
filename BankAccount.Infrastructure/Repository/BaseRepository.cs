using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using BankAccount.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        protected readonly MySqlContext _mySqlContext;
        
        public BaseRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public void Insert(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> Select()
        {
            throw new NotImplementedException();
        }

        public TEntity Select(int id)
        {
            throw new NotImplementedException();
        }


    }
}
