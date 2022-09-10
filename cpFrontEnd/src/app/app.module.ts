import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import {  MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { CpTestPageComponent } from './cp-test-page/cp-test-page.component';
import { MatDividerModule } from '@angular/material/divider'
import { HttpClientModule } from '@angular/common/http';
import { MatDialogModule } from '@angular/material/dialog';
import { CpTestDialogComponent } from './cp-test-page/cp-test-dialog/cp-test-dialog.component';
@NgModule({
  declarations: [
    AppComponent,
    CpTestPageComponent,
    CpTestDialogComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatTableModule,
    MatCheckboxModule,
    MatDividerModule,
    HttpClientModule,
    MatDialogModule
  ],
  entryComponents:[
    CpTestPageComponent,
    CpTestDialogComponent
  ],
  exports:[
    CpTestPageComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
