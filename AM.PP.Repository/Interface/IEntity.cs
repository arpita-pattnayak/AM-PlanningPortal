using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.PP.Repository.Interface
{
    /// <summary>
    /// Entity interface
    /// </summary>
    public interface IEntity
    {
        public long Id { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }
    }
}
