using SchoolOlympiads.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolOlympiads.ApplicationServices.Ports.Gateways.Database
{
    public interface IOlympiadDatabaseGateway
    {
        Task AddOlympiad(Olympiad olympiad);

        Task RemoveOlympiad(Olympiad olympiad);

        Task UpdateOlympiad(Olympiad olympiad);

        Task<Olympiad> GetOlympiad(long id);

        Task<IEnumerable<Olympiad>> GetAllOlympiads();

        Task<IEnumerable<Olympiad>> QueryOlympiads(Expression<Func<Olympiad, bool>> filter);

    }
}
