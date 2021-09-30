import { HttpClient, HttpErrorResponse, HttpHeaders, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
    providedIn: 'root'
})

export class UserFactory {

  constructor(private http: HttpClient, private toastr: ToastrService, private translate: TranslateService) {
  }

  ngOnInit(): void {
  }


  async connectUser(username: string, password: string) {
    let url = environment.baseCoreUrl + '/Login';

    var body = {
      Username: username,
      Password: password
    };

    try {
      const ret: any = JSON.parse(await this.http.post(url, body, {responseType: 'text'}).toPromise());
      return ret;
    } catch (err: any) {
      this.toastr.warning(this.translate.instant("Home." + err.error), "");
    }
  }
}
