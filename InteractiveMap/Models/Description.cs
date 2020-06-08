using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveMap.Models
{
    public class Description
    {
        [Key]
        public int Id { get; set; }
        public int DescriptionText { get; set; }
        public int MyProperty { get; set; }
        public DescriptionObject DescriptionObject { get; set; }
        public int DescritionId { get; set; }
    }
    public class DescriptionObject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Description> Descriptions { get; set; }
    }
}
