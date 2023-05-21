import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'

@Injectable()
export class ClienteService {

  private baseUrl: string = 'https://localhost:7232/';

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Cliente[]>(this.baseUrl + 'cliente/getall');
  }

  getById(id: number) {
    return this.http.get<Cliente>(this.baseUrl + `cliente/get/${id}`)
  }

  update(product: Cliente) {
    return this.http.put(this.baseUrl + 'cliente/put', product);
  }

  create(product: Cliente) {
    return this.http.post(this.baseUrl + 'cliente/create', product);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + `cliente/delete/${id}`)
  }

}

export interface Cliente {
  idCliente: number;
  nmCliente: string;
  nmCidade: string;
}
