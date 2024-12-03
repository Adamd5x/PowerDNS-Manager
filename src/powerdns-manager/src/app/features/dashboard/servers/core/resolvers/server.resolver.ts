import { inject } from "@angular/core";
import { ActivatedRouteSnapshot,
         ResolveFn,
         RouterStateSnapshot } from "@angular/router";
import { Server } from "../models/server";
import { ServerService } from "../../services/server-service.service";


export const ServerResolver: ResolveFn<Server> = (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
) => {
    const id = route.paramMap.get('id');
    return inject(ServerService).getServer(id!);
}