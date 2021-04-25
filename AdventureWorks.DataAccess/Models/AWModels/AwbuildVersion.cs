using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.DataAccess.Models.AWModels
{
    public partial class AwbuildVersion
    {
        public byte SystemInformationId { get; set; }
        public string DatabaseVersion { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
