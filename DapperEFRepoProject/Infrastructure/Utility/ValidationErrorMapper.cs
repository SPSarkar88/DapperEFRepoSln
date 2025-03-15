using DapperEFRepoProject.Modules.Common.Response;
using FluentValidation.Results;
using static DapperEFRepoProject.Modules.Common.Response.ErrorResponse;

namespace DapperEFRepoProject.Infrastructure.Utility
{
    /// <summary>
    /// Represents a validation error mapper.
    /// </summary>
    public static class ValidationErrorMapper
    {
        /// <summary>
        /// Maps a validation error to a response error.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static ValidationError MapValidationError(ValidationFailure e)
        {
            return new ValidationError
            {
                PropertyName = e.PropertyName,
                ErrorMessage = e.ErrorMessage
            };
        }
    }
}
