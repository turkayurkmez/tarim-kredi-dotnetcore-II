using System.ComponentModel.DataAnnotations;

namespace eshop.Domain
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Timestamp]
        public int MyProperty { get; set; }
    }
}
