import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";

@Component({
    selector: 'cp-test-dialog',
    templateUrl: 'cp-test-dialog.component.html',
    styleUrls  : ['./cp-test-dialog.component.scss']
  })
  export class CpTestDialogComponent {
    constructor(
      public dialogRef: MatDialogRef<CpTestDialogComponent>,
      @Inject(MAT_DIALOG_DATA) public data: any,
    ) 
    {
        this.userIndex = data.userIndex;
        this.isEdit = data.isEdit;
    }
  
    userIndex:number;
    isEdit:boolean = false;

    close(): void {
      this.dialogRef.close();
    }
  }