import { AuditoriaModel } from "./auditoria.model";

export class EntidadModel extends AuditoriaModel {

    idEntidad: number = 0;
    nit: string = "";
    nombreEntidad: string = "";
    urlImagen: string = "";
}