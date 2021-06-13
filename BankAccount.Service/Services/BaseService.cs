using AutoMapper;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public TOutputModel Add<TInputModel, TOutputModel>(TInputModel inputModel) 
            where TOutputModel : class
            where TInputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            _baseRepository.Insert(entity);

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }
    }
}
