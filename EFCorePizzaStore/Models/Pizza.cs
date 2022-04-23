namespace EFCorePizzaStore.Models
{

    /*
     {
        "name": "Pepperoni",
        "description": "A classic pepperoni pizza"
     }
     */
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
