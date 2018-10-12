﻿using System;

namespace Synergy.Recruitment.Rest.Models.Candidate
{
    public class CandidateResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}