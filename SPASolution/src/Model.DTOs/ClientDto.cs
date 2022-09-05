using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class ClientCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
