import { Endpoint } from "./endpoint";

export interface StartUpConfig {
    licenseToken: string | undefined,
    userToken: string | undefined,
    refreshInterval: number,
    endpoints?: Endpoint[]
}