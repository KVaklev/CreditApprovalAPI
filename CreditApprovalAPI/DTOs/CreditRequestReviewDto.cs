namespace CreditApprovalAPI.DTOs
{
    public class CreditRequestReviewDto
    {
        public Guid Id { get; set; }
        public string ReviewerName { get; set; }
        public bool IsApproved { get; set; }
    }
}
