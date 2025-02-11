import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DatePipe } from '@angular/common'; // Import DatePipe here

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    HttpClientModule  
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [DatePipe],
})
export class AppComponent {
  title = 'proyectos-frontend';

  autenticado = "NO" ;

  validarAutenticacion()
  {
    return localStorage.getItem('auth') ?? "";
  }

}
