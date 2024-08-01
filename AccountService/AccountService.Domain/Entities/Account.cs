namespace AccountService.Domain.Entities
{
    public class Account
    {
        public Guid AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public string AccountHolder { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public Account()
        {
            
        }

        public Account(Guid accountNumber, string accountHolderName)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolderName;
            CreatedDate = DateTime.UtcNow;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds for this withdrawal.");
            }

            Balance -= amount;
        }
    }
}
