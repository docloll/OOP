using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SchoolOlympiads.ApplicationServices.Repositories;
using SchoolOlympiads.ApplicationServices.Ports;
using SchoolOlympiads.ApplicationServices.GetOlympiadListUseCase;
using Xunit;
using SchoolOlympiads.DomainObjects;

namespace SchoolOlympiads.WebService.Tests
{
    public class GetOlympiadListUseCaseTest 
    {        
        private InMemoryOlympiadRepository CreateRoteRepository()
        {
            var repo = new InMemoryOlympiadRepository(new List<Olympiad> {
                new Olympiad { Id = 1,  Name = "Олимпиада №1" , Class = "7 - 11", Subject = "Математика" , Type = "Московская", Year = 2012},
                new Olympiad { Id = 2,  Name = "Олимпиада №2" , Class = "6 - 10", Subject = "Русский" , Type = "Школьная", Year = 2013},
                new Olympiad { Id = 3,  Name = "Олимпиада №3" , Class = "5 - 9", Subject = "Литература" , Type = "Районная", Year = 2014},
                new Olympiad { Id = 4,  Name = "Олимпиада №4" , Class = "4 - 7", Subject = "География" , Type = "Всероссийская", Year = 2015},
            });
            return repo;
        }

        [Fact]
        public void TestGetAllOlympiads()
        {
            var useCase = new GetOlympiadListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetOlympiadListUseCaseRequest.CreateAllOlympiadsRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.Olympiads.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.Olympiads.Select(o => o.Id));
        }

        [Fact]
        public void TestGetAlllympiadsFromEmptyRepository()
        {
            var useCase = new GetOlympiadListUseCase(new InMemoryOlympiadRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetOlympiadListUseCaseRequest.CreateAllOlympiadsRequest(), outputPort).Result);
            Assert.Empty(outputPort.Olympiads);
        }

        [Fact]
        public void TestGetOlympiad()
        {
            var useCase = new GetOlympiadListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetOlympiadListUseCaseRequest.CreateOlympiadRequest(2), outputPort).Result);
            Assert.Single(outputPort.Olympiads, r => 2 == r.Id);
        }

        [Fact]
        public void TestTryGetNotExistingOlympiad()
        {
            var useCase = new GetOlympiadListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetOlympiadListUseCaseRequest.CreateOlympiadRequest(999), outputPort).Result);
            Assert.Empty(outputPort.Olympiads);
        }

    }

    class OutputPort : IOutputPort<GetOlympiadListUseCaseResponse>
    {
        public IEnumerable<Olympiad> Olympiads { get; private set; }

        public void Handle(GetOlympiadListUseCaseResponse response)
        {
            Olympiads = response.Olympiads;
        }
    }

}
