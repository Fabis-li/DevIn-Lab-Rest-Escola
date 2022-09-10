namespace Escola.Domain.Models
{
  public class Paginacao
  {
        public Paginacao(int take, int skip)
        {
            this.take = take;
            this.skip = skip;
        }

        public int take { get; set; }

        public int skip { get; set; }
  }


}
   