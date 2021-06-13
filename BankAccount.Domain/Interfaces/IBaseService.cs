using BankAccount.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity 
    {
        TOutputModel Add<TInputModel, TOutputModel>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class;

        IEnumerable<TOutputModel> Get<TOutputModel>() where TOutputModel : class;

    }
}
