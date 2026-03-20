using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class VisaTypeDto
    {
        public int VisaTypeId { get; set; }

        public int CompanyId { get; set; }

        public int RegionId { get; set; }

        public string VisaType1 { get; set; } = null!;
        public string VisaTypeName
        {
            get => VisaType1;
            set => VisaType1 = value;
        }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public string RegionName { get; set; }
        public string CompanyName { get; set; }
    }
}
