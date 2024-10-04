namespace Auto_Mapper_Program.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product>Products { get; set; }
    }
}