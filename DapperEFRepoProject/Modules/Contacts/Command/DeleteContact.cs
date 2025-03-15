using Carter;
using DapperEFRepoProject.Infrastructure.Utility;
using DapperEFRepoProject.Modules.Common.Response;
using DapperEFRepoProject.Modules.Contacts.Request;
using DapperEFRepoProject.Modules.Contacts.Service;
using FluentValidation;

namespace DapperEFRepoProject.Modules.Contacts.Command
{
    /// <summary>
    /// Represents the delete contact module.
    /// </summary>
    public class DeleteContact : CarterModule
    {
        /// <summary>
        /// The logger used to log information to the console.
        /// </summary>
        private readonly ILogger<DeleteContact> _logger;
        /// <summary>
        /// The validator used to validate the request.
        /// </summary>
        private readonly IValidator<DeleteContactRequest> _validator;
        /// <summary>
        /// The contact service used to interact with the database.
        /// </summary>
        private readonly IContactService _contactService;
        /// <summary>
        /// Creates a new instance of the <see cref="DeleteContact"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="validator"></param>
        /// <param name="contactService"></param>
        public DeleteContact(
            ILogger<DeleteContact> logger, 
            IValidator<DeleteContactRequest> validator, 
            IContactService contactService)
        {
            _logger = logger;
            _validator = validator;
            _contactService = contactService;
        }
        /// <summary>
        /// Adds the routes to the module.
        /// </summary>
        /// <param name="app"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/contacts/{id:int}", DeleteContactAsync);
        }
        /// <summary>
        /// Deletes a contact from the database.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private async ValueTask<IResult> DeleteContactAsync(HttpContext context, int id )
        {
            _logger.LogInformation("Deleting contact with id {Id}", id);
            var deleteConatct = new DeleteContactRequest { Id = id };
            var result = _validator.Validate(deleteConatct);
            if (!result.IsValid)
            {
                _logger.LogWarning("Validation failed for request {@Request}", deleteConatct);
                return Results.BadRequest(new ErrorResponse
                {
                    Message = "Validation failed",
                    ValidationErrors = result.Errors.Select(e => ValidationErrorMapper.MapValidationError(e)).ToList()
                });
            }
            var isContactDeleted = await _contactService.DeleteContactAsync(id);
            _logger.LogWarning("Deleting Contact with Id {Id} successful", id);
            return isContactDeleted ? Results.NoContent() : Results.NotFound();
        }
    }
}
