using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.DTO.Models.BL
{
    [DataContract]
    public class RegisInfoDTO
    {
        [DataMember]
        public List<Province> Provinces { get; set; }
    }

    [DataContract]
    public class Province
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
