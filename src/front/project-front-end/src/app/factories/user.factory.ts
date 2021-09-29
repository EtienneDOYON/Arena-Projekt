import { HttpClient, HttpHeaders, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})

export class UserFactory {

  constructor(private http: HttpClient) {
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
    } catch (e) {
      console.log(e);
    }
  }
}
