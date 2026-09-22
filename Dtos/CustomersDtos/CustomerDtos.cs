namespace Flower_Shop.Dtos.CustomersDtos
{
    public class CreateCustomerDto
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
    }

    public class UpdateCustomerDto : CreateCustomerDto
    {
        public int Id { get; set; }
        public string UID { get; set; } = "";
    }

    public class CustomerDto : UpdateCustomerDto
    {
    }
}