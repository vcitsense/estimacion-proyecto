import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component'; // Adjust the path if needed
import { EntidadesComponent } from './entidades/entidades.component';
import { ProyectosComponent } from './proyectos/proyectos.component';
import { AdministrarProyectoComponent } from './proyectos/administrar-proyecto/administrar-proyecto.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent }, // Route for the login page
  { path: 'entidades', component: EntidadesComponent }, 
  { path: 'proyectos/:idEntidad', component: ProyectosComponent },
  { path: 'administrarproyecto', component: AdministrarProyectoComponent },

  { path: '**', redirectTo: 'login', pathMatch: 'full' } // Optional: Redirect unknown paths to login
];
