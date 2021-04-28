using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Hierarchy;

namespace AdventureWorks.EF.Models
{
    [Table("Production.Document")]
    public partial class Document
    {
        public Document()
        {
        }

        [Key]
        [Required]
        public HierarchyId DocumentNode { get; set; }
        public int? DocumentLevel { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Owner { get; set; }
        [Required]
        public bool FolderFlag { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileExtension { get; set; }
        [Required]
        public string Revision { get; set; }
        [Required]
        public int ChangeNumber { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public string DocumentSummary { get; set; }
        [Column("Document")]
        public byte[] DocumentBinary { get; set; }
        [Required]
        public Guid rowguid { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
