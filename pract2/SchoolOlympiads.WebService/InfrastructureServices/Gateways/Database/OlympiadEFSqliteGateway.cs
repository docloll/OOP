using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.ApplicationServices.Ports.Gateways.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolOlympiads.InfrastructureServices.Gateways.Database
{
    public class OlympiadEFSqliteGateway : IOlympiadDatabaseGateway 
    {
        private readonly OlympiadContext _olympiadContext;

        public OlympiadEFSqliteGateway(OlympiadContext olympiadContext)
            => _olympiadContext = olympiadContext;

        public async Task<Olympiad> GetOlympiad(long id)
           => await _olympiadContext.Olympiads.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Olympiad>> GetAllOlympiads()
            => await _olympiadContext.Olympiads.ToListAsync();

        public async Task<IEnumerable<Olympiad>> QueryOlympiads(Expression<Func<Olympiad, bool>> filter)
            => await _olympiadContext.Olympiads.Where(filter).ToListAsync();

        public async Task AddOlympiad(Olympiad olympiad)
        {
            _olympiadContext.Olympiads.Add(olympiad);
            await _olympiadContext.SaveChangesAsync();
        }

        public async Task UpdateOlympiad(Olympiad olympiad)
        {
            _olympiadContext.Entry(olympiad).State = EntityState.Modified;
            await _olympiadContext.SaveChangesAsync();
        }

        public async Task RemoveOlympiad(Olympiad olympiad)
        {
            _olympiadContext.Olympiads.Remove(olympiad);
            await _olympiadContext.SaveChangesAsync();
        }
    }
}
