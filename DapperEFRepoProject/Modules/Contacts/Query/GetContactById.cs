using Carter;
using DapperEFRepoProject.Modules.Contacts.Request;
using DapperEFRepoProject.Modules.Contacts.Service;
using FluentValidation;

namespace DapperEFRepoProject.Modules.Contacts.Query
{
    /// <summary>
    /// Represents the get contact by id module.
    /// </summary>
    public class GetContactById : CarterModule
    {
        /// <summary>
        /// The logger used to log information to the console.
        /// </summary>
        private readonly ILogger<GetContactById> _logger;
        /// <summary>
        /// The contact service used to interact with the database.
        /// </summary>
        private readonly IContactService _contactService;
        /// <summary>
        /// The validator used to validate the request.
        /// </summary>
        private readonly IValidator<DeleteContactRequest> _validator;
        public GetContactById(
            ILogger<GetContactById> logger, 
            IContactService contactService, 
            IValidator<DeleteContactRequest> validator)
        {
            _logger = logger;
            _contactService = contactService;
            _validator = validator;
        }
        /// <summary>
        /// Adds the routes to the module.
        /// </summary>
        /// <param name="app"></param>
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/contacts/{id:int}", GetContactByIdAsync);
        }
        /// <summary>
        /// Gets a contact by its unique identifier.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async ValueTask<IResult> GetContactByIdAsync(HttpContext context, int id)
        {
            _logger.LogInformation("Getting contact with id {Id}", id);
            var contact = await _contactService.GetContactAsync(id);
            if (contact is null)
            {
                return Results.NotFound();
            }
            _logger.LogInformation("Getting contact with id {Id} successful", id);
            return Results.Ok(contact);
        }
    }
}
