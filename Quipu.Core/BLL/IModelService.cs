using Microsoft.AspNetCore.Mvc;
using Quipu.Core.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quipu.Core.BLL
{
    public interface IModelService<T> 
    {      
        public Task<ActionResult<IEnumerable<T>>> Get();
        public Task<ActionResult<T>> Get(int id);
        public Task<bool> Put(T entity);
        public Task<T> Post(T entity);
        public Task<bool> Delete(int id);

    }
}
