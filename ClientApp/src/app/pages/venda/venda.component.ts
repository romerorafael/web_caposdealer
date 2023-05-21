import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import ValidateForm from '../../helper/validateForm';
import { NgToastService } from 'ng-angular-popup'

import { Venda, VendaService } from '../../services/vendaService'
import { Produto, ProdutoService } from '../../services/produtoService'
import { Cliente, ClienteService } from '../../services/clienteService'

@Component({
  selector: 'venda',
  templateUrl: './venda.component.html',
  styleUrls: ['./venda.component.css']
})
export class VendaComponent implements OnInit {

  public vendas: Venda[] = new Array<Venda>;
  public vendasBkp: Venda[] = new Array<Venda>;
  public produtos: Produto[] = new Array<Produto>;
  public clientes: Cliente[] = new Array<Cliente>;
  public isEdit: boolean = false;
  public sellForm!: FormGroup;
  public sellScaffold: Venda = { idVenda: 0, idCliente: 0, idProduto: 0, vlrUnitario: 0, vlrUnitarioVenda: 0, qtdVenda: 0, dthVenda: new Date(), nmCliente: '', dscProduto: '' };
  public selectValue = "0";

  public showAddSell: boolean = false;
  public showToast: boolean = false;
  public showDeleteSell: boolean = false;
  public noFoundTerm: boolean = false;

  constructor(
    private vendaService: VendaService,
    private clienteService: ClienteService,
    private produtoService: ProdutoService,
    private fb: FormBuilder,
    private toast: NgToastService
  ) { }

  ngOnInit() {
    this.sellForm = this.fb.group({
      idCliente: ['', Validators.required],
      idProduto: ['', Validators.required],
      vlrUnitario: ['', Validators.required],
      qtdVenda: ['', Validators.required]
    });

    this.vendaService.getAll().subscribe(data => {
      this.vendas = data;
      this.vendasBkp = [...this.vendas];
    }, error => console.error(error));
    this.clienteService.getAll().subscribe(data => {
      this.clientes = data;
    }, error => console.error(error));
    this.produtoService.getAll().subscribe(data => {
      this.produtos = data;
    }, error => console.error(error));
  }

  openRegister(edit: boolean, venda: Venda | null) {
    this.isEdit = edit;
    this.sellForm.reset();

    if (edit && venda != null) {
      this.sellForm = this.fb.group({
        idVenda: [venda.idVenda, Validators.required],
        idCliente: [venda.idCliente, Validators.required],
        idProduto: [venda.idProduto, Validators.required],
        vlrUnitario: [venda.vlrUnitario, Validators.required],
        vlrUnitarioVenda: [venda.vlrUnitarioVenda, Validators.required],
        qtdVenda: [venda.qtdVenda, Validators.required],
        dthVenda: [venda.dthVenda, Validators.required],
        nmCliente: [venda.nmCliente, Validators.required],
        dscProduto: [venda.dscProduto, Validators.required]
      });
    }

    this.showAddSell = true;
  }

  onSubmit() {
    console.log(this.sellForm);
    if (this.sellForm.valid) {
      if (this.isEdit) {
        this.vendaService.update(this.sellForm.value).subscribe({
          next: (res: any) => {
            this.sellForm.reset;
            this.showAddSell = false;
            if (res.success) {
              this.toast.success({ detail: "SUCESSO", summary: "Venda editada com sucesso", duration: 2000 });
            }
            location.reload();
          },
          error: (err) => {
            this.toast.success({ detail: "SUCESSO", summary: err, duration: 2000 });
          }
        })
      } else {
        this.vendaService.create(this.sellForm.value).subscribe({
          next: (res: any) => {
            this.sellForm.reset;
            this.showAddSell = false;
            if (res.success) {
              this.toast.success({ detail: "SUCESSO", summary: "Venda criada com sucesso", duration: 2000 });
            }
            location.reload();
          },
          error: (err) => {
            this.toast.success({ detail: "ERRO", summary: err, duration: 2000 });
          }
        })
      }
    } else {
      ValidateForm.validateAllFields(this.sellForm);
    }
  }

  deleteModal(venda: Venda) {
    this.sellScaffold = venda;
    this.showDeleteSell = true;
  }

  onDelete() {
    this.showDeleteSell = false;
    this.vendaService.delete(this.sellScaffold.idVenda).subscribe({
      next: (res: any) => {
        this.sellForm.reset;
        this.showDeleteSell = false;
        if (res) {
          this.toast.success({ detail: "SUCESSO", summary: "Venda deletado com sucesso", duration: 2000 });
        }
        location.reload();
      },
      error: (err) => {
        this.toast.success({ detail: "ERRO", summary: err, duration: 2000 });
      }
    })
  }

  chargePrice(e: any) {
    let id = parseInt(e.target.value);
    let produto = this.produtos.filter(x => x.idProduto == id)[0];
    this.selectValue = produto != null ? "R$" + produto.vlrUnitario.toString() : "";
    this.sellForm.controls.vlrUnitario.setValue(produto.vlrUnitario);
  }

  search(e: any) {
    debugger
    let searchTerm = e.target.value.toLowerCase();
    if (searchTerm.length >= 3) {
      this.vendas = [...this.vendasBkp];
      this.vendas = this.vendas.filter(x => x.dscProduto.toLowerCase().includes(searchTerm) || x.nmCliente.toLowerCase().includes(searchTerm));
    } else if (searchTerm.length == 0 || searchTerm == '') {
      this.vendas = [...this.vendasBkp];
    }

    if (this.vendas.length == 0) {
      this.noFoundTerm = true;
    } else {
      this.noFoundTerm = false;
    }
  }
}
