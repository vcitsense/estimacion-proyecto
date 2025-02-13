import { AuditoriaModel } from "./auditoria.model";
import { HistoriaUsuarioModel } from "./historia-usuario.model";

export class ModuloModel extends AuditoriaModel {

    idModulo: number = 0;
    nombreModulo: string = "";
    descripcion: string = "";
    idProyecto: number = 0;
    total: number = 0;
    historiasUsuario: HistoriaUsuarioModel[] = [];
}

