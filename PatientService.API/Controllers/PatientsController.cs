using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientService.Application.Patients.Commands;
using PatientService.Application.Patients.Dtos;
using PatientService.Application.Patients.Queries;

namespace PatientService.API.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Guid> Create(CreatePatientCommand cmd)
        {
            return await _mediator.Send(cmd);
        }

        [HttpGet]
        public async Task<IEnumerable<PatientDto>> Search([FromQuery] string? birthDate)
        {
            return await _mediator.Send(new SearchPatientsQuery(birthDate));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdatePatientCommand body)
        {
            await _mediator.Send(body with { Id = id });
            return NoContent();
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeletePatientCommand(id));
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetById(Guid id)
        {
            var patient = await _mediator.Send(new GetPatientByIdQuery(id));

            return Ok(patient);
        }
    }
}
