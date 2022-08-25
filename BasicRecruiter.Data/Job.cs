using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Data
{
    internal class Job:BaseEntity
    {
        public string Summary { get; set; }
        public string Title { get; set; }
        public string JobDescriptionUrl { get; set; }
        public DateTime ExpiryDate { get; set; }

        public int JobStatusId { get; set; }
        public JobStatus JobStatus { get; set; }
    }
}
