import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { ApiService } from "../api.service";
import { CustomerViewModel } from "./customerViewModel.interface";

@Injectable({
    providedIn: 'root'
})

export class CpService
{
    constructor(private api: ApiService) { }

    GetCustomerList():Observable<any> {
        return this.api.get(`api/CustomerInfo/GetCustomerList`);
    }

    CreateOrUpdateCustomer(model: CustomerViewModel): Observable<any> {
        const data = {
            'customerId' : model.customerId,
            'consultantInfoId': model.consultantInfoId,
            'customerBuy': model.customerBuy,
            'customerSell':model.customerSell,
            'consultantBuy': model.consultantBuy,
            'consultantSell': model.consultantSell
        }
        return this.api.put(`api/CustomerInfo/CreateOrUpdateCustomer`, data);
    }
}