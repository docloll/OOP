using SchoolOlympiads.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolOlympiads.ApplicationServices.GetOlympiadListUseCase
{
    public class GetOlympiadListUseCaseRequest : IUseCaseRequest<GetOlympiadListUseCaseResponse>
    {
        public long? OlympiadId { get; private set; }

        private GetOlympiadListUseCaseRequest()
        { }

        public static GetOlympiadListUseCaseRequest CreateAllOlympiadsRequest()
        {
            return new GetOlympiadListUseCaseRequest();
        }

        public static GetOlympiadListUseCaseRequest CreateOlympiadRequest(long olympiadId)
        {
            return new GetOlympiadListUseCaseRequest() { OlympiadId = olympiadId };

        }
    }
}

