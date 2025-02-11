import { Component, ViewChild } from '@angular/core';
import { UsuarioService } from '../servicios/usuario.service';
import { MensajeModel } from '../modelos/mensaje.model';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MensajeComponent } from '../shared-components/mensaje/mensaje.component';
import { CommonModule, DatePipe } from '@angular/common'; // Import DatePipe here
import { Modal } from 'bootstrap'; // Import Bootstrap's Modal class
import { EntidadModel } from '../modelos/entidad.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-entidades',
  standalone: true,
    imports: [
      FormsModule,      // Required for ngModel
      HttpClientModule,
      MensajeComponent,
      CommonModule
    ],
  templateUrl: './entidades.component.html',
  styleUrl: './entidades.component.css'
})
export class EntidadesComponent {

  mensaje: MensajeModel = new MensajeModel();
  entidades: EntidadModel[] = [];
  entidadSeleccionada: EntidadModel = new EntidadModel();

  @ViewChild('exampleModal') modal: any; // Access the modal using ViewChild


  constructor(private _usuarioService: UsuarioService,  private router: Router) {
      this.consultarEntidades();
  } 


  consultarEntidades()
  {
    this._usuarioService.consultarEntidades().subscribe({
      next: (response) => {

        this.mensaje.codigo = response.status
        this.mensaje.mensaje = response.message

        if(response.status == 200)
        {
          this.entidades = response.data;
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
    this.entidadSeleccionada = registro;
    const modalInstance = new Modal(this.modal.nativeElement); // Create instance of modal
    modalInstance.show(); // Open the modal
  }

  


  upsertEntidad()
  {
    this.mensaje.ver = false;
    this.entidadSeleccionada.creadoPor = localStorage.getItem('idUsuario') !== null ? Number(localStorage.getItem('idUsuario')) : 0;
    this.entidadSeleccionada.actualizadoPor = localStorage.getItem('idUsuario') !== null ? Number(localStorage.getItem('idUsuario')) : 0;

    this._usuarioService.upsertEntidad(this.entidadSeleccionada).subscribe({
      next: (response) => {


        this.mensaje.codigo = response.status
        this.mensaje.mensaje = response.message
        this.mensaje.ver = true;
        if(response.status == 200)
        {
          this.entidades = response.data;
          this.entidadSeleccionada = new EntidadModel();
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


  redireccionarProyectos(entidad: EntidadModel)
  {
    localStorage.setItem('idEntidad', entidad.idEntidad.toString());
    localStorage.setItem('nombreEntidad', entidad.nombreEntidad);
    
    this.router.navigate(['/proyectos', entidad.idEntidad]);
  }


}
