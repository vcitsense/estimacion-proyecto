import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private baseUrl = 'http://52.205.206.106:9905/'; 
  //private baseUrl = 'https://localhost:7061/'; 

  constructor(private http: HttpClient) {}


  //Usuarios ============================================================================================================

  autenticacionUsuario(input: any): Observable<any> {
    return this.http.post(this.baseUrl + "api/Usuario/AutenticacionUsuario", input);
  }


  //Entidades ===========================================================================================================
  consultarEntidades(): Observable<any> {
    return this.http.get(this.baseUrl + "api/Proyecto/ConsultarEntidades");
  }


  upsertEntidad(input: any): Observable<any> {
    return this.http.post(this.baseUrl + "api/Proyecto/UpsertEntidad", input);
  }

  //Proyectos ===========================================================================================================
  consultarProyectosPorEntidad(idEntidad: number): Observable<any> {
    return this.http.get(this.baseUrl + "api/Proyecto/ConsultarProyectosPorEntidad?idEntidad=" + idEntidad);
  }


  upsertProyecto(input: any): Observable<any> {
    return this.http.post(this.baseUrl + "api/Proyecto/upsertProyecto", input);
  }

  //Modulos ===========================================================================================================
  consultarModulosPorProyecto(idProyecto: number): Observable<any> {
    return this.http.get(this.baseUrl + "api/Proyecto/ConsultarModulosPorProyecto?idProyecto=" + idProyecto);
  }


  upsertModulo(input: any): Observable<any> {
    return this.http.post(this.baseUrl + "api/Proyecto/upsertModulo", input);
  }

  consutarProyeccion(idProyecto: number): Observable<any> {
    return this.http.get(this.baseUrl + "api/Proyecto/consutarProyeccion?idProyecto=" + idProyecto);
  }

  //Historias Usuario  ===========================================================================================================
  consultarHistoriasUsuario(idModulo: number): Observable<any> {
    return this.http.get(this.baseUrl + "api/Proyecto/ConsultarHistoriasUsuario?idModulo=" + idModulo);
  }


  upsertHistoriaUsuario(input: any): Observable<any> {
    return this.http.post(this.baseUrl + "api/Proyecto/upsertHistoriaUsuario", input);
  }

  //Actividades  ===========================================================================================================
  consultarActividadesPorHistoriaUsuario(idHistoriaUsuario: number): Observable<any> {
    return this.http.get(this.baseUrl + "api/Proyecto/ConsultarActividadesPorHistoriaUsuario?idHistoriaUsuario=" + idHistoriaUsuario);
  }


  upsertActividad(input: any): Observable<any> {
    return this.http.post(this.baseUrl + "api/Proyecto/upsertActividad", input);
  }
}
