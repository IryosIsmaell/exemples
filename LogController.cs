using Ark.Domain.Helpers;
using Ark.Domain.Models.Dto.Info;
using Ark.Infra.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArkServer.WebApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogRegisterService _service;

        public LogController(ILogRegisterService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LogDto value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseError(422, ModelState.Values));
            }

            if (value?.FilialId == null)
            {
                return BadRequest(new ResponseError(400, "Id Filial não informado!"));
            }

            _service.RegistroExt(value);

            return Ok(new Response<object>(200, null));
        }

    }
}
