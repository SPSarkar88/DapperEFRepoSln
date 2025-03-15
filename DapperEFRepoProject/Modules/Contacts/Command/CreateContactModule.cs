﻿using DapperEFRepoProject.Infrastructure.Mapping;
using DapperEFRepoProject.Modules.Common.Response;
using DapperEFRepoProject.Modules.Contacts.Request;
using DapperEFRepoProject.Modules.Contacts.Service;
using FluentValidation;
using FluentValidation.Results;

namespace ContactManager.Modules.Contacts.Commands
{
    /// <summary>
    /// Represents the create contact module.
    /// </summary>
    public class CreateContactModule : Carter.CarterModule
    {
        /// <summary>
        /// The logger used to log information to the console.
        /// </summary>
        private readonly ILogger<CreateContactModule> _logger;
        /// <summary>
        /// The validator used to validate the request.
        /// </summary>
        private readonly IValidator<CreateContactRequest> _validator;
        /// <summary>
        /// The contact service used to interact with the database.
        /// </summary>
        private readonly IContactService _contactService;
        /// <summary>
        /// Creates a new instance of the <see cref="CreateContactModule"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="validator"></param>
        /// <param name="contactService"></param>
        public CreateContactModule(
            ILogger<CreateContactModule> logger, 
            IValidator<CreateContactRequest> validator, 
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
        public override void AddRoutes(IEndpointRouteBuilder app) => app.MapPost("/api/contacts", CreateContactAsync);
        /// <summary>
        /// Creates a new contact in the database.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private async ValueTask<IResult> CreateContactAsync(HttpContext req, CreateContactRequest request)
        {
            _logger.LogInformation("Creating contact {@Request}", request);
            var result = _validator.Validate(request);
            if (!result.IsValid)
            {
                _logger.LogWarning("Validation failed for request {@Request}", request);
                return Results.BadRequest(new ErrorResponse
                {
                    Message = "Validation failed",
                    ValidationErrors = result.Errors.Select(e => MapValidationError(e)).ToList()
                });
            }
            var contact = request.ToContact();
            contact.CreatedAt = DateTime.UtcNow; 
            var newContact = await _contactService.CreateContactAsync(contact);
            _logger.LogInformation("Created contact {@Contact}", newContact);
            return newContact is null ? Results.NotFound() : Results.Ok(newContact.ToContactResponse());
        }
        /// <summary>
        /// Maps a validation error to a response error.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private ErrorResponse.ValidationError MapValidationError(ValidationFailure e)
        {
            return new ErrorResponse.ValidationError
            {
                PropertyName = e.PropertyName,
                ErrorMessage = e.ErrorMessage
            };
        }
    }
}