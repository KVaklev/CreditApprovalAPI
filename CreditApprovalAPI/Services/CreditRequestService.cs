using AutoMapper;
using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Enums;
using CreditApprovalAPI.Models;
using CreditApprovalAPI.Repository;
using CreditApprovalAPI.Services.Utilities;

namespace CreditApprovalAPI.Services
{
    /// <summary>
    /// Service responsible for handling credit request business logic, 
    /// including creation, retrieval, and review operations.
    /// </summary>
    public class CreditRequestService : ICreditRequestService
    {
        private readonly ICreditRequestRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditRequestService"/> class.
        /// </summary>
        /// <param name="repository">The repository interface used for data persistence.</param>
        /// <param name="mapper">The AutoMapper instance for DTO-entity transformations.</param>
        public CreditRequestService(ICreditRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all credit requests from the data source.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A result containing a collection of credit request DTOs.</returns>
        public async Task<Result<IEnumerable<CreditRequestReadDto>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);
            var dtos = _mapper.Map<IEnumerable<CreditRequestReadDto>>(entities);
            return Result<IEnumerable<CreditRequestReadDto>>.Ok(dtos);
        }

        /// <summary>
        /// Retrieves a single credit request by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the credit request to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A result containing the credit request DTO, or a failure message if not found.</returns>
        public async Task<Result<CreditRequestReadDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
                return Result<CreditRequestReadDto>.Fail($"Credit request with ID {id} not found.");

            return Result<CreditRequestReadDto>.Ok(_mapper.Map<CreditRequestReadDto>(entity));
        }

        /// <summary>
        /// Creates a new credit request based on provided data.
        /// </summary>
        /// <param name="dto">The DTO containing data to create the credit request.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A result containing the created credit request DTO.</returns>
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

        /// <summary>
        /// Reviews an existing credit request, updating its approval status and reviewer metadata.
        /// </summary>
        /// <param name="dto">The DTO containing the review decision and reviewer details.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A result containing the updated credit request DTO, or a failure message if the request is not found.</returns>
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
