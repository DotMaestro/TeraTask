namespace Tera.TransferService.Messages
{
    public record UpdateAccountBalance
    {
        public Guid CommandId { get; init; }
        public Guid AccountNumber { get; init; }
        public decimal Amount { get; init; }

        public UpdateAccountBalance()
        {

        }

        public UpdateAccountBalance(Guid accountNumber, decimal amount)
        {
            AccountNumber = accountNumber;
            Amount = amount;
        }
    }
}
