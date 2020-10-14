using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Api.Models
{
    [DataContract]
    public class ProductModel
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid ProductIdentity { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ProductName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double UnitPrice { get; set; }
    }
}