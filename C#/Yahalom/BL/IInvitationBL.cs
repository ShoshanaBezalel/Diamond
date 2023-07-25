using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public interface IInvitationBL
    {// פונקציות מספר 5 6 7
        //ListBaseResult<InvitationDTO> getInvitationSupplier(int IdSupplier, SupplierInventationStatus? inventationStatus);
        BaseResult<List<InvitationDTO>> getInvitationSupplier(int IdSupplier, SupplierInventationStatus? inventationStatus);
        // פונקציה מספר 9 עדכון האם שולם
        BaseResult<bool?> UpdateIsPaid(int idInvitation);
        // פונקציה מספר 10 הצגת הפרטים של ההזמנה, עבור הספק
        BaseResult<InvitationDTO> getInvitationDetails(int idInvitation);
        //פונקציה מספר 11 הצגת הפרטים של הלקוח שביצע את ההזמנה, עבור הספק
        BaseResult<CustomerDTO> getCustomerDetails(int idInvitation);

        // פונקציה מספר 22
        //הצגת ההזמנות ללקוח
        //BaseResult<InvitationDTO>getInvitationCustomer(int idCustomer);
        BaseResult<List<InvitationDTO>> getInvitationCustomer(int idCustomer);

        // פונקציה מספר 23
        // הוספת הזמנה חדשה ללקוח
        BaseResult<int> CreateInvitationCustomer(DateTime? DateOfInvitation, int? FinalPrice, string Location,
            int? StatusId, DateTime? From, DateTime? To, int? IdCustomer, int? IdSuplier);
        //פונקציה מספר 24
        //צור קשר- להצגת פרטי הספק ללקוח
        BaseResult<string> ContactUs(int idInvitation);
    }
}
