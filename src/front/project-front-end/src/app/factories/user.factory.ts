import { HttpClient, HttpErrorResponse, HttpHeaders, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';
import { TokenFactory } from './token.factory'

@Injectable({
    providedIn: 'root'
})

export class UserFactory {

  constructor(private http: HttpClient, private toastr: ToastrService, private translate: TranslateService, private tokenFactory: TokenFactory) {
  }

  ngOnInit(): void {
  }


  async connectUser(username: string, password: string) {
    let url = environment.baseCoreUrl + 'user/Login';

    var body = {
      Username: username,
      Password: password
    };

    const ret: any = await this.tokenFactory.postWithoutToken(url, body);
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }

}
