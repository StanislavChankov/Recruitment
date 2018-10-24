namespace Synergy.Recruitment.Data.Models
{
    public class CandidateJobAdvertisment
    {
        public long Id { get; set; }

        public long CandidateId { get; set; }

        public long JobAdvertismentId { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual JobAdvertisement JobAdvertisment { get; set; }
    }
}
