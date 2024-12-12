import { ServiceMode } from "@shared/types/service-mode";

export interface Server {
    id: string;
    name: string;
    dataCenterId?: string;
    description?: string;
    proto: string;
    hostAddress: string;
    port: number;
    apiKey?: string;
    auth?: string;
    version?: string;
    os?: string;
    configuration?: string;
    localId?: string;
    serviceMode?: ServiceMode;
}