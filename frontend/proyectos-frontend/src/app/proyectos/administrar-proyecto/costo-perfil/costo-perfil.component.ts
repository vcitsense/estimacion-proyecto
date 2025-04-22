import { HttpClientModule } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MensajeComponent } from '../../../shared-components/mensaje/mensaje.component';
import { CommonModule } from '@angular/common';
import { MensajeModel } from '../../../modelos/mensaje.model';
import { UsuarioService } from '../../../servicios/usuario.service';
import { Modal } from 'bootstrap'; // Import Bootstrap's Modal class
import { ModuloModel } from '../../../modelos/modulo.model';
import { CostoPerfilModel } from '../../../modelos/costopefil.model';
import { ItemModel } from '../../../modelos/item.model';

@Component({
  selector: 'app-costo-perfil',
  standalone: true,
  imports: [
    FormsModule,      // Required for ngModel
    HttpClientModule,
    MensajeComponent,
    CommonModule
  ],
  templateUrl: './costo-perfil.component.html',
  styleUrl: './costo-perfil.component.css'
})
export class CostoPerfilComponent {

  mensaje: MensajeModel = new MensajeModel();
  idModuloSeleccionado: number = 0;
  idProyectoSeleccionado: number = 0

  costoPerfil: CostoPerfilModel[] = [];
  costoPerfileleccionado: CostoPerfilModel = new CostoPerfilModel();
  perfiles: ItemModel[] = [];

  @ViewChild('upsertModal') modal: any; // Access the modal using ViewChild

  constructor(private _usuarioService: UsuarioService
  ) {

    
  let idProyecto = +(localStorage.getItem('idProyecto') ?? 0)        
  this.idProyectoSeleccionado = idProyecto; 

  this.consultarCostoPerfilPorProyecto();
  this.consultarItemsPorCatalogo();

  }

  consultarCostoPerfilPorProyecto()
  {
    this._usuarioService.consultarCostoPerfilPorProyecto(this.idProyectoSeleccionado).subscribe({
      next: (response) => {
    
        this.mensaje.codigo = response.status
        this.mensaje.mensaje = response.message
    
        if(response.status == 200)
        {
          this.costoPerfil = response.data;

        }
    
      },
      error: (error) => {
        console.error('error', error);
        this.mensaje.codigo = 500
        this.mensaje.mensaje = "Error procesando la solicitud"
        this.mensaje.ver = true
    
      }
    });
  }

  consultarItemsPorCatalogo()
  {
    this._usuarioService.consultarItemsPorCatalogo(1).subscribe({
      next: (response) => {
    
        this.mensaje.codigo = response.status
        this.mensaje.mensaje = response.message
    
        if(response.status == 200)
        {
          this.perfiles = response.data;

        }
    
      },
      error: (error) => {
        console.error('error', error);
        this.mensaje.codigo = 500
        this.mensaje.mensaje = "Error procesando la solicitud"
        this.mensaje.ver = true
    
      }
    });
  }


  abrirModalCrear(): void {
      const modalInstance = new Modal(this.modal.nativeElement); // Create instance of modal
      modalInstance.show(); // Open the modal
    }
  
    abrirModalEditar(registro: any): void {
      this.costoPerfileleccionado = registro;
      const modalInstance = new Modal(this.modal.nativeElement); // Create instance of modal
      modalInstance.show(); // Open the modal
    }
  
    
  
  
    upsertCostoPerfilPorProyecto()
    {
      this.mensaje.ver = false;
      
      if(!this.validarPorcentaje())
      {
        this.mensaje.codigo = 500
        this.mensaje.mensaje = "El porcentaje total supera el 100%"
        this.mensaje.ver = true
      }
      else 
      {
        

        this.costoPerfileleccionado.idProyecto = this.idProyectoSeleccionado;
        this._usuarioService.upsertCostoPerfilPorProyecto(this.costoPerfileleccionado).subscribe({
          next: (response) => {
    
    
            this.mensaje.codigo = response.status
            this.mensaje.mensaje = response.message
            this.mensaje.ver = true;
            if(response.status == 200)
            {
              this.costoPerfil = response.data;
              this.costoPerfileleccionado = new CostoPerfilModel();
            }
    
          },
          error: (error) => {
            console.error('error', error);
            this.mensaje.codigo = 500
            this.mensaje.mensaje = "Error procesando la solicitud"
            this.mensaje.ver = true
    
          }
        });
      }

      
    }

    calculateTotal()
    {
      this.costoPerfileleccionado.costoTotal = this.costoPerfileleccionado.costoHora * this.costoPerfileleccionado.cantidad;
    }

    validarPorcentaje(): boolean
    {
      let porcentaje = 0;

      for(let i = 0; i < this.costoPerfil.length; i++)
      {
        porcentaje += this.costoPerfil[i].porcentajeAsignacion
      }

      let porcentajeTotal = this.costoPerfileleccionado.porcentajeAsignacion;

      //Agrega el total si es nuevo registro
      if(this.costoPerfileleccionado.idCosto == 0)
      {
         porcentajeTotal += porcentaje
      }
      else {
        porcentajeTotal = porcentaje;
      }


      if(porcentajeTotal > 100)
      {
        return false;
      }
      else
      {
        return true;
      }
    }

}
