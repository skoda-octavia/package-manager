using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public CustomerType(CustomerTypeEnum type)
        {
            Id = type;
            Name = type.ToString();
        }
        public CustomerType() { }
        public CustomerTypeEnum Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
