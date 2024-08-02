namespace TransferService.Domain.Entities
{
    public class Transfer
    {
        public int TransferId { get; set; }
        public Guid AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }

        public Transfer()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
