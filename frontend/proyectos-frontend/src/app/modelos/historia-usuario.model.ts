import { ActividadModel } from "./actividad.model";
import { AuditoriaModel } from "./auditoria.model";

export class HistoriaUsuarioModel extends AuditoriaModel {

    idHistoriaUsuario: number = 0;
    nombre : string = "";
    descripcion: string = "";
    idModulo: number = 0;
    total: number = 0;
    actividades: ActividadModel[] = []
}
