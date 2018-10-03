namespace MM.Common.Contracts.Models
{
    using Interfaces;
    using System.ComponentModel.DataAnnotations;

    public abstract class Entity: IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
