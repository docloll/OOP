using System.Net;
using Newtonsoft.Json;
using SchoolOlympiads.ApplicationServices.Ports;
using SchoolOlympiads.ApplicationServices.GetOlympiadListUseCase;

namespace SchoolOlympiads.InfrastructureServices.Presenters
{
    public class OlympiadListPresenter : IOutputPort<GetOlympiadListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public OlympiadListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetOlympiadListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Olympiads) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
