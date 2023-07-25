import { Component, OnInit } from '@angular/core';
import { InvitationService } from '../../_services/invitation.service';
import { TasksServiceService } from '../../_services/tasks-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-view-tasks',
  templateUrl: './view-tasks.component.html',
  styleUrls: ['./view-tasks.component.css']
})
export class ViewTasksComponent implements OnInit {
  myTasksId = 1;
  userId!: number;
  showForm: boolean = false
  isEdit: boolean = false
idTask:number =0
  isSupplier: boolean = false
  arrTasks: any[] = []
  task = {
    "myTasksId": 0,
    "statusId": 0,
    "remarks": "",
    "supplierId": 0,
    "idCustomer": 0,
    "isToWeddingDay": true,
    "categoryForTask": "",
    "missionDescription": ""
  }

  constructor(private taskService: TasksServiceService) { }

  ngOnInit() {
    const valueFromLocalStorage = localStorage.getItem('id_task');

    const convertedValue = Number(valueFromLocalStorage);
    this.idTask=Number(valueFromLocalStorage);
   console.log(this.idTask,"ddddddddddddddddddddddddddddd");
   if(this.idTask==0){
    localStorage.setItem('id_task','10')
    this.idTask=Number(localStorage.getItem('id_task'));
   }
   
    this.userId = Number(localStorage.getItem('id_user'));
    if (localStorage.getItem('supplier') == "true") {
      this.isSupplier = true
    }
    else {
      this.fetchTasks()
    }
  }

  fetchTasks() {
    this.taskService.getTasksCustomer(this.userId).subscribe(
      data => {
        console.log(data)
        this.arrTasks = data.data

      }
    )
  }

  deleteTask(task: any) {
    console.log(task)
    this.taskService.deleteTask(task).subscribe(
      data => {
        if (!data.isError) {
          console.log(data, 'task deleted')
          const index = this.arrTasks.indexOf(task);
          if (index > -1) {
            this.arrTasks.splice(index, 1);
            this.ngOnInit()
          }
        }
      }
    )
  }

  openEdit(taskToEdit: any) {
    this.task = taskToEdit
    this.showForm = true
    this.isEdit = true
  }
  openAddForm(){
    this.showForm=!this.showForm
    this.isEdit=false;
    this.task = {
      "myTasksId": 0,
      "statusId": 0,
      "remarks": "",
      "supplierId": 0,
      "idCustomer": 0,
      "isToWeddingDay": true,
      "categoryForTask": "",
      "missionDescription": ""
    }
  }

  editTask() {
console.log(this.task.myTasksId)
    this.taskService.editTask(this.task).subscribe(
      data => {
        if (!data.isError) {
          console.log(data, 'vmkhj,h');
          console.log(data.data);
          

        }
      }
    )
  }

  createTask() {
    this.showForm = !this.showForm
    this.task.idCustomer = this.userId;
    this.idTask++;
    // localStorage.getItem('id_task')
    // localStorage.setItem('id_task',this.idTask)
    localStorage.setItem('id_task', this.idTask.toString());
    console.log(this.idTask)
 this.task.myTasksId = this.idTask
    this.task.supplierId = 1
    console.log(this.task)
    this.taskService.createTask(this.task).subscribe(
      data => {
        if (!data.isError) {
          console.log(data, 'vmkhj,h');

          this.arrTasks.push(data.data)
          console.log(data.data);
          this.ngOnInit()
        }
      }
    )
  }
}

