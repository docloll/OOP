using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.ApplicationServices.GetOlympiadListUseCase;
using SchoolOlympiads.InfrastructureServices.Presenters;

namespace SchoolOlympiads.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OlympiadsController : ControllerBase
    {
        private readonly ILogger<OlympiadsController> _logger;
        private readonly IGetOlympiadListUseCase _getOlympiadListUseCase;

        public OlympiadsController(ILogger<OlympiadsController> logger, IGetOlympiadListUseCase getOlympiadListUseCase)
        {
            _logger = logger;
            _getOlympiadListUseCase = getOlympiadListUseCase;
        }

        [HttpGet]

        public async Task<ActionResult> GetAllOlympiads()
        {
            var presenter = new OlympiadListPresenter();
            await _getOlympiadListUseCase.Handle(GetOlympiadListUseCaseRequest.CreateAllOlympiadsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{routeId}")]
        public async Task<ActionResult> GetOlympiad(long olympiadId)
        {
            var presenter = new OlympiadListPresenter();
            await _getOlympiadListUseCase.Handle(GetOlympiadListUseCaseRequest.CreateOlympiadRequest(olympiadId), presenter);
            return presenter.ContentResult;
        }
    }
}
