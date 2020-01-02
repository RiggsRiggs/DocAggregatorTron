using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class PropDocs
    {
        [Column("ID")]
        public int Id { get; set; }
        public int? PropRef { get; set; }
        public string Message { get; set; }
    }
}
