using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOlympiads.DomainObjects.Repositories 
{
    public abstract class ReadOnlyOlympiadRepositoryDecorator : IReadOnlyOlympiadRepository
    {
        private readonly IReadOnlyOlympiadRepository _olympiadRepository;

        public ReadOnlyOlympiadRepositoryDecorator(IReadOnlyOlympiadRepository olympiadRepository)
        {
            _olympiadRepository = olympiadRepository;
        }

        public virtual async Task<IEnumerable<Olympiad>> GetAllOlympiads()
        {
            return await _olympiadRepository?.GetAllOlympiads();
        }

        public virtual async Task<Olympiad> GetOlympiad(long id)
        {
            return await _olympiadRepository?.GetOlympiad(id);
        }

        public virtual async Task<IEnumerable<Olympiad>> QueryOlympiads(ICriteria<Olympiad> criteria)
        {
            return await _olympiadRepository?.QueryOlympiads(criteria);
        }
    }
}
