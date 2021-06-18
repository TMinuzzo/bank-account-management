using BankAccount.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace BankAccount.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity 
    {
        TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>;

        IEnumerable<TOutputModel> Get<TOutputModel>() where TOutputModel : class;
        
        TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class;

        TOutputModel Update<TInputModel, TOutputModel>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class;
    }
}
