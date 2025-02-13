import { Component } from '@angular/core';
import { UsuarioService } from '../../../servicios/usuario.service';
import { MensajeModel } from '../../../modelos/mensaje.model';
import { MensajeComponent } from '../../../shared-components/mensaje/mensaje.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-proyeccion',
  standalone: true,
  imports: [
          FormsModule,      // Required for ngModel
          HttpClientModule,
          MensajeComponent,
          CommonModule
        ],
  templateUrl: './proyeccion.component.html',
  styleUrl: './proyeccion.component.css'
})
export class ProyeccionComponent {

  proyeccion: any = {};
  idProyectoSeleccionado: number = 0;
  mensaje: MensajeModel = new MensajeModel();

  constructor(private _usuarioService: UsuarioService
        ) {
    
          
        let idProyecto = +(localStorage.getItem('idProyecto') ?? 0)        
        this.idProyectoSeleccionado = idProyecto; 
  
        this.consutarProyeccion()
  
        } 

        consutarProyeccion()
        {
          this._usuarioService.consutarProyeccion(this.idProyectoSeleccionado).subscribe({
            next: (response) => {
      
              this.mensaje.codigo = response.status
              this.mensaje.mensaje = response.message
      
              if(response.status == 200)
              {
                this.proyeccion = response.data;
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
