import {  Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Attendance } from '../interfaces/attendance';
import { AttendanceService } from '../services/attendance.service';
import { NotificationService } from '../services/notification.service';

@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.scss']
})
export class AttendanceComponent implements OnInit {
  

  attendance: Attendance[]=[];
  total: number = 0;

  SearchForm = this.fb.group({
    code: "",
  });

  SearchGameForm = this.fb.group({
    seasonId: "",
    gameNumber:""
  });

  constructor(private fb: FormBuilder,
    private service: AttendanceService,
    private notifyService : NotificationService) { }

  ngOnInit(): void {
   this.GetAttendance();
  }


  GetAttendance(){
    this.service.getAttendance().subscribe((data) => {
      this.ProcessData(data);
      
    });
  }

  GetAttendanceForProduct(productCode: string){
    this.service.getAttendanceForProduct(productCode).subscribe((data) => {
      this.ProcessData(data);
    });
  }

  GetAttendanceForGame(seasonId: number, gameNumber: number){
    this.service.getAttendanceForGame(seasonId,gameNumber).subscribe((data) => {
     this.ProcessData(data);
    });
  }

  ProcessData(data: Attendance[]){
    if(data && data.length > 0){
      this.attendance = data;
      this.total = this.attendance.length;
    }else{
      this.NotFound();
    }
  }

  Search(){
    var form = this.SearchForm.value;
    var productCode = form.code;
    if(productCode){
      this.GetAttendanceForProduct(productCode);
    }else{
      this.Invalid();
    }
    
  }

  SearchGame(){
    debugger;
    var form = this.SearchGameForm.value;
    var seasonId = +form.seasonId;
    var gameNumber = +form.gameNumber;
    if(seasonId && gameNumber){
      this.GetAttendanceForGame(seasonId,gameNumber);
    }else{
      this.Invalid();
    }
    
  }

  clearAll(){
    this.SearchForm.reset();
    this.SearchGameForm.reset();
    this.GetAttendance();
  }

  NotFound(){
    this.notifyService.showError("","Data Not Found");
  }

  Invalid(){
    this.notifyService.showError("","Invalid data");
  }

}
