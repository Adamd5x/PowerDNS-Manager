export interface ApiResponse<TData> {
    success: boolean;
    error?: string;
    code?: string;
    data?: TData
}