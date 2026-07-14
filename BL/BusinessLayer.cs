using DAL;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.FileConverters;
using DAL.Exceptions;
using BL.Exceptions;
using System.Reflection;
using Domains.CustomeAttributes;
using System.Text.RegularExpressions;

namespace BL
{
    public class BusinessLayer<T> : IBusiness<T> where T : Domains.BaseEntity, new()
    {
        IRepository<T> _repo = new Repository<T>(new JsonConverter<T>());

        //public BusinessLayer(IRepository<T> repo)
        //{
        //    _repo = repo;
        //}
        public async Task Add(T model)
        {
            try
            {
                if (!Validate(model))
                    throw new ValidationException("", "");
                await _repo.Add(model);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("", "", ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _repo.Delete(id);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("", "", ex);
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                var items = await _repo.GetAll();
                if (items == null)
                    throw new NotFoundException("", "");
                return items;
            }
            catch (SerializationException)
            {
                return new List<T>();
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("", "", ex);
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ValidationException("", "");
                return await _repo.GetById(id);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("", "", ex);
            }
        }

        public async Task Update(T model)
        {
            try
            {
                if (!Validate(model))
                    throw new ValidationException("", "");
                await _repo.Update(model);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("", "", ex);
            }
        }

        public bool Validate(T model)
        {
            IValidator<T> validator = new Validator<T>();
            return validator.Validate(model);
        }
    }
}
