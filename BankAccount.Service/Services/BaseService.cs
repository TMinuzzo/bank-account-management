using AutoMapper;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<TOutputModel> Get<TOutputModel>() 
            where TOutputModel : class
        {
            var entities = _baseRepository.Select();

            var outputModels = entities.Select(e => _mapper.Map<TOutputModel>(e));

            return outputModels;
        }

        public TOutputModel Update<TInputModel, TOutputModel>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            _baseRepository.Update(entity);

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }
    }
}
