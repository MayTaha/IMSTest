import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  ProductDto,
  ProductServiceProxy,
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'create-or-edit-product-dialog',
  templateUrl: 'create-or-edit-product-dialog.component.html'
})
export class CreateOrEditProductDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  product: ProductDto = new ProductDto();
  
   isViewMode: boolean=false;
  private _id: number;
  get id(): number{
    return this._id;
  }
  set id(value: number){
    this._id = value;
      if (this.id){
        this._productService.get(this.id).subscribe((result: ProductDto) => {
          this.product = result;
        });
      }
  }

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productService: ProductServiceProxy,
    public bsModalRef: BsModalRef
  ) { super(injector);}
  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    this._productService
      .createOrEdit(this.product)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
