namespace Entity_Framework
{
	public class Phone
	{
		public int Id { get; set; }
	    public string Manufacturer { get; set; }
        public string Model { get; set; }
		public decimal Price { get; set; }

	    public int? DepartmentId { get; set; }
	    public Department Department { get; set; }
	}
}
