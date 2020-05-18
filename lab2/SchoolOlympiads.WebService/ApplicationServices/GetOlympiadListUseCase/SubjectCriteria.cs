using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SchoolOlympiads.ApplicationServices.GetOlympiadListUseCase
{
    public class SubjectCriteria : ICriteria<Olympiad>
    {
        public string Subject { get; }

        public SubjectCriteria(string subject)
            => Subject = subject;

        public Expression<Func<Olympiad, bool>> Filter
            => (s => s.Subject == Subject);
    }
}
