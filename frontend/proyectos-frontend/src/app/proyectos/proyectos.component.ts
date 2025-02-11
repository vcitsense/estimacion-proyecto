import { HttpClientModule } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MensajeComponent } from '../shared-components/mensaje/mensaje.component';
import { CommonModule } from '@angular/common';
import { MensajeModel } from '../modelos/mensaje.model';
import { ProyectoModel } from '../modelos/proyecto.model';
import { UsuarioService } from '../servicios/usuario.service';
import { Modal } from 'bootstrap'; // Import Bootstrap's Modal class
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-proyectos',
  standalone: true,
  imports: [
        FormsModule,      // Required for ngModel
        HttpClientModule,
        MensajeComponent,
        CommonModule
      ],
  templateUrl: './proyectos.component.html',
  styleUrl: './proyectos.component.css'
})
export class ProyectosComponent {

    mensaje: MensajeModel = new MensajeModel();
    proyectos: ProyectoModel[] = [];
    proyectoSeleccionado: ProyectoModel = new ProyectoModel();
    idEntidadSeleccionada: number = 0;
    nombreEntidadSeleccionada: string = "";

    @ViewChild('upsertModal') modal: any; // Access the modal using ViewChild
  
  
    constructor(private _usuarioService: UsuarioService,
      private route: ActivatedRoute,
      private router: Router
    ) {

      this.route.paramMap.subscribe(params => {
        let param = +(params.get('idEntidad') ?? 0)
        
        this.idEntidadSeleccionada = param; 

        this.nombreEntidadSeleccionada = localStorage.getItem('nombreEntidad') ?? "";

        if (this.idEntidadSeleccionada) {
          this.consultarProyectosPorEntidad();
        }
      });

    } 


  consultarProyectosPorEntidad()
  {
    this._usuarioService.consultarProyectosPorEntidad(this.idEntidadSeleccionada).subscribe({
      next: (response) => {

        this.mensaje.codigo = response.status
        this.mensaje.mensaje = response.message

        if(response.status == 200)
        {
          this.proyectos = response.data;
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


  upsertProyecto()
  {
    this.mensaje.ver = false;
    this.proyectoSeleccionado.creadoPor = localStorage.getItem('idUsuario') !== null ? Number(localStorage.getItem('idUsuario')) : 0;
    this.proyectoSeleccionado.actualizadoPor = localStorage.getItem('idUsuario') !== null ? Number(localStorage.getItem('idUsuario')) : 0;
    this.proyectoSeleccionado.IdEntidad = this.idEntidadSeleccionada;
    
    this._usuarioService.upsertProyecto(this.proyectoSeleccionado).subscribe({
      next: (response) => {


        this.mensaje.codigo = response.status
        this.mensaje.mensaje = response.message
        this.mensaje.ver = true;
        if(response.status == 200)
        {
          this.proyectos = response.data;
          this.proyectoSeleccionado = new ProyectoModel();
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
    this.proyectoSeleccionado = registro;
    const modalInstance = new Modal(this.modal.nativeElement); // Create instance of modal
    modalInstance.show(); // Open the modal
  }

  redireccionarProyectos(proyecto: ProyectoModel)
  {
    localStorage.setItem('idProyecto', proyecto.idProyecto.toString());
    localStorage.setItem('nombreProyecto', proyecto.nombreProyecto);

    this.router.navigate(['/administrarproyecto']);
  }
  

}
