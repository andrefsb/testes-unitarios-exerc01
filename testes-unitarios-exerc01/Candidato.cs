namespace testes_unitarios_exerc01
{
    public class Candidato
    {
        public string Nome { get; set; }
        public int Votos { get; private set; }

        public Candidato(string nome)
        {
            Nome = nome;
        }

        public void AdicionarVoto()
        {
            this.Votos ++;
        }

        public int RetornarVotos()
        {
            return this.Votos;
        }

     
    }
}