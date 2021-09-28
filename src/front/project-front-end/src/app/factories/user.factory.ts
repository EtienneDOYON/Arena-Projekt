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
    let url = environment.baseCoreUrl + '/connectUser?username=' + username + '&password=' + password;

    const ret: String = await this.http.get(url, {responseType: 'text'}).toPromise();
    
    return ret;
  }
}
