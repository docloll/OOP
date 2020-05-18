using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.DomainObjects.Ports;
using SchoolOlympiads.ApplicationServices.Ports;

namespace SchoolOlympiads.ApplicationServices.GetOlympiadListUseCase
{
    public class GetOlympiadListUseCase : IGetOlympiadListUseCase
    {
        private readonly IReadOnlyOlympiadRepository _readOnlyOlympiadRepository;

        public GetOlympiadListUseCase(IReadOnlyOlympiadRepository readOnlyOlympiadRepository)
            => _readOnlyOlympiadRepository = readOnlyOlympiadRepository;

        public async Task<bool> Handle(GetOlympiadListUseCaseRequest request, IOutputPort<GetOlympiadListUseCaseResponse> outputPort)
        {
            IEnumerable<Olympiad> olympiads = null;
            if (request.OlympiadId != null)
            {
                var olympiad = await _readOnlyOlympiadRepository.GetOlympiad(request.OlympiadId.Value);
                olympiads = (olympiad != null) ? new List<Olympiad>() { olympiad } : new List<Olympiad>();

            }
            else
            {
                olympiads = await _readOnlyOlympiadRepository.GetAllOlympiads();
            }
            outputPort.Handle(new GetOlympiadListUseCaseResponse(olympiads));
            return true;
        }
    }
}
