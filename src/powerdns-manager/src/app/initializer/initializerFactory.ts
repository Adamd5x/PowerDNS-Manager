import { ConfigService } from "./config.service";

export function startupInitializer(configService: ConfigService): () => Promise<void> {
    console.log('Initializing app...');
    return () => configService.loadConfiguration();
}