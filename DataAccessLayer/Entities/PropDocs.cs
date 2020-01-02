using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class PropDocs
    {
        [Column("ID")]
        public int Id { get; set; }
        public int? PropRef { get; set; }
        public string Message { get; set; } 
        //public int CountDocs { get; set; }
    }
}
