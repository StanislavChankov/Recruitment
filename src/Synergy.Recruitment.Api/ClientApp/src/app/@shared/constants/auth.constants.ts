export class AuthConstants {
//#region Identity
    public static readonly client_secret: string = 'G8$DJR*D-JD%V-!V3H-HD#D-AHFG(F#J';
    public static readonly client_id: string = 'recruitment';
    public static readonly grant_type: string = 'password';
    public static readonly scopes: string = 'openid profile organization recruitment-api';
//#endregion
//#region Claims
    public static readonly orgId_claim: string = 'org';
//#endregion
}
