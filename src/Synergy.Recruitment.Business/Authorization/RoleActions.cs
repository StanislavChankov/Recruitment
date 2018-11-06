namespace Synergy.Recruitment.Business.Authorization
{
    public class RoleActions
    {
        /// <summary>
        /// Gets the <see cref="RoleAction"/> that allows viewing the dashboard.
        /// </summary>
        public static RoleAction ViewDashboard { get; } = new RoleAction(nameof(ViewDashboard), 1);

        public static RoleAction ViewCandidates { get; } = new RoleAction(nameof(ViewCandidates), 2);
    }
}
