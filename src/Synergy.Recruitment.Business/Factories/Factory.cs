namespace Synergy.Recruitment.Business.Factories
{
    public static class Factory
    {
        public static bool ProjectIsActive(bool isActive, bool? includeIsActive)
            => (includeIsActive.HasValue && includeIsActive == isActive)
                || !includeIsActive.HasValue;
    }
}
