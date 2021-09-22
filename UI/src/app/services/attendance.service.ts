import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Attendance } from '../interfaces/attendance';
import { Constants } from '../preferences/constants';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {
  constructor(private http: HttpClient) { }
  

  getAttendance(): Observable<Attendance[]> {
    debugger;
    return this.http
      .get<Attendance[]>(
        `${Constants.baseUrl}attendance/getattendance`
      )
      .pipe();
  }

  getAttendanceForProduct(productCode: string): Observable<Attendance[]> {
    debugger;
    return this.http
      .get<Attendance[]>(
        `${Constants.baseUrl}attendance/getattendance/${productCode}`
      )
      .pipe();
  }

  getAttendanceForGame(seasonId: number, gameNumber: number): Observable<Attendance[]> {
    debugger;
    return this.http
      .get<Attendance[]>(
        `${Constants.baseUrl}attendance/getattendance/${seasonId}/${gameNumber}`
      )
      .pipe();
  }
}
