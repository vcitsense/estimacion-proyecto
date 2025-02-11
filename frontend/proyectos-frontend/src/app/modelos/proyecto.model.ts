import { AuditoriaModel } from "./auditoria.model";

export class ProyectoModel extends AuditoriaModel {

    idProyecto: number = 0;
    nombreProyecto: string = "";
    descripcion: string = "";
    IdEntidad: number = 0;
}