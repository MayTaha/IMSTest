using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ProductCatalogue.Dto
{
    public class PagedProductResultRequestDto : PagedResultRequestDto
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public int? Quantity { get; set; }
        public QuantityOperator QuantityOperator { get; set; }
        public DateTime? CreationTime { get; set; }
    }

    public enum QuantityOperator
    {
        Equals = 1,
        GreaterThan = 2,
        LessThan = 3
    }
}
