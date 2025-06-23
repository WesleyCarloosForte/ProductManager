using ProductManager.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; }=DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public EntityStatus Status { get; set; }

        public void Enable()
        {
            Status = EntityStatus.Enabled;
            UpdatedAt= DateTime.UtcNow;
        }
        public void Disable()
        {
            Status = EntityStatus.Disabled;
            UpdatedAt= DateTime.UtcNow;
        }
        public void Delete()
        {
            Status = EntityStatus.Deleted;
            DeletedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
