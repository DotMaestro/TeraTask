namespace TransferService.Application.Dtos
{
    public record CreateTransferDto(int TransferId, Guid AccountNumber, decimal Amount);
}
