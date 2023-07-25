using AutoMapper;
using DAL.DB;
using DTO;
using DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class MyTasksBL:IMyTasksBL
    {
                //הזרקת תלויות בקונסטרקטור גם ל
        //DAL
        //וגם להמרה
        //(readonly = משתנה שאי אפשר לשנות את ערכו)
        private readonly YahalomContext _dbContext;
        private IMapper _mapper;

        public MyTasksBL(YahalomContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // פונקציה מספר 18
        // הצגת משימות ללקוח
        public BaseResult<List<MyTasksDTO>> getTasksCustomer(int idCustomer)
        {
            try
            {
             List<MyTask> getMyTaskdb = _dbContext.MyTasks.Where(x => x.IdCustomer == idCustomer).ToList();
               List<MyTasksDTO> getTasks = _mapper.Map<List<MyTasksDTO>>(getMyTaskdb);
                return new BaseResult<List<MyTasksDTO>>()
                {
                    Data = getTasks
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<List<MyTasksDTO>>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }

        // פונקציה מספר 19
        // הוספת משימה חדשה ללקוח
        public BaseResult<int> CreateTask(MyTasksDTO newTask)
        {
            try
            {
                MyTask MyTaskdb = _mapper.Map<MyTask>(newTask);
                var CreateTask = _dbContext.MyTasks.Add(MyTaskdb);
                _dbContext.SaveChanges();
                return new BaseResult<int>()
                {
                    Data = CreateTask.Entity.MyTasksId
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
        //פונקציה מספר 20
        // עדכון משימה ללקוח
        public BaseResult<int> EditTask(MyTasksDTO task)
        {
            try
            {
                MyTask updateTaskdb = _mapper.Map<MyTask>(task);
                var updateTask = _dbContext.MyTasks.SingleOrDefault(x => x.MyTasksId == updateTaskdb.MyTasksId);
                if (updateTask != null)
                {
                    if (updateTaskdb.MissionDescription != null) updateTask.MissionDescription = updateTaskdb.MissionDescription;
                    if (updateTaskdb.Remarks != null) updateTask.Remarks = updateTaskdb.Remarks;
                    if (updateTaskdb.StatusId!= null) updateTask.StatusId = updateTaskdb.StatusId;
                    if (updateTaskdb.IdCustomer != null) updateTask.IdCustomer = updateTaskdb.IdCustomer;
                    if (updateTaskdb.SupplierId != null) updateTask.SupplierId = updateTaskdb.SupplierId;
                    if (updateTaskdb.IsToWeddingDay != null) updateTask.IsToWeddingDay = updateTaskdb.IsToWeddingDay;
                    if (updateTaskdb.CategoryForTask != null) updateTask.CategoryForTask = updateTaskdb.CategoryForTask;
                    _dbContext.SaveChanges();
                return new BaseResult<int>()
                {
                    Data = updateTask.MyTasksId
                };
            }
            return null;
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
        

        // פונקציה מספר 21
        // מחיקת משימה ללקוח
       public BaseResult<int> DeleteTask(MyTasksDTO task)
        {
            try
            {
                MyTask deleteTaskdb = _mapper.Map<MyTask>(task);
                _dbContext.MyTasks.Remove(deleteTaskdb);
                _dbContext.SaveChanges();
                return new BaseResult<int>()
                {
                    Data =((int)ErrorCode.Success)
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

       


    }
}



