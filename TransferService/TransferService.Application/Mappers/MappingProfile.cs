using AutoMapper;

using TransferService.Application.Dtos;
using TransferService.Domain.Entities;

namespace TransferService.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTransferDto, Transfer>();
        }
    }
}
