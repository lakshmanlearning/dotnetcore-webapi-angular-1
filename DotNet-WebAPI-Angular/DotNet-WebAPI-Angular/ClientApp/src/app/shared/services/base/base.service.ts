import 'rxjs/add/observable/empty';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { catchError, retry, tap } from 'rxjs/operators';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';

@Injectable()
export class BaseService {
    constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') private baseUrl: string) {

    }

    get(_url: string, options?: any) : Observable<any> {
        let headers: HttpHeaders;
        headers = new HttpHeaders({
            'Cache-Control': 'no-cache',
            'Pragma': 'no-cache',
            'Expires': 'Sat, 01 Jan 2000 00:00:00 GMT'
        });
        if(options != null) {
            options.headers = headers;
        } else {
            options = { headers: headers };
        }
        

        return this.http.get<any>(this.baseUrl + _url, options)
        .pipe(
            retry(3),
            tap(data => console.log("Success")),
            catchError( error => new ErrorObservable(error.error))
        );
    }

    post(_url: string, body: any, options?: any): Observable<any> {
        let headers: HttpHeaders = new HttpHeaders({
            'Cache-Control': 'no-cache',
            'Pragma': 'no-cache',
            'Expires': 'Sat, 01 Jan 2000 00:00:00 GMT'
        });
        if(options != null) {
            options.headers = headers;
        } else {
            options = { headers: headers };
        }

        return this.http.post(_url, body, options)
        .pipe(
            retry(3),
            tap(data => console.log(data)),
            catchError(error => new ErrorObservable(error.error))
        );
    }

}
