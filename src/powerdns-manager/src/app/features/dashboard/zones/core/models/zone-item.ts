import { ZoneKind } from "../types/zone-kind";

export interface ZoneItem {
    id: string;
    name: string;
    serial: number;
    editedSerial: number;    
    notifiedSerial: number;
    lastCheck: string;
    account: string;
    catalog: string;
    dnssec: boolean;    
    kind: ZoneKind;
    masters: string[]
}