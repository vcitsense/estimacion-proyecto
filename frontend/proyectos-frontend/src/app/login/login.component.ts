import { Component } from '@angular/core';
import { UsuarioService } from '../servicios/usuario.service';
import { NgModel, FormsModule } from '@angular/forms'; // Import NgModel and FormsModule
import { HttpClientModule } from '@angular/common/http';
import { MensajeComponent } from '../shared-components/mensaje/mensaje.component';
import { MensajeModel } from '../modelos/mensaje.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,  
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  imports: [
    FormsModule,      // Required for ngModel
    HttpClientModule,
    MensajeComponent
  ]
})
export class LoginComponent {

  mensaje: MensajeModel = new MensajeModel();

  user = {
    usuario: '',
    contrasena: ''
  };

  constructor(private _usuarioService: UsuarioService,  private router: Router) {
    localStorage.setItem('auth', 'NO');
  }

  onSubmit(): void {
    // Call the authentication service
    this._usuarioService.autenticacionUsuario(this.user).subscribe({
      next: (response) => {
        console.log('Login successful:', response);

        

        this.mensaje.codigo = response.status
        this.mensaje.mensaje = response.message
        this.mensaje.ver = true

        if(response.status == 200)
        {
          localStorage.setItem('auth', 'SI');
          localStorage.setItem('token', response.data.token);
          localStorage.setItem('idUsuario', response.data.idUsuario);
          localStorage.setItem('idRol', response.data.idRol);

          this.router.navigate(['/entidades']);
        }
        else 
        {
          localStorage.setItem('auth', 'NO');
        }

        // Handle successful login, e.g., navigate to another page
      },
      error: (error) => {
        console.error('Login failed:', error);
        this.mensaje.codigo = 500
        this.mensaje.mensaje = "Error procesando la solicitud"
        this.mensaje.ver = true
        localStorage.setItem('auth', 'NO');

      }
    });
  }

}
