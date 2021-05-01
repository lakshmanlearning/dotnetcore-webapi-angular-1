import { Injectable, Inject } from "@angular/core";
import { BaseService } from "../base/base.service";
import { Observable } from "rxjs";

@Injectable()
export class MembersService {
    constructor(private baseHttp: BaseService) {

    }

    GetAllMembers() : Observable<any> {
        return this.baseHttp.get('weatherforecast/GetAllMembers').map(result => <any>result);
    }
}