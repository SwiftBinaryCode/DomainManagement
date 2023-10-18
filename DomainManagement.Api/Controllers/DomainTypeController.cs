using DomainManagement.Application.Features.DomainType.Commands.CreateDomainType;
using DomainManagement.Application.Features.DomainType.Commands.DeleteDomainType;
using DomainManagement.Application.Features.DomainType.Commands.UpdateDomainType;
using DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes;
using DomainManagement.Application.Features.DomainType.Queries.GetDomainTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DomainManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    /// <summary>
    /// Handles CRUD operations for domain types, utilizing the Mediator pattern for command and query handling.
    /// </summary>
    public class DomainTypeController : ControllerBase
    {
        /// <summary>
        /// A mediator for handling the sending of commands and queries, providing a mechanism for 
        /// decoupling and enhancing the testability and maintenance of the application.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainTypeController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator for sending commands and queries.</param>
        public DomainTypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Retrieves all domain types.
        /// </summary>
        /// <returns>A list of domain type DTOs.</returns>
        /// <response code="200">Returns the list of domain types.</response>
        [HttpGet]
        public async Task<List<DomainTypeDto>> Get()
        {
            var domainTypes = await _mediator.Send(new GetDomainTypesQuery());
            return domainTypes;
        }

        /// <summary>
        /// Retrieves a specific domain type by ID.
        /// </summary>
        /// <param name="id">The ID of the domain type.</param>
        /// <returns>An ActionResult containing the specific domain type DTO.</returns>
        /// <response code="200">Returns the domain type.</response>
        /// <response code="404">If the domain type is not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<DomainTypeDto>> Get(int id)
        {
            var domainType = await _mediator.Send(new GetDomainTypesDetailsQuery(id));
            return Ok(domainType);
        }

        /// <summary>
        /// Creates a new domain type.
        /// </summary>
        /// <param name="domaintype">The command containing the details of the domain type to create.</param>
        /// <returns>A response indicating the result of the creation operation.</returns>
        /// <response code="201">Indicates that the domain type was created successfully.</response>
        /// <response code="400">If the command is invalid.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateDomainTypeCommand domaintype)
        {
            var response = await _mediator.Send(domaintype);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        /// <summary>
        /// Updates an existing domain type.
        /// </summary>
        /// <param name="domaintype">The command containing the updated details of the domain type.</param>
        /// <returns>A response indicating the result of the update operation.</returns>
        /// <response code="204">Indicates that the domain type was updated successfully.</response>
        /// <response code="400">If the command is invalid.</response>
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

        /// <summary>
        /// Deletes a specific domain type by ID.
        /// </summary>
        /// <param name="id">The ID of the domain type to delete.</param>
        /// <returns>A response indicating the result of the deletion operation.</returns>
        /// <response code="204">Indicates that the domain type was deleted successfully.</response>
        /// <response code="404">If the domain type is not found.</response>
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
