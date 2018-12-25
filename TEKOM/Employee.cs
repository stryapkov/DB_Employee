namespace TEKOM
{
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string SurName { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
    }
}
