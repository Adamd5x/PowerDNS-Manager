import { RecordItem } from "./record-item";

export interface ZoneRecord {
    type: string;
    name: string;
    ttl: number;
    comments: string [];
    records: RecordItem[];
}