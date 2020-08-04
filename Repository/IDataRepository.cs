using InsuranceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCore.Repository
{
    public interface IDataRepository
    {
        Task<List<Contracts>> GetContracts();
        Task<Contracts> AddContracts(Contracts contracts);
        Task<Contracts> DeleteContracts(int? CustomerId);
        Task UpdateContracts(Contracts contracts);
    }
}


//IEnumerable<TEntity> GetAll();
//TEntity Get(long id);
//TDto GetDto(long id);
//void Add(TEntity entity);
//void Update(TEntity entityToUpdate, TEntity entity);
//void Delete(TEntity entity);
