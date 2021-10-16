import { HttpClient, HttpErrorResponse, HttpHeaders, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';
import { TokenFactory } from './token.factory'

@Injectable({
    providedIn: 'root'
})

export class SubclassFactory {

  private subclassRoute = 'subclass';

  constructor(private http: HttpClient, private toastr: ToastrService, private translate: TranslateService, private tokenFactory: TokenFactory) {
  }

  ngOnInit(): void {
  }

  async GetAllSubclasses()
  {
    let url = environment.baseCoreUrl + `${this.subclassRoute}`;

    const ret: any = await this.tokenFactory.get(url);
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }

  async GetSubclass(subclassId: number)
  {
    let url = environment.baseCoreUrl + `${this.subclassRoute}/${subclassId}`;

    const ret: any = await this.tokenFactory.get(url);
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }

  async EditSubclass(_subclass: any)
  {
    let url = environment.baseCoreUrl + `${this.subclassRoute}`;

    const ret: any = await this.tokenFactory.put(url, _subclass);
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }

  async CreateSubclass(_subclass: any)
  {
    let url = environment.baseCoreUrl + `${this.subclassRoute}`;

    const ret: any = await this.tokenFactory.post(url, _subclass);
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }

  async DeleteSubclass(classId: number)
  {
    let url = environment.baseCoreUrl + `${this.subclassRoute}/${classId}`;

    const ret: any = await this.tokenFactory.delete(url);
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }

  async GetAllSubclassesOfClass(classId: number)
  {
    let url = environment.baseCoreUrl + `${this.subclassRoute}/GetAllSubclassesOfClass/${classId}`;

    const ret: any = await this.tokenFactory.get(url);
    if (ret.error) {
      this.toastr.warning(this.translate.instant("Error." + ret.error), "");
    } else {
      return ret;
    }
  }
}
