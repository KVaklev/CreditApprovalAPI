using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Services.Utilities;
using MediatR;
using System;

namespace CreditApprovalAPI.Services.Queries
{
    public class CreditRequestGetByIdQuery : IRequest<Result<CreditRequestReadDto>>
    {
        public Guid Id { get; set; }

        public CreditRequestGetByIdQuery(Guid id) => Id = id;
        
    }
}
