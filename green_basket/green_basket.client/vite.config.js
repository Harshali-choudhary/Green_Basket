import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import fs from 'fs';
import path from 'path';
import { execSync } from 'child_process';
import process from 'process';

import { env } from 'process';

const __dirname = path.dirname(new URL(import.meta.url).pathname);

const baseFolder = env.APPDATA || `${env.HOME}/.aspnet/https`;
const certificateName = "green_basket.client";
const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

// Generate certificate if it doesn't exist
if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
    try {
        execSync(
            `dotnet dev-certs https --export-path ${certFilePath} --format Pem --no-password`,
            { stdio: 'inherit' }
        );
    } catch (error) {
        console.error("Error creating certificate:", error.message);
        process.exit(1);
    }
}

const target = env.ASPNETCORE_HTTPS_PORT
    ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
    : env.ASPNETCORE_URLS
        ? env.ASPNETCORE_URLS.split(';')[0]
        : 'https://localhost:7287';

export default defineConfig({
    plugins: [react()],
    resolve: {
        alias: {
            '@': path.resolve(__dirname, './src'),
            '@Components': path.resolve(__dirname, './src/Components'),
            '@pages': path.resolve(__dirname, './src/pages'),
        }
    },
    server: {
        proxy: {
            '^/api': {
                target,
                secure: false,
                changeOrigin: true,
            },
            '^/weatherforecast': {
                target,
                secure: false
            }
        },
        port: 5173,
        https: fs.existsSync(keyFilePath) && fs.existsSync(certFilePath)
            ? {
                key: fs.readFileSync(keyFilePath),
                cert: fs.readFileSync(certFilePath),
            }
            : undefined, // Only use HTTPS if certs exist
    }
});
