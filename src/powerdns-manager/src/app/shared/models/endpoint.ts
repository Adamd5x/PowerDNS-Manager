import { EndpointType } from "../types/endpoint-type";

export interface Endpoint {
    endpointType: EndpointType,
    url: string
}