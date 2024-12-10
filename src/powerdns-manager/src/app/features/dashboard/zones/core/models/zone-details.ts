import { ZoneKind } from "../types/zone-kind";
import { ZoneRecord } from "./zone-record";

export interface ZoneDetails {
    id: string;
    name: string;
    kind: ZoneKind,
    account: string;
    catalog: string;
    serial: number;
    notifiedSerial: number;
    editedSerial: number;
    last_check: number;
    api_rectify: boolean;    
    masters: string[];
    dnssec: boolean;
    masterTsigKeyIds: string[];
    slaveTsigKeyIds: string[],
    msec3Narrow: boolean;
    nsec3param: string;
    soaEdit: string;
    soaEditApi: string;
    rrsets: ZoneRecord[];
    url: string;
}