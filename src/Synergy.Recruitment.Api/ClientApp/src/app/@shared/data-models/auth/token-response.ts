
/**
 * The token response data-model for mapping the token response.
 *
 * @export
 * @class TokenResponse
 */
export class TokenResponse {
    public access_token: string;

    public token_type: string;

    public expires_in: number;

    public refresh_token: string;
}
