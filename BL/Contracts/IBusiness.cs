using DAL.Exceptions;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BL
{
    public interface IBusiness<T> where T : BaseEntity , new()
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public Task Add(T model);
        public Task Update(T model);
        public Task Delete(int id);
        public bool Validate(T model);
    }
}
