import { Component, OnInit } from '@angular/core';
import { Cliente, ClienteService } from '../../services/clienteService'
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import ValidateForm from '../../helper/validateForm';
import { NgToastService } from 'ng-angular-popup'

@Component({
  selector: 'cliente',
  templateUrl: './cliente.component.html',  
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  public clientes: Cliente[] = new Array<Cliente>;
  public clientesBkp: Cliente[] = new Array<Cliente>;
  public isEdit: boolean = false;
  public clientForm!: FormGroup;
  public clientScaffold: Cliente = { idCliente: 0, nmCidade: '', nmCliente: '' };

  public showAddClient: boolean = false;
  public showToast: boolean = false;
  public showDeleteClient: boolean = false;
  public noFoundTerm: boolean = false;

  constructor(
    private clienteService: ClienteService,
    private fb: FormBuilder,
    private toast: NgToastService
  ) { }

  ngOnInit() {
    this.clientForm = this.fb.group({
      nmCidade: ['', Validators.required],
      nmCliente: ['', Validators.required]
    });
    this.clienteService.getAll().subscribe(data => {
      this.clientes = data;
      this.clientesBkp = [...this.clientes];
    }, error => console.error(error));
  }

  openRegister(edit: boolean, cliente: Cliente | null) {
    this.isEdit = edit;
    this.clientForm.reset();

    if (edit && cliente != null) {
      this.clientForm = this.fb.group({
        idCliente: [cliente.idCliente, Validators.required],
        nmCidade: [cliente.nmCidade, Validators.required],
        nmCliente: [cliente.nmCliente, Validators.required]
      });
    } else {
      this.clientForm = this.fb.group({
        nmCidade: ['', Validators.required],
        nmCliente: ['', Validators.required]
      });
    }

    this.showAddClient = true;
  }

  onSubmit() {
    if (this.clientForm.valid) {
      if (this.isEdit) {
        this.clienteService.update(this.clientForm.value).subscribe({
          next: (res: any) => {
            this.clientForm.reset;
            this.showAddClient = false;
            if (res.success) {
              this.toast.success({ detail: "SUCESSO", summary: "Cliente editado com sucesso", duration: 2000 });
            }
            location.reload();
          },
          error: (err) => {
            this.toast.success({ detail: "SUCESSO", summary: err, duration: 2000 });
          }
        })
      } else {
        this.clienteService.create(this.clientForm.value).subscribe({
          next: (res: any) => {
            this.clientForm.reset;
            this.showAddClient = false;
            if (res.success) {
              this.toast.success({ detail: "SUCESSO", summary: "Cliente criado com sucesso", duration: 2000 });
            }
            location.reload();
          },
          error: (err) => {
            this.toast.success({ detail: "ERRO", summary: err, duration: 2000 });
          }
        })
      }
    } else {
      ValidateForm.validateAllFields(this.clientForm);
    }
  }

  deleteModal(cliente: Cliente) {
    this.clientScaffold = cliente;
    this.showDeleteClient = true;
  }

  onDelete() {
    this.showDeleteClient = false;
    this.clienteService.delete(this.clientScaffold.idCliente).subscribe({
      next: (res: any) => {
        this.clientForm.reset;
        this.showAddClient = false;
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
      this.clientes = [...this.clientesBkp];
      this.clientes = this.clientes.filter(x => x.nmCliente.toLowerCase().includes(searchTerm));
    } else if (searchTerm.length == 0 || searchTerm == '') {
      this.clientes = [...this.clientesBkp];
    }

    if (this.clientes.length == 0) {
      this.noFoundTerm = true;
    } else {
      this.noFoundTerm = false;
    }
  }
}
