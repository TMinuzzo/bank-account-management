using AutoMapper;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

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
        // Receives a generic Input, Output and Validator type, operate the mappings, validations and Insert on db.
        public TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TOutputModel : class
            where TInputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            TValidator validator = Activator.CreateInstance<TValidator>();

            validator.ValidateAndThrow(entity);

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
        public TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class
        {
            var entity = _baseRepository.Select(id);

            var outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
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
