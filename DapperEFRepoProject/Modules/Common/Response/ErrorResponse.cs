namespace DapperEFRepoProject.Modules.Common.Response
{
    /// <summary>
    /// Represents the error response.
    /// </summary>
    public struct ErrorResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> struct.
        /// </summary>
        /// <param name="message"></param>
        public ErrorResponse(string message)
        {
            Message = message;
        }
        /// <summary>
        /// Gets or sets the message of the error.
        /// </summary>
        public string Message { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the validation errors.
        /// </summary>
        public List<ValidationError>? ValidationErrors { get; set; }

        public struct ValidationError
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ValidationError"/> struct.
            /// </summary>
            public ValidationError()
            {
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="ValidationError"/> struct.
            /// </summary>
            /// <param name="propertyName"></param>
            /// <param name="errorMessage"></param>
            public ValidationError(string propertyName, string errorMessage)
            {
                PropertyName = propertyName;
                ErrorMessage = errorMessage;
            }
            /// <summary>
            /// Gets or sets the name of the property.
            /// </summary>
            public string PropertyName { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the error message.
            /// </summary>
            public string ErrorMessage { get; set; } = string.Empty;
        }
    }
}