namespace Escola.Domain.DTO
{
    public class BaseDTO
    {
        public IList<AlunoDTO> Data { get; set; }

        public PaginacaoDTO pagiancao { get; set; }
    }
}
