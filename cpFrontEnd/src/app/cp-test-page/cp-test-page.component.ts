import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CpTestDialogComponent } from './cp-test-dialog/cp-test-dialog.component';
import { CpService } from './cp.service';
import { CustomerViewModel } from "./customerViewModel.interface";

@Component({
  selector: 'app-cp-test-page',
  templateUrl: './cp-test-page.component.html',
  styleUrls: ['./cp-test-page.component.scss']
})
export class CpTestPageComponent implements OnInit {
  title = 'cp test';
  displayedColumns: string[] = ['position', 'customerBuy', 'customerSell', 'consultantBuy', 'consultantSell', 'updateButton' ];
  dataSource = [];
  customerBuyIsChecked:boolean = false;
  customerSellIsChecked:boolean= false;
  consultantBuyIsChecked: boolean= false;
  consultantSellIsChecked: boolean= false;

  constructor(private cpService: CpService,
              private _matDialog: MatDialog)
  {

  }
  
  ngOnInit(): void {
   this.GetCustomerList();
  }

  changeRules(event:any, element:any, type:string) {

    var dataIndex = 0;
    if(element != null)
    {
      dataIndex = this.dataSource.findIndex(x => x.customerId == element.customerId);
    }

    switch(type) {
      case 'customerBuy':
        this.dataSource[dataIndex].customerBuy = event.checked;
        break;
      case 'customerSell':
        this.dataSource[dataIndex].customerSell = event.checked;
        break;
      case 'consultantBuy':
        this.dataSource[dataIndex].consultantBuy = event.checked;
        break;
      case 'consultantSell':
        this.dataSource[dataIndex].consultantSell = event.checked;
        break;
      case 'customerBuyIsChecked':
        this.customerBuyIsChecked = event.checked;
        break;
      case 'customerSellIsChecked':
        this.customerSellIsChecked = event.checked;
        break;
      case 'consultantBuyIsChecked':
        this.consultantBuyIsChecked = event.checked;
        break;
      case 'consultantSellIsChecked':
        this.consultantSellIsChecked = event.checked;
        break;

    }
  }

  UpdateCustomer(customerId: number) {
    var record = this.dataSource.find(x => x.customerId == customerId);

    var model = <CustomerViewModel>{};
    model.customerId = record.customerId;
    model.consultantInfoId = record.consultantInfoId;
    model.customerBuy = record.customerBuy;
    model.customerSell = record.customerSell;
    model.consultantBuy = record.consultantBuy;
    model.consultantSell =record.consultantSell;

    this.cpService.CreateOrUpdateCustomer(model).toPromise().then((result) =>{
      if(result) {
        this.ShowConfirmationDialog(result.customerId, true);
      }
    });

  }

  CreateCustomer() {
    var model = <CustomerViewModel>{};
    model.customerId = null;
    model.consultantInfoId = null;
    model.customerBuy = this.customerBuyIsChecked;
    model.customerSell = this.customerSellIsChecked;
    model.consultantBuy = this.consultantBuyIsChecked;
    model.consultantSell = this.consultantSellIsChecked;

    
    this.cpService.CreateOrUpdateCustomer(model).toPromise().then((result) =>{
      if(result) {
        this.ShowConfirmationDialog(result.customerId, false);
      }
    });

  }

  GetCustomerList() {
    this.cpService.GetCustomerList().toPromise().then((result )=> {
      if(result) {
        this.dataSource = result;
      }
    })
  }

  ShowConfirmationDialog(customerId:number, isEdit:boolean) {
    const dialogRef = this._matDialog.open(CpTestDialogComponent, {
      width: '500px',
      data: {userIndex: customerId, isEdit:isEdit},
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      this.GetCustomerList();     
    });
  }

}
