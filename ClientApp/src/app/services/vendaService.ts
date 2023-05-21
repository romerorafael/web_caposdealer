import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'

@Injectable()
export class VendaService {

  private baseUrl: string = 'https://localhost:7232/';

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Venda[]>(this.baseUrl + 'venda/getall');
  }

  getById(id: number) {
    return this.http.get<Venda>(this.baseUrl + `venda/get/${id}`)
  }

  update(product: Venda) {
    return this.http.put(this.baseUrl + 'venda/put', product);
  }

  create(product: Venda) {
    return this.http.post(this.baseUrl + 'venda/create', product);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + `venda/delete/${id}`)
  }

}

export interface Venda {
  idVenda: number;
  idCliente: number;
  idProduto: number;
  vlrUnitario: number;
  qtdVenda: number;
  dthVenda: Date;
  vlrUnitarioVenda: number;
  nmCliente: string;
  dscProduto: string;
}
