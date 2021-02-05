import { Component, Injector, ViewChild } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto,
} from '@shared/paged-listing-component-base';
import {
    ProductServiceProxy,
    ProductDto,
    ProductDtoPagedResultDto,
} from '@shared/service-proxies/service-proxies';
import { CreateProductDialogComponent } from './create-product/create-product-dialog.component';
import * as moment from 'moment';
// import { EditTenantDialogComponent } from './edit-tenant/edit-tenant-dialog.component';

enum QuantityOperator {
  Equals = 1,
  GreaterThan = 2,
  LessThan = 3
}
class PagedProductsRequestDto extends PagedRequestDto {
    title: string;
    code: string;
    quantity?: number;
    quantityOperator: QuantityOperator;
    creationTime: moment.Moment;
}

@Component({
    templateUrl: './products.component.html',
    animations: [appModuleAnimation()]
})
export class ProductsComponent extends PagedListingComponentBase<ProductDto> {

  //@ViewChild('createOrEditProductDialog') createOrEditProductDialog: CreateProductDialogComponent;
    products: ProductDto[] = [];
    title='';
    code='';
    quantity;
    quantityOperator;
    creationTime: Date;
    advancedFiltersVisible = false;
    quantityOperators = QuantityOperator;

    constructor(
        injector: Injector,
        private _productService: ProductServiceProxy,
        private _modalService: BsModalService
    ) {
        super(injector);
    }

    list(
        request: PagedProductsRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {
      request.title = this.title;
      request.code = this.code;
      request.quantity = this.quantity == null ? this.emptyNumber : this.quantity;
      request.quantityOperator = this.quantityOperator;
      request.creationTime = this.creationTime ? moment(this.creationTime) : null;

        this._productService
            .getAll(
                request.title,
                request.code,
                request.quantity,
                request.quantityOperator as number,
                request.creationTime,
                request.skipCount,
                request.maxResultCount)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: ProductDtoPagedResultDto) => {
                this.products = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    delete(product: ProductDto): void {
        abp.message.confirm("Delete?",
            undefined,
            (result: boolean) => {
                if (result) {
                    this._productService
                        .delete(product.id)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('SuccessfullyDeleted'));
                                this.refresh();
                            })
                        )
                        .subscribe(() => { });
                }
            }
        );
    }

    create(): void {
      //this.createOrEditProductDialog.show();
      this.showCreateOrEditProductDialog();
    }

    edit(product: ProductDto): void {
      //this.createOrEditProductDialog.show(product.id);
      this.showCreateOrEditProductDialog(product.id);
    }

    showCreateOrEditProductDialog(id?: number): void {
      let createOrEditDialog: BsModalRef;
      createOrEditDialog = this._modalService.show(
        CreateProductDialogComponent,
        {
          class: 'modal-lg',
        }
      );

      createOrEditDialog.content.id = id;

      createOrEditDialog.content.onSave.subscribe(() => {
        this.refresh();
      });
    }

    clearFilters(): void {
        // this.title = '';
        // this.isActive = undefined;
        this.getDataPage(1);
    }
}
