using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public interface IMyTasksBL
    {
        // פונקציה מספר 18
        //הצגת המשימות ללקוח
        BaseResult<List<MyTasksDTO>> getTasksCustomer(int idCustomer);
        // פונקציה מספר 19
        // הוספת משימה חדשה ללקוח
        BaseResult<int> CreateTask(MyTasksDTO newTask);
        //פונקציה מספר 20
        // עדכון משימה ללקוח
        BaseResult<int> EditTask(MyTasksDTO task);
        // פונקציה מספר 21
        // מחיקת משימה ללקוח
        BaseResult<int> DeleteTask(MyTasksDTO task);
       
    }
}
