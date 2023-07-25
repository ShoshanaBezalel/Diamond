using DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class DTOConvertor
    {
        public static CustomerDTO ConvertToDTO(Customer customer)
        {
            return new CustomerDTO()
            {
                Id = customer.IdCustomer,
                IsGroom = customer.IsGroom,
                DateOfWedding = customer.DateOfWedding,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = customer.Password,
                Phone = customer.Phone
            };
        }

        public static SupplierDTO ConvertToDTO(Supplier supplier)
        {
            return new SupplierDTO()
            {
                Id=supplier.IdSuplier,
                IdCategory = supplier.IdCategory,
                IdPlace = supplier.IdPlace,
                AboutMe = supplier.AboutMe,
                PriceFrom = supplier.PriceFrom,
                PriceUntill = supplier.PriceUntill,
                IdSuplier = supplier.IdSuplier,
                FirstName = supplier.FirstName,
                LastName = supplier.LastName,
                Email = supplier.Email,
                Password = supplier.Password,
                Phone = supplier.Phone
            };
        }

        //private static T CheckNull<T, G>(G dbObject)
        //{
        //    return dbObject is null ? null : dbObject;
        //}
    }
}
