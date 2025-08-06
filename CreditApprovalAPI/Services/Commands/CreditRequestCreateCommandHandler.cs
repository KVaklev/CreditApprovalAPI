using AutoMapper;
using CreditApprovalAPI.Data;
using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Models;
using CreditApprovalAPI.Services.Utilities;
using MediatR;

namespace CreditApprovalAPI.Services.Commands
{
    public class CreditRequestCreateCommandHandler : IRequestHandler<CreditRequestCreateCommand, CreditRequestReadDto>
    {
        private readonly CreditDbContext _context;
        private readonly IMapper _mapper;

        public CreditRequestCreateCommandHandler(CreditDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreditRequestReadDto> Handle(CreditRequestCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreditRequest>(request.CreditRequest);

            entity.RequestNumber = await RequestNumberGenerator.GenerateRequestNumberAsync(_context, cancellationToken);

            _context.CreditRequests.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CreditRequestReadDto>(entity);
        }
    }
}
