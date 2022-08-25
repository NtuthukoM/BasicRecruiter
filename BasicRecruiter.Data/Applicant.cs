using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Domain
{
    public class Applicant:BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CvUrl { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
