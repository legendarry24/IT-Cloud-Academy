namespace Entity_Framework
{
	public class Phone
	{
		public int Id { get; set; }
	    public string Manufacturer { get; set; }
        public string Model { get; set; }
		public decimal Price { get; set; }

        //one-to-many relationship (the "many" side)
        public int? DepartmentId { get; set; }
	    public virtual Department Department { get; set; } // virtual for lazy loading

	    //one-to-one relationship 
        public PhoneConfig Config { get; set; }
	}
}
