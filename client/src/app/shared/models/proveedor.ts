export interface Proveedor {
    id: number;
    name: string;
    description: string;
    telefono: string;
    correo: string;
    rubro: string;
    rubrosId : number;
}

export class Proveedor implements Proveedor {}