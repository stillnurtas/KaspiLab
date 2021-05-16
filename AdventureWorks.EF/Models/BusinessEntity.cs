namespace AdventureWorks.EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person.BusinessEntity")]
    public partial class BusinessEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusinessEntity()
        {
            BusinessEntityAddress = new HashSet<BusinessEntityAddress>();
        }

        public int BusinessEntityID { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddress { get; set; }
    }
}
