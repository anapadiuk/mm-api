using MM.Common.Contracts.Models;
using MM.Common.Contracts.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MM.Core.Contracts.Entities
{
    public class Product : Entity, INamedEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
