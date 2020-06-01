using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SchoolOlympiads.DomainObjects.Ports
{
    public interface IReadOnlyOlympiadRepository
    {
        Task<Olympiad> GetOlympiad(long id);

        Task<IEnumerable<Olympiad>> GetAllOlympiads();

        Task<IEnumerable<Olympiad>> QueryOlympiads(ICriteria<Olympiad> criteria);

    }

    public interface IOlympiadRepository
    {
        Task AddOlympiad(Olympiad olympiad);

        Task RemoveOlympiad(Olympiad olympiad);

        Task UpdateOlympiad(Olympiad olympiad);
    }
}
