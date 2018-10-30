namespace Synergy.Recruitment.Resources
{
    public static class IdentityServerConstants
    {
        #region Claims

        /// <summary>
        /// The organization identifier custom claim.
        /// </summary>
        public const string Org = "org";

        #endregion

        #region Resources

        /// <summary>
        /// The organization resource name.
        /// </summary>
        public const string ORGANIZATION = "organization";

        /// <summary>
        /// The organization resource display name.
        /// </summary>
        public const string OrganizationName = "organization_name";

        #endregion

        #region Clients

        /// <summary>
        /// The recruitment API identifier.
        /// </summary>
        public const string RECRUITMENT_API_ID = "recruitment";

        /// <summary>
        /// The recruitment API name.
        /// </summary>
        public const string RECRUITMENT_API_NAME = "Recruitment Api Client";

        /// <summary>
        /// The recruitment API secret.
        /// </summary>
        public const string RECRUITMENT_API_SECRET = "G8$DJR*D-JD%V-!V3H-HD#D-AHFG(F#J";

        #endregion

        #region Scopes

        /// <summary>
        /// The recruitment Api scope.
        /// </summary>
        public const string RECRUITMENT_API = "recruitment-api";
    
        /// <summary>
        /// The recruitment display name.
        /// </summary>
        public const string RECRUITMENT_API_DISPLAY_NAME = "Recruitment Api";

        /// <summary>Open id scope.</summary>
        public const string OPENID = "openid";

        #endregion
    }
}
