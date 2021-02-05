using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ProductCatalogue
{
    public class Product : FullAuditedEntity
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
    }
}
