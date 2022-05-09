using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        public Guid ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
