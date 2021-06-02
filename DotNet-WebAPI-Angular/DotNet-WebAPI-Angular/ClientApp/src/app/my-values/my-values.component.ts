import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService } from '../shared/services/common/common.service';

@Component({
  selector: 'app-my-values',
  templateUrl: './my-values.component.html'
})
export class MyValuesComponent {
  public appSettings: IAppSettingsOptions;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private commonService: CommonService) {
    this.commonService.GetAppSettings().subscribe(result => {
        console.log(result);
        this.appSettings = result;
        console.log(this.appSettings);
    }, error => {
        console.error(error)
    });

  }
}

interface IAppSettingsOptions {
    myConnectionString: string;
    connectionString: string;
    environmentName: number;
    environmentSlotName: number;
}
