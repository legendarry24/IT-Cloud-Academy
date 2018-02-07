namespace ZooCodeFirst
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Animal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        public string Name { get; set; }

        public int? Age { get; set; }
    }
}
