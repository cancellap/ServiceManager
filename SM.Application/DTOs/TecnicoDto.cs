using SM.Domaiin.Entities;

namespace SM.Application.DTOs
{
    public class TecnicoDto
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public EnderecoComplementoDto EnderecoComplementoDto { get; set; }
    }
}
