import { HttpClientModule } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MensajeComponent } from '../../../shared-components/mensaje/mensaje.component';
import { CommonModule } from '@angular/common';
import { MensajeModel } from '../../../modelos/mensaje.model';
import { UsuarioService } from '../../../servicios/usuario.service';
import { Modal } from 'bootstrap'; // Import Bootstrap's Modal class
import { HistoriaUsuarioModel } from '../../../modelos/historia-usuario.model';
import { ModuloModel } from '../../../modelos/modulo.model';

@Component({
  selector: 'app-historias-usuarios',
  standalone: true,
  imports: [
    FormsModule,      // Required for ngModel
    HttpClientModule,
    MensajeComponent,
    CommonModule
  ],
  templateUrl: './historias-usuarios.component.html',
  styleUrl: './historias-usuarios.component.css'
})

export class HistoriasUsuariosComponent {

  mensaje: MensajeModel = new MensajeModel();
  historiasUsuarios: HistoriaUsuarioModel[] = [];
  historiasUsuarioSeleccionado: HistoriaUsuarioModel = new HistoriaUsuarioModel();
  idModuloSeleccionado: number = 0;
  idProyectoSeleccionado: number = 0

  modulos: ModuloModel[] = [];
  moduloSeleccionado: ModuloModel = new ModuloModel();
  
  @ViewChild('upsertModalHU') modal: any; // Access the modal using ViewChild

  constructor(private _usuarioService: UsuarioService
  ) {

    
  let idProyecto = +(localStorage.getItem('idProyecto') ?? 0)        
  this.idProyectoSeleccionado = idProyecto; 

  this.consultarModulosPorProyecto()

  }

  consultarModulosPorProyecto()
  {
    this._usuarioService.consultarModulosPorProyecto(this.idProyectoSeleccionado).subscribe({
      next: (response) => {
    
        this.mensaje.codigo = response.status
        this.mensaje.mensaje = response.message
    
        if(response.status == 200)
        {
          this.modulos = response.data;

          if(this.modulos.length > 0)
          {
            this.consultarHistoriasUsuario(this.modulos[0].idModulo);
          }
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

  onModuloChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedId = selectElement.value;
    this.consultarHistoriasUsuario(+selectedId);
    // Aquí puedes llamar a un servicio o hacer algo con el ID seleccionado
  }

  consultarHistoriasUsuario(idModulo:number)
  {
    this.idModuloSeleccionado = idModulo;
    this._usuarioService.consultarHistoriasUsuario(idModulo).subscribe({
      next: (response) => {
    
        this.mensaje.codigo = response.status
        this.mensaje.mensaje = response.message
    
        if(response.status == 200)
        {
          this.historiasUsuarios = response.data;
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
      this.historiasUsuarioSeleccionado = registro;
      const modalInstance = new Modal(this.modal.nativeElement); // Create instance of modal
      modalInstance.show(); // Open the modal
    }
  
    
  
  
    upsertHistoriaUsuario()
    {
      this.mensaje.ver = false;
      this.historiasUsuarioSeleccionado.creadoPor = localStorage.getItem('idUsuario') !== null ? Number(localStorage.getItem('idUsuario')) : 0;
      this.historiasUsuarioSeleccionado.actualizadoPor = localStorage.getItem('idUsuario') !== null ? Number(localStorage.getItem('idUsuario')) : 0;
      this.historiasUsuarioSeleccionado.idModulo = this.idModuloSeleccionado;

      this._usuarioService.upsertHistoriaUsuario(this.historiasUsuarioSeleccionado).subscribe({
        next: (response) => {
  
  
          this.mensaje.codigo = response.status
          this.mensaje.mensaje = response.message
          this.mensaje.ver = true;
          if(response.status == 200)
          {
            this.historiasUsuarios = response.data;
            this.historiasUsuarioSeleccionado = new HistoriaUsuarioModel();
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
