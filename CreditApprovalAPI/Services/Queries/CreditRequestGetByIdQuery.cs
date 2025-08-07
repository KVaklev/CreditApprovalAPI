using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;
using System;

namespace CreditApprovalAPI.Services.Queries
{
    /// <summary>
    /// Query to retrieve a credit request by its unique identifier.
    /// </summary>
    public class CreditRequestGetByIdQuery : IRequest<Result<CreditRequestReadDto>>
    {
        /// <summary>
        /// Gets the unique identifier of the credit request to retrieve.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditRequestGetByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The ID of the credit request.</param>
        public CreditRequestGetByIdQuery(Guid id) => Id = id;
    }
}
