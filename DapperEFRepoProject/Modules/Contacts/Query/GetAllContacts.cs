using Carter;
using DapperEFRepoProject.Infrastructure.Mapping;
using DapperEFRepoProject.Infrastructure.Utility;
using DapperEFRepoProject.Modules.Common.Response;
using DapperEFRepoProject.Modules.Contacts.Request;
using DapperEFRepoProject.Modules.Contacts.Service;
using FluentValidation;

namespace DapperEFRepoProject.Modules.Contacts.Query
{
    /// <summary>
    /// Represents the get all contacts module.
    /// </summary>
    public class GetAllContacts : CarterModule
    {
        /// <summary>
        /// The logger used to log information to the console.
        /// </summary>
        private readonly ILogger<GetAllContacts> _logger;
        /// <summary>
        /// The validator for the GetAllContacts request
        /// </summary>
        private readonly IValidator<GetAllContactRequest> _validator;
        /// <summary>
        /// The contact service
        /// </summary>
        private readonly IContactService _contactService;
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllContacts"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="validator"></param>
        /// <param name="contactService"></param>
        public GetAllContacts(
            ILogger<GetAllContacts> logger, 
            IValidator<GetAllContactRequest> validator, 
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
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/contacts", GetAllContactsAsync);
        }
        /// <summary>
        /// Gets all contacts.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private async ValueTask<IResult> GetAllContactsAsync(HttpContext context, GetAllContactRequest request)
        {
            _logger.LogInformation("Getting all contacts");
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for request {@Request}", request);
                return Results.BadRequest(new ErrorResponse
                {
                    Message = "Validation failed",
                    ValidationErrors = validationResult.Errors.Select(e => ValidationErrorMapper.MapValidationError(e)).ToList()
                });
            }
            var contacts = await _contactService.GetAllContactsAsync();
            return contacts is not null && contacts.Any()? Results.Ok(contacts.ToContactListResponse()) : Results.NotFound();
        }
    }
}
