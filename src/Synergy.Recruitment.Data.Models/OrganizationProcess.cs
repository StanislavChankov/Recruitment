namespace Synergy.Recruitment.Data.Models
{
    public class OrganizationProcess
    {
        public long Id { get; set; }

        public long OrganizationId { get; set; }

        public long ProcessId { get; set; }

        public int Sequence { get; set; }

        public Process Process { get; set; }
    }
}
