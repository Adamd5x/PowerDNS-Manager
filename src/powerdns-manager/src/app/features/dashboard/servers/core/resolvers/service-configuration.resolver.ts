import { ActivatedRouteSnapshot, ResolveFn, RouterStateSnapshot } from '@angular/router';
import { ServiceConfigItem } from '../models/service-config-item';
import { inject } from '@angular/core';
import { ServerService } from '../../services/server-service.service';

export const ServiceConfigurationResolver: ResolveFn<ServiceConfigItem[]> = (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
) => {
    const id = route.paramMap.get('id');
    return inject(ServerService).getServiceConfig(id!);
}