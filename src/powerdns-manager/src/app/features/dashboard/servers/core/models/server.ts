export interface Server {
    id: string;
    name: string;
    locationId?: string;
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
    timeout?: number;
    retries?: number;
}