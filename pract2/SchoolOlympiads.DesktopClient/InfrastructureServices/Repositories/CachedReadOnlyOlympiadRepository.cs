using SchoolOlympiads.ApplicationServices.Ports.Cache;
using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.DomainObjects.Ports;
using SchoolOlympiads.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOlympiads.InfrastructureServices.Repositories
{
    public class CachedReadOnlyOlympiadRepository : ReadOnlyOlympiadRepositoryDecorator
    {
        private readonly IDomainObjectsCache<Olympiad> _olympiadsCache;

        public CachedReadOnlyOlympiadRepository(IReadOnlyOlympiadRepository OlympiadRepository,
                                             IDomainObjectsCache<Olympiad> olympiadsCache)
            : base(OlympiadRepository)
            => _olympiadsCache = olympiadsCache;

        public async override Task<Olympiad> GetOlympiad(long id)
            => _olympiadsCache.GetObject(id) ?? await base.GetOlympiad(id);

        public async override Task<IEnumerable<Olympiad>> GetAllOlympiads()
            => _olympiadsCache.GetObjects() ?? await base.GetAllOlympiads();

        public async override Task<IEnumerable<Olympiad>> QueryOlympiads(ICriteria<Olympiad> criteria)
            => _olympiadsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryOlympiads(criteria);

    }
}
