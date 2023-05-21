import { Injectable, Inject} from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'

@Injectable()
export class ProdutoService {

  private baseUrl: string = 'https://localhost:7232/';

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Produto[]>( this.baseUrl + 'produto/getall');
  }

  getById(id: number) {
    return this.http.get<Produto>(this.baseUrl + `produto/get/${id}`)
  }

  update(product: Produto) {
    return this.http.put(this.baseUrl + 'produto/put', product);
  }

  create(product: Produto) {
    return this.http.post(this.baseUrl + 'produto/create', product);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + `produto/delete/${id}`)
  }
  
}

export interface Produto {
  idProduto: number;
  dscProduto: string;
  vlrUnitario: number;
}
