using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Infra.Data.Repository;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);

            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);

            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new Exception("The Id can't to be zero");

            repository.Delete(id);
        }

        public IList<T> Get() => repository.Select();

        public T Get(int id)
        {
            if (id == 0)
                throw new Exception("The Id can't to be zero");

            return repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Not found Data");

            validator.ValidateAndThrow(obj);
        }

    }
}
