namespace WebTestInvent
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order strings")]
    public partial class Order_string
    {
        [Key]
        [Column("Id string")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public Order Order { get; set; }

        [Required]
        public Good Good { get; set; }

        [Column(TypeName = "money")]
        public decimal Prise { get; set; }

        public int Count { get; set; }

        [Column(TypeName = "money")]
        public decimal Sum { get; set; }
    }
}
