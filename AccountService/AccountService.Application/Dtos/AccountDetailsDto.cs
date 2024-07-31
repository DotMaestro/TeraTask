namespace AccountService.Application.Dtos
{
    public record AccountDetailsDto(Guid AccountNumber, string AccountHolder, DateTime CreatedDate);
    public record AccountBalanceDto(Guid AccountNumber, decimal Balance);
    public record UpdateBalanceDto(Guid AccountNumber, decimal Amount);
}