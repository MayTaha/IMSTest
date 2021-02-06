import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';

import { ProductsComponent } from './products/products.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                   
                    { path: 'products', component: ProductsComponent,  canActivate: [AppRouteGuard] },
                    
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
