import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import ValidateForm from '../app/helper/validateForm'
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './pages/home/home.component';
import { ProdutoComponent } from './pages/produto/produto.component';
import { ClienteComponent } from './pages/cliente/cliente.component';
import { VendaComponent } from './pages/venda/venda.component';

import { ProdutoService } from './services/produtoService'
import { ClienteService } from './services/clienteService'
import { VendaService } from './services/vendaService'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProdutoComponent,
    ClienteComponent,
    VendaComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'produto-page', component: ProdutoComponent },
      { path: 'cliente-page', component: ClienteComponent },
      { path: 'venda-page', component: VendaComponent }
    ])
  ],
  providers: [
    ProdutoService,
    ClienteService,
    VendaService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
