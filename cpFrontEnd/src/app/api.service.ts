import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient, HttpParams } from "@angular/common/http"
import { environment as config} from "src/environments/environment";
@Injectable({
    providedIn: 'root'
  })
  export class ApiService {
  
    constructor(private http: HttpClient) { }
  
    get(url: string, params = new HttpParams()): Observable<any> {
      return this.getHost(config.api.host, url, params);
    }
  
    getHost(host: string, url: string, params = new HttpParams()): Observable<any> {
        const headers = { 'Content-Type': 'application/json' };
      return this.http.get(`${host}${url}`, { observe: 'body', params, headers:headers });
    }
  
    getUrl(url: string): Observable<any> {
        
      return this.http.get(`${url}`, { observe: 'body' });
    }
  
    post(url: string, body: any): Observable<any> {
      const headers = { 'Content-Type': 'application/json' };
      return this.http.post(`${config.api.host}${url}`, body, { headers });
    }

    
  put(url: string, body: any, options?: any): Observable<any> {
    if (!options) {
      return this.http.put(`${config.api.host}${url}`, body);
    }
    return this.http.put(`${config.api.host}${url}`, body, options);
  }
}
  