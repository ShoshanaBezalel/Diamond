using AutoMapper;
using DAL;
using DAL.DB;
//using DAL.Models;
using DTO;
using DTO.Responses;
using Lib.GoogleClendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class InvitationBL : IInvitationBL
    {
        private readonly YahalomContext _dbContext;
        private IMapper _mapper;

        public InvitationBL(YahalomContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //   פונקציות מספר 5 6 7 
        public BaseResult<List<InvitationDTO>> getInvitationSupplier(int IdSupplier, SupplierInventationStatus? paidStatus)
        {
            try
            {
                DateTime now = DateTime.Now;

                // פונקציה מספר 5
                // פונצקיה שמחזירה לספק את כל ההזמנות שלו מה 4 חודשים האחרונים
                var invitationsdb = _dbContext.Invitations.Where(x => x.IdSuplier == IdSupplier
                 && x.DateOfInvitation.Value <= now && x.DateOfInvitation.Value >= now.AddMonths(-4)).ToList();

                // 6
                //  פונקציה שמחזירה לספק את כל ההזמנות שעדיין לא שולמו במלואן
                if (paidStatus == SupplierInventationStatus.NotPaid)
                {
                    invitationsdb = _dbContext.Invitations.Where(x => x.IdSuplier == IdSupplier
                        && x.IsPaid == false).ToList();
                }
                //פונקציה מספר 7
                //פונקציה שמחזירה לספק את כל ההזמנות שעדיין לא בוצעו בפועל
                if (paidStatus == SupplierInventationStatus.FutureInventation)
                {
                    invitationsdb = _dbContext.Invitations.Where(x => x.IdSuplier == IdSupplier
                        && x.DateOfInvitation >= DateTime.Now).ToList();
                }
                List<InvitationDTO> invitations = Mapper.Map<List<InvitationDTO>>(invitationsdb);
                return new BaseResult<List<InvitationDTO>>()
                {

                    Data = invitations
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<List<InvitationDTO>>()
                {
                    IsError = true,
                  /*  ErrorCode = ex.HResult*/
                    ErrorMessage = ex.Message

                };
            }
        }

        // פונקציה מספר 9 עדכון שההזמנה שולמה במלואה
        public BaseResult<bool?> UpdateIsPaid(int idInvitation)
        {
            try
            {
                Invitation inv = _dbContext.Invitations.SingleOrDefault
                    (x => x.IdInvitation == idInvitation);
                inv.IsPaid = true;
                _dbContext.Update(inv);
                _dbContext.SaveChanges();

                return new BaseResult<bool?>()
                {
                    Data = inv.IsPaid
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<bool?>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message

                };
            }
        }
        // פונקציה מספר 10 הצגת הפרטים של ההזמנה עבור הספק
        public BaseResult<InvitationDTO> getInvitationDetails(int idInvitation)
        {
            try
            {

                var findInvitationdb = _dbContext.Invitations.Where(x => x.IdInvitation == idInvitation).FirstOrDefault();

                InvitationDTO findInvitation = _mapper.Map<InvitationDTO>(findInvitationdb);

                return new BaseResult<InvitationDTO>()
                {
                    Data = findInvitation
                };

            }
            catch (Exception ex)
            {
                return new BaseResult<InvitationDTO>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }
        //פונקציה מספר 11 הצגת הפרטים של הלקוח שביצע את ההזמנה, עבור הספק
        public BaseResult<CustomerDTO> getCustomerDetails(int idInvitation)
        {
            try
            {
                Invitation findInvitationdb = _dbContext.Invitations.SingleOrDefault(x => x.IdInvitation == idInvitation);
                Customer findCustomerDetails = _dbContext.Customers.SingleOrDefault(x => x.IdCustomer == findInvitationdb.IdCustomer);
                CustomerDTO findCustomer = _mapper.Map<CustomerDTO>(findCustomerDetails);

                return new BaseResult<CustomerDTO>()
                {
                    Data = findCustomer
                };

            }
            catch (Exception ex)
            {
                return new BaseResult<CustomerDTO>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }


        //פונקציה מספר 22
        //הצגת ההזמנות ללקוח
        //public BaseResult<InvitationDTO> getInvitationCustomer(int idCustomer)
        //{
        //    try
        //    {
        //        List<Invitation> getInvitationdb = _dbContext.Invitations.Where(x => x.IdCustomer == idCustomer).ToList();
        //        InvitationDTO getInvitations = _mapper.Map<InvitationDTO>(getInvitationdb);
        //        return new BaseResult<InvitationDTO>()
        //        {
        //            Data = getInvitations
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResult<InvitationDTO>()
        //        {
        //            IsError = true,
        //            ErrorCode = ErrorCode.Unexpected,
        //            ErrorMessage = ex.Message
        //        };
        //    }
        //}

        public BaseResult<List<InvitationDTO>> getInvitationCustomer(int idCustomer)
        {
            try
            {
                List<Invitation> getInvitationdb = _dbContext.Invitations.Where(x => x.IdCustomer == idCustomer).ToList();
                List<InvitationDTO> getInvitations = _mapper.Map<List<InvitationDTO>>(getInvitationdb);
                return new BaseResult<List<InvitationDTO>>()
                {
                    Data = getInvitations
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<List<InvitationDTO>>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }

        // פונקציה מספר 23
        // הוספת הזמנה חדשה ללקוח
        public BaseResult<int> CreateInvitationCustomer(DateTime? DateOfInvitation, int? FinalPrice, 
            string Location, int? StatusId, DateTime? From, DateTime? To, int? IdCustomer, int? IdSuplier)
        {
            try
            {
                Invitation CreateInvitationdb = new Invitation(DateOfInvitation, FinalPrice, Location, StatusId, From, To, IdCustomer, IdSuplier);
                var CreateInvitation = _dbContext.Invitations.Add(CreateInvitationdb).Entity;
                var supplierById = _dbContext.Suppliers.Where(s => s.IdSuplier ==IdSuplier).FirstOrDefault();
                var customer = _dbContext.Customers.Where(c => c.IdCustomer == IdCustomer).FirstOrDefault();
                
                if (supplierById != null)
                {
                    var emailSupplier = supplierById.Email;
                    ClendarEvent clendar = new ClendarEvent()
                    {
                        Start = (DateTime)CreateInvitation.From,
                        End = (DateTime)CreateInvitation.To,
                        Summary = customer.ToString(),
                        Description = customer.ToString(),
                        EmailTo = emailSupplier
                    };
                    Clendar.AddEvent(clendar);
                }

                //         public DateTime Start { get; set; }
                //public DateTime End { get; set; }
                //public string Summary { get; set; }
                //public string Description { get; set; }
                //public string EmailTo { get; set; }

                _dbContext.SaveChanges();
                return new BaseResult<int>()
                {
                    Data = CreateInvitation.IdInvitation
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<int>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }

        //פונקציה מספר 24
        //צור קשר- להצגת פרטי הספק ללקוח
        public BaseResult<string> ContactUs(int idInvitation)
        {
            try
            {
                Invitation invitationForCustomer = _dbContext.Invitations.SingleOrDefault(x => x.IdInvitation == idInvitation);
                int getIdSupplier =(int) invitationForCustomer.IdSuplier;
                Supplier getIdSupplierDeteilsdb = _dbContext.Suppliers.SingleOrDefault(x => x.IdSuplier == getIdSupplier);
                SupplierDTO supplier = _mapper.Map<SupplierDTO>(getIdSupplierDeteilsdb);
                return new BaseResult<string>()
                {
                    Data = supplier.FirstName +" "+ supplier.LastName + " " 
                    + supplier.Phone + " " + supplier.Email
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<string>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }

    }
    }



































































































































