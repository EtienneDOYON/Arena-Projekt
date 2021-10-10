import { HttpClient, HttpErrorResponse, HttpHeaders, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';
import { TokenFactory } from './token.factory'

@Injectable({
    providedIn: 'root'
})

export class ClassFactory {

  constructor(private http: HttpClient, private toastr: ToastrService, private translate: TranslateService, private tokenFactory: TokenFactory) {
  }

  ngOnInit(): void {
  }

  async GetAllClasses()
  {
    let url = environment.baseCoreUrl + 'class';

    const ret: any = await this.tokenFactory.get(url);
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }

  async GetClass(classId: number)
  {
    let url = environment.baseCoreUrl + 'class/' + classId;

    const ret: any = await this.tokenFactory.get(url);
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }

  async EditClass(_class: any)
  {
    let url = environment.baseCoreUrl + 'class';

    const ret: any = await this.tokenFactory.put(url, {classViewModel: _class});
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }

  async CreateClass(_class: any)
  {
    let url = environment.baseCoreUrl + 'class';

    const ret: any = await this.tokenFactory.post(url, {classViewModel: _class});
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }

  async DeleteClass(classId: number)
  {
    let url = environment.baseCoreUrl + 'class/' + classId;

    const ret: any = await this.tokenFactory.delete(url);
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }
}
