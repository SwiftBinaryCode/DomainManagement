using DomainManagement.Application.Features.DomainType.Commands.CreateDomainType;
using DomainManagement.Application.Features.DomainType.Commands.DeleteDomainType;
using DomainManagement.Application.Features.DomainType.Commands.UpdateDomainType;
using DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes;
using DomainManagement.Application.Features.DomainType.Queries.GetDomainTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DomainManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DomainTypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<DomainTypeController>
        [HttpGet]
        public async Task<List<DomainTypeDto>> Get()
        {
            var domainTypes = await _mediator.Send(new GetDomainTypesQuery());
            return domainTypes;
        }

        // GET api/<DomainTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DomainTypeDto>> Get(int id)
        {
            var domainType = await _mediator.Send(new GetDomainTypesDetailsQuery(id));
            return Ok(domainType);
        }


        // POST api/<DomainTypeController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateDomainTypeCommand domaintype)
        {
            var response = await _mediator.Send(domaintype);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<DomainTypeController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateDomainTypeCommand domaintype)
        {
            await _mediator.Send(domaintype);
            return NoContent();
        }

        // DELETE api/<DomainTypeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteDomainTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
