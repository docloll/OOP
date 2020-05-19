using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolOlympiads.ApplicationServices.Repositories
{
    public class InMemoryOlympiadRepository : IReadOnlyOlympiadRepository,
                                           IOlympiadRepository
    {
        private readonly List<Olympiad> _olympiads = new List<Olympiad>();

        public InMemoryOlympiadRepository(IEnumerable<Olympiad> olympiads = null)
        {
            if (olympiads != null)
            {
                _olympiads.AddRange(olympiads);
            }
        }

        public Task AddOlympiad(Olympiad olympiad)
        {
            _olympiads.Add(olympiad);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Olympiad>> GetAllOlympiads()
        {
            return Task.FromResult(_olympiads.AsEnumerable());
        }

        public Task<Olympiad> GetOlympiad(long id)
        {
            return Task.FromResult(_olympiads.Where(o => o.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Olympiad>> QueryOlympiads(ICriteria<Olympiad> criteria)
        {
            return Task.FromResult(_olympiads.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveOlympiad(Olympiad olympiad)
        {
            _olympiads.Remove(olympiad);
            return Task.CompletedTask;
        }

        public Task UpdateOlympiad(Olympiad olympiad)
        {
            var foundOlympiad = GetOlympiad(olympiad.Id).Result;
            if (foundOlympiad == null)
            {
                AddOlympiad(olympiad);
            }
            else
            {
                if (foundOlympiad != olympiad)
                {
                    _olympiads.Remove(foundOlympiad);
                    _olympiads.Add(olympiad);
                }
            }
            return Task.CompletedTask;
        }
    }
}
