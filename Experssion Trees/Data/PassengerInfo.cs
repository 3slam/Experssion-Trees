using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Experssion_Trees.Data
{
    public class PassengerInfo
    {
        public int Id { get; set; }
        public bool Survived { get; set; }

        
        public int PassengerClass { get; set; } // Renamed to avoid conflict with C# keyword

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Sex { get; set; }

        public int Age { get; set; }

        public int SiblingsOrSpouse { get; set; }

        public int ParentOrChildren { get; set; }
       
    }
}
 

