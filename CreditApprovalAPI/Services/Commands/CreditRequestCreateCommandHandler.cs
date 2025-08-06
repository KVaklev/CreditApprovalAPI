using AutoMapper;
using CreditApprovalAPI.Data;
using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

            // Generate unique RequestNumber e.g., CRE-20250806-0001
            var datePart = DateTime.UtcNow.ToString("yyyyMMdd");
            var count = await _context.CreditRequests.CountAsync(r => r.CreatedDate.Date == DateTime.UtcNow.Date, cancellationToken);
            var requestNumber = $"CRE-{datePart}-{(count + 1).ToString("D4")}";
            entity.RequestNumber = requestNumber;

            _context.CreditRequests.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);


            return _mapper.Map<CreditRequestReadDto>(entity);
        }
    }
}
