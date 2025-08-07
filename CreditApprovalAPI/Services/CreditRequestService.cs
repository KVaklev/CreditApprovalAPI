using AutoMapper;
using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Enums;
using CreditApprovalAPI.Models;
using CreditApprovalAPI.Repository;
using CreditApprovalAPI.Services.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CreditApprovalAPI.Services
{
    public class CreditRequestService : ICreditRequestService
    {
        private readonly ICreditRequestRepository _repository;
        private readonly IMapper _mapper;

        public CreditRequestService(ICreditRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<CreditRequestReadDto>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);
            var dtos = _mapper.Map<IEnumerable<CreditRequestReadDto>>(entities);
            return Result<IEnumerable<CreditRequestReadDto>>.Ok(dtos);
        }

        public async Task<Result<CreditRequestReadDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
                return Result<CreditRequestReadDto>.Fail($"Credit request with ID {id} not found.");

            return Result<CreditRequestReadDto>.Ok(_mapper.Map<CreditRequestReadDto>(entity));
        }

        public async Task<Result<CreditRequestReadDto>> CreateAsync(CreditRequestCreateDto dto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreditRequest>(dto);

            entity.Status = CreditStatus.Pending_Review;
            
            entity.CreatedDate = DateTime.UtcNow;

            entity.RequestNumber = await RequestNumberGenerator.GenerateRequestNumberAsync(_repository, cancellationToken);

            await _repository.AddAsync(entity, cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);

            return Result<CreditRequestReadDto>.Ok(_mapper.Map<CreditRequestReadDto>(entity));
        }


        public async Task<Result<CreditRequestReadDto>> ReviewAsync(CreditRequestReviewDto dto, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(dto.Id, cancellationToken);

            if (entity == null)
                return Result<CreditRequestReadDto>.Fail($"Credit request with ID {dto.Id} not found.");

            entity.Status = dto.IsApproved ? CreditStatus.Approved : CreditStatus.Rejected;

            entity.ReviewerName = dto.ReviewerName;

            entity.ReviewDate = DateTime.UtcNow;

            await _repository.SaveChangesAsync(cancellationToken);

            return Result<CreditRequestReadDto>.Ok(_mapper.Map<CreditRequestReadDto>(entity));
        }       
    }
}
