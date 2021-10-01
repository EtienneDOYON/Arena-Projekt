import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})

export class TokenFactory {

  constructor(private http: HttpClient, private toastr: ToastrService, private translate: TranslateService, private route: Router) {
  }

  ngOnInit(): void {
  }


  async post(url: string, body: any) {

    var auth_token = localStorage.getItem("UserToken");

    if (!auth_token) {
        this.route.navigate(['/notAllowed']);
        return {
            'error': 'NotAllowed'
        };
    }

    const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${auth_token}`    
    })
    
    try {
      const ret: any = JSON.parse(await this.http.post(url, body, {responseType: 'text', headers: headers}).toPromise());
      return ret;
    } catch (err: any) {
      return err;
    }
  }

  async postWithoutToken(url: string, body: any) {
    
    try {
      const ret: any = JSON.parse(await this.http.post(url, body, {responseType: 'text'}).toPromise());
      return ret;
    } catch (err: any) {
      return err;
    }
  }

  async get(url: string) {

    var auth_token = localStorage.getItem("UserToken");

    if (!auth_token) {
        this.route.navigate(['/notAllowed']);
        return {
            'error': 'NotAllowed'
        };
    }

    const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${auth_token}`    
    })
    
    try {
      const ret: any = JSON.parse(await this.http.get(url, {responseType: 'text', headers: headers}).toPromise());
      return ret;
    } catch (err: any) {
      return err;
    }
  }

  async getWithoutToken(url: string) {
    
    try {
      const ret: any = JSON.parse(await this.http.get(url, {responseType: 'text'}).toPromise());
      return ret;
    } catch (err: any) {
      return err;
    }
  }
}
