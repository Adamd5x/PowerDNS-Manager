import { UserRole } from "@shared/types/user-role-type";

export interface AppUser {
    id: string | undefined;
    name?: string;
    email?: string;
    roles?: UserRole[];
}