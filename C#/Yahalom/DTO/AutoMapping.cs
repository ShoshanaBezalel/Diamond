using AutoMapper;
using DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Customer, CustomerDTO>();
           
            CreateMap<Invitation, InvitationDTO>();
            CreateMap<InvitationDTO, Invitation>();
          
            CreateMap<MyTask, MyTasksDTO>();
            CreateMap<MyTasksDTO, MyTask>();
            CreateMap<PlaceId, PlaceIdDTO>();
            CreateMap<Status, StatusDTO>();
            CreateMap<Supplier, SupplierDTO>();
            //CreateMap<SupplierDTO, Supplier>()
            //    .ForMember(x => x.IdCategoryNavigation, opt => opt.Ignore())
            //     .ForMember(x => x.IdPlaceNavigation, opt => opt.Ignore())
            //    .ForMember(x => x.Invitations, opt => opt.Ignore());
            //SupplierBasicDTO
            CreateMap<Supplier, SupplierBasicDTO>();
            CreateMap<SecondCtegory, SecondCtegoryDTO>();
            CreateMap<SupplierBasicDTO, Supplier>()
                .ForMember(x => x.IdCategoryNavigation, opt => opt.Ignore())
                .ForMember(x => x.IdPlaceNavigation, opt => opt.Ignore())
                .ForMember(x => x.Invitations, opt => opt.Ignore());
            //CreateMap<CustomerBasicDTO, Customer>()
            //    .ForMember(x => x.Invitations,opt=>opt.Ignore())
            //    .ForMember(x => x.MyTasks, opt => opt.Ignore());
            //Invitations,MyTasks
            //CreateMap<Supplier, SupplierDTO>().ForMember(x => x.Invitations, opt => opt.Ignore());

            CreateMap<SupplierCategory, SupplierCategoryDTO>();
           // CreateMap<User, UserDTO>();

        }
    }
}
