using TransferService.Domain.Entities;

namespace TransferService.Domain.Interfaces
{
    public interface ITransferRepository
    {
        public void Create(Transfer transferEntity);
    }
}
