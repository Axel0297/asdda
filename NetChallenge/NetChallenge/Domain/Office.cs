using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetChallenge.Domain
{
    public class Office
    {
        public string LocationName { get; set; }
        [Required (ErrorMessage = "Ingresar un nombre para la oficina")]
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public IEnumerable<string> AvailableResources { get; set; }
    }
}