import { HttpClientModule } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MensajeComponent } from '../../../shared-components/mensaje/mensaje.component';
import { CommonModule } from '@angular/common';
import { MensajeModel } from '../../../modelos/mensaje.model';
import { ModuloModel } from '../../../modelos/modulo.model';
import { UsuarioService } from '../../../servicios/usuario.service';
import { Modal } from 'bootstrap'; // Import Bootstrap's Modal class

@Component({
  selector: 'app-modules',
  standalone: true,
  imports: [
        FormsModule,      // Required for ngModel
        HttpClientModule,
        MensajeComponent,
        CommonModule
      ],
  templateUrl: './modules.component.html',
  styleUrl: './modules.component.css'
})
export class ModulesComponent {

  mensaje: MensajeModel = new MensajeModel();
  modulos: ModuloModel[] = [];
  moduloSeleccionado: ModuloModel = new ModuloModel();
  idProyectoSeleccionado: number = 0

  @ViewChild('upsertModal') modal: any; // Access the modal using ViewChild
  
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

      upsertModulo()
     {
       this.mensaje.ver = false;
       this.moduloSeleccionado.creadoPor = localStorage.getItem('idUsuario') !== null ? Number(localStorage.getItem('idUsuario')) : 0;
       this.moduloSeleccionado.actualizadoPor = localStorage.getItem('idUsuario') !== null ? Number(localStorage.getItem('idUsuario')) : 0;
       this.moduloSeleccionado.idProyecto = this.idProyectoSeleccionado;
       
       this._usuarioService.upsertModulo(this.moduloSeleccionado).subscribe({
         next: (response) => {
   
   
           this.mensaje.codigo = response.status
           this.mensaje.mensaje = response.message
           this.mensaje.ver = true;
           if(response.status == 200)
           {
             this.modulos = response.data;
             this.moduloSeleccionado = new ModuloModel();
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
       this.moduloSeleccionado = registro;
       const modalInstance = new Modal(this.modal.nativeElement); // Create instance of modal
       modalInstance.show(); // Open the modal
     }

}
