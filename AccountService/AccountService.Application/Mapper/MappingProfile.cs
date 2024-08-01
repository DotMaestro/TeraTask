using AccountService.Application.Dtos;
using AccountService.Domain.Entities;

using AutoMapper;

namespace AccountService.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDetailsDto>();
            CreateMap<Account, AccountBalanceDto>();
        }
    }
}
