using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolOlympiads.ApplicationServices.GetOlympiadListUseCase
{
    public class GetOlympiadListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<Olympiad> Olympiads { get; }

        public GetOlympiadListUseCaseResponse(IEnumerable<Olympiad> olympiads) => Olympiads = olympiads;
    }
}
