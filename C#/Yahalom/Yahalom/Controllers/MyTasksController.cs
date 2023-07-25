using BL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yahalom.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MyTasksController : Controller
    {
        private IMyTasksBL _MyTasksBL;
        // קונסטרקטור שבזמן שמייצרים 
        //CustomerController
        // אז הוא יהיה חייב לקבל טיפוס מסוג הממשק של 
        //ICustomerBL
        //והוא יזריק תלות אליו
        public MyTasksController(IMyTasksBL MyTasksBL)
        {
            _MyTasksBL = MyTasksBL;
        }

        // פונקציה מספר 18 
        //הצגת המשימות ללקוח
        [HttpGet]
        public BaseResult<List<MyTasksDTO>> getTasksCustomer(int idCustomer)
        {
            return _MyTasksBL.getTasksCustomer(idCustomer);
        }

        // פונקציה מספר 19 
        // הוספת משימה חדשה ללקוח
        [HttpPost]
        public BaseResult<int> CreateTask(MyTasksDTO newTask)
        {

            return _MyTasksBL.CreateTask(newTask);
        }

        //פונקציה מספר 20
        // עדכון משימה
        [HttpPost]
        public BaseResult<int> EditTask(MyTasksDTO task)
        {

            return _MyTasksBL.EditTask(task);
        }
        //פונקציה מספר 21
        // מחיקת משימה
        [HttpDelete]
        public BaseResult<int> DeleteTask(MyTasksDTO task)
        {
            return _MyTasksBL.DeleteTask(task);
        }
  
    }
}
