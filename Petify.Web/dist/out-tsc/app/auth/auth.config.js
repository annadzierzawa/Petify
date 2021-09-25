/* eslint-disable @typescript-eslint/naming-convention */
export class AuthSettings {
    static getClientSettings() {
        return {
            authority: appConfig.identityUrl,
            client_id: "Petify_spa",
            redirect_uri: `${appConfig.clientUrl}/auth-callback`,
            response_type: "code",
            scope: "openid profile email Petifyapi.read",
            automaticSilentRenew: true,
            silent_redirect_uri: `${appConfig.clientUrl}/assets/silent-refresh.html`
        };
    }
}
//# sourceMappingURL=auth.config.js.map