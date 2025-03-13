using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.Models
{
    public enum CustomerTypeEnum
    {
        Company,
        Person,
    }

    public class CustomerType
    {
        public CustomerTypeEnum Id { get; set; }
        public string? Name { get; set; }
    }
}
