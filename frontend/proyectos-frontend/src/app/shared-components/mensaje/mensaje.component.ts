import { Component, Input } from '@angular/core';
import { MensajeModel } from '../../modelos/mensaje.model';

@Component({
  selector: 'app-mensaje',
  standalone: true,
  imports: [],
  templateUrl: './mensaje.component.html',
  styleUrl: './mensaje.component.css'
})
export class MensajeComponent {

  @Input() mensaje: MensajeModel =  new MensajeModel();


  ocultarMensaje() 
  {
    this.mensaje.ver = false;
  }
}
