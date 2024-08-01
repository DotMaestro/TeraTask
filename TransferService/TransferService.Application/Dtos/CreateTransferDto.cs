namespace TransferService.Application.Dtos
{
    public record CreateTransferDto(Guid AccountNumber, decimal Amount);
}
