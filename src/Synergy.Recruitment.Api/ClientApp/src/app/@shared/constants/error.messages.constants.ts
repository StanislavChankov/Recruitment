export class ErrorMessagesConstants {
    public static readonly authFail: string =
        'Authentication failed when trying to connect to the server. See AuthService :39/ environment.tokenEndPoint.';
    public static readonly invalidToken: string = 'The token response which tried to be stored is invalid.';
    public static readonly missingStoragekey: string = 'Key {0} is not present in the local storage.';
    public static readonly argumentNullException: string = 'The provided argument {0} is not defined.';
    public static readonly nameOrUlrNotProvided =
    'Either role action name or request url should be provided to check whether the user is authorized';
}

