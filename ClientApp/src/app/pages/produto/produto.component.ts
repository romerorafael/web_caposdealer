import { Component, OnInit } from '@angular/core';
import { Produto, ProdutoService } from '../../services/produtoService'
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import ValidateForm from '../../helper/validateForm';
import { NgToastService } from 'ng-angular-popup'

@Component({
  selector: 'produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  public produtos: Produto[] = new Array <Produto>;
  public produtosBkp: Produto[] = new Array<Produto>;
  public isEdit: boolean = false;
  public productForm!: FormGroup;
  public productScaffold: Produto = { idProduto: 0, dscProduto: '', vlrUnitario: 0 };

  public showAddProduct: boolean = false;
  public showToast: boolean = false;
  public showDeleteProduct: boolean = false;
  public noFoundTerm: boolean = false;

  constructor(
    private produtoService: ProdutoService,
    private fb: FormBuilder,
    private toast: NgToastService
  ) { }

  ngOnInit() {
    this.productForm = this.fb.group({
      dscProduto: ['', Validators.required],
      vlrUnitario: ['', Validators.required]
    });
    this.produtoService.getAll().subscribe(data => {
      this.produtos = data;
      this.produtosBkp = [...this.produtos];
    }, error => console.error(error));
  }

  openRegister(edit: boolean, produto: Produto|null) {
    this.isEdit = edit;
    this.productForm.reset();

    if (edit && produto!= null) {
      this.productForm = this.fb.group({
        idProduto: [produto.idProduto, Validators.required],
        dscProduto: [produto.dscProduto, Validators.required],
        vlrUnitario: [produto.vlrUnitario, Validators.required]
      });
    } else {
      this.productForm = this.fb.group({
        dscProduto: ['', Validators.required],
        vlrUnitario: ['', Validators.required]
      });
    }
    
    this.showAddProduct = true;
  }

  onSubmit() {
    if (this.productForm.valid) {
      if (this.isEdit) {
        this.productForm.controls.vlrUnitario.setValue(this.productForm.controls.vlrUnitario.value.replace(',','.'));
        this.produtoService.update(this.productForm.value).subscribe({
          next: (res :any) => {
            this.productForm.reset;
            this.showAddProduct = false;
            if (res.success) {
              this.toast.success({ detail: "SUCESSO", summary: "Produto editado com sucesso", duration: 2000 });
            }
            location.reload();
          },
          error: (err) => {
            this.toast.success({ detail: "SUCESSO", summary: err, duration: 2000 });
          }
        })
      } else {
        this.produtoService.create(this.productForm.value).subscribe({
          next: (res: any) => {
            this.productForm.reset;
            this.showAddProduct = false;
            if (res.success) {
              this.toast.success({ detail: "SUCESSO", summary: "Produto criado com sucesso", duration: 2000 });
            }
            location.reload();
          },
          error: (err) => {
            this.toast.success({ detail: "ERRO", summary: err, duration: 2000 });
          }
        })
      }
    } else {
      ValidateForm.validateAllFields(this.productForm);
    }
  }

  deleteModal(produto: Produto) {
    this.productScaffold = produto;
    this.showDeleteProduct = true;
  }

  onDelete() {
    this.showDeleteProduct = false;
    this.produtoService.delete(this.productScaffold.idProduto).subscribe({
      next: (res: any) => {
        this.productForm.reset;
        this.showAddProduct = false;
        if (res) {
          this.toast.success({ detail: "SUCESSO", summary: "Produto deletado com sucesso", duration: 2000 });
        }
        location.reload();
      },
        error: (err) => {
          this.toast.success({ detail: "ERRO", summary: err, duration: 2000 });
        }
    })
  }

  search(e: any) {
    debugger
    let searchTerm = e.target.value.toLowerCase();
    if (searchTerm.length >= 3) {
      this.produtos = [...this.produtosBkp];
      this.produtos = this.produtos.filter(x => x.dscProduto.toLowerCase().includes(searchTerm));
    } else if (searchTerm.length == 0 || searchTerm == '') {
      this.produtos = [...this.produtosBkp];
    }

    if (this.produtos.length == 0) {
      this.noFoundTerm = true;
    } else {
      this.noFoundTerm = false;
    }
  }
}
