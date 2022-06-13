using AutoMapper;
using Shops.Application.Dtos;
using Shops.Application.Features.Commands.CurrentAccounts.CreateCurrAcc;
using Shops.Application.Features.Commands.Invoices.CreateInvoice;
using Shops.Domain.Entities;

namespace Shops.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CurrentAccount Mapping
            CreateMap<CurrentAccount, CreateCurrAccRequest>(MemberList.None).ReverseMap();
            CreateMap<CurrentAccount, CurrentAccountDto>(MemberList.None)
                    .ForMember(dest => dest.CurrAccDesc, opt => opt.MapFrom(src => src.CurrentAccountType.CurrentAccountTypeDesc));

            // CurrentAccountType Mapping
            CreateMap<CurrentAccountType, CurrentAccountTypeDto>();

            // Discount Mapping
            CreateMap<Discount, DiscountDto>();

            // Invoice Mapping
            CreateMap<Invoice, CreateInvoiceRequest>(MemberList.None).ReverseMap();
            CreateMap<Invoice, InvoiceListDto>(MemberList.None)
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.CurrentAccount.FirstName} {src.CurrentAccount.LastName}"));
            CreateMap<Invoice, InvoiceDto>(MemberList.None)
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.CurrentAccount.FirstName} {src.CurrentAccount.LastName}"));
        }
    }
}