using Carter;
using DapperEFRepoProject.Infrastructure.Mapping;
using DapperEFRepoProject.Infrastructure.Utility;
using DapperEFRepoProject.Modules.Common.Response;
using DapperEFRepoProject.Modules.Contacts.Request;
using DapperEFRepoProject.Modules.Contacts.Service;
using FluentValidation;

namespace DapperEFRepoProject.Modules.Contacts.Command
{
    /// <summary>
    /// Represents the update contact module.
    /// </summary>
    public class UpdateContact : CarterModule
    {
        /// <summary>
        /// The logger used to log information to the console.
        /// </summary>
        private readonly ILogger<UpdateContact> _logger;
        /// <summary>
        /// The validator used to validate the request.
        /// </summary>
        private readonly IValidator<UpdateContactRequest> _validator;
        /// <summary>
        /// The contact service used to interact with the database.
        /// </summary>
        private readonly IContactService _contactService;

        /// <summary>
        /// Creates a new instance of the <see cref="UpdateContact"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="validator"></param>
        /// <param name="contactService"></param>
        public UpdateContact(
            ILogger<UpdateContact> logger, 
            IValidator<UpdateContactRequest> validator, 
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
            app.MapPost("/api/contacts/{id:int}", UpdateContactAsync);
        }
        /// <summary>
        /// Updates a contact in the database.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private async ValueTask<IResult> UpdateContactAsync(HttpContext context, int id, UpdateContactRequest request)
        {
            var result = _validator.Validate(request);
            if (!result.IsValid)
            {
                _logger.LogWarning("Validation failed for request {@Request}", request);
                return Results.BadRequest(new ErrorResponse
                {
                    Message = "Validation failed",
                    ValidationErrors = result.Errors.Select(e => ValidationErrorMapper.MapValidationError(e)).ToList()
                });
            }
            var contact = request.ToContact();
            contact.Id = id;
            var updatedContact = await _contactService.UpdateContactAsync(contact);
            return updatedContact is not null ? Results.Ok(updatedContact.ToContactResponse()) : Results.BadRequest();
        }
    }
}
