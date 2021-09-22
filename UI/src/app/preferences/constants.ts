import { HttpHeaders } from "@angular/common/http";

export class Constants {
  public static baseUrl = 'https://localhost:44376/api/';
  public static httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };
 
}
