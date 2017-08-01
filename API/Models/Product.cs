using System;
using System.ComponentModel.DataAnnotations;

namespace API
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [DataType(DataType.PostalCode)]
        public string OriginPostCode { get; set; }

        public ProductRating Rating { get; set; }
    }

    public enum ProductRating
    {
        Terrible,
        Good,
        Great
    }
}