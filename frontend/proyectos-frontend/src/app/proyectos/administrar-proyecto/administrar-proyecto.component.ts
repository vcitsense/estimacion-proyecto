import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MensajeComponent } from '../../shared-components/mensaje/mensaje.component';
import { CommonModule } from '@angular/common';
import { MensajeModel } from '../../modelos/mensaje.model';
import { UsuarioService } from '../../servicios/usuario.service';
import { Router } from '@angular/router';
import { ModulesComponent } from './modules/modules.component';
import { HistoriasUsuariosComponent } from './historias-usuarios/historias-usuarios.component';
import { ActividadesComponent } from './actividades/actividades.component';
import { ProyeccionComponent } from './proyeccion/proyeccion.component';

@Component({
  selector: 'app-administrar-proyecto',
  standalone: true,
  imports: [
        FormsModule,      // Required for ngModel
        HttpClientModule,
        MensajeComponent,
        CommonModule,
        ModulesComponent,
        HistoriasUsuariosComponent,
        ActividadesComponent,
        ProyeccionComponent
      ],
  templateUrl: './administrar-proyecto.component.html',
  styleUrl: './administrar-proyecto.component.css'
})
export class AdministrarProyectoComponent {

    mensaje: MensajeModel = new MensajeModel();
    idProyectoSeleccionado: number = 0;
    nombreProyecctoSelecciado: string = "";

    tabSeleccionado: number = 1;

    constructor(private _usuarioService: UsuarioService,  private router: Router) {

      let idProyecto = +(localStorage.getItem('idProyecto') ?? 0)        
      this.idProyectoSeleccionado = idProyecto; 
      this.nombreProyecctoSelecciado = localStorage.getItem('nombreProyecto') ?? "";

    } 

    seleccionarTab(tab:number)
    {
      this.tabSeleccionado = tab;
    }
    
}
