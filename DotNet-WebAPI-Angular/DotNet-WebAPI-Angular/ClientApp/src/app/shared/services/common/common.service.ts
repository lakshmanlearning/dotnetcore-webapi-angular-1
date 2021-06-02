import { Injectable, Inject } from "@angular/core";
import { BaseService } from "../base/base.service";
import { Observable } from "rxjs";

@Injectable()
export class CommonService {
    constructor(private baseHttp: BaseService) {

    }

    GetAppSettings() : Observable<any> {
        return this.baseHttp.get('MyValues/GetAppSettings').map(result => <any>result);
    }
}