import { ActivatedRouteSnapshot, ResolveFn, RouterStateSnapshot } from "@angular/router";
import { DataCenter } from "../models/data-center";
import { map } from 'rxjs';
import { inject } from "@angular/core";
import { DataCenterService } from "../../services/data-center.service";
import { EMPTY_DATA_CENTER } from "../models/empty-data-center";

export const DataCenterResolver: ResolveFn<DataCenter> = (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
) => {
    const dataCenterId = route.paramMap.get('id');
    if (dataCenterId) {
        return inject(DataCenterService).getDataCenter(dataCenterId);
    }
    return EMPTY_DATA_CENTER;
}
