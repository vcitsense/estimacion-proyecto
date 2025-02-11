import { AuditoriaModel } from "./auditoria.model";

export class ActividadModel extends AuditoriaModel {

    idActividad: number = 0;
    descripcion: string = "";
    idHistoriaUsuario: number = 0;
    analisis: number = 0;
    documentacion: number = 0;
    pruebas: number = 0;
    devops: number = 0;
    disenoGrafico: number = 0;
}
