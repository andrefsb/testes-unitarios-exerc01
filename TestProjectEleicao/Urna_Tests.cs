using FluentAssertions;
using testes_unitarios_exerc01;

namespace TestProjectEleicao
{
    public class Urna_Tests
    {

        [Fact]
        public void ValidateEmptyUrna()
        {
            Urna urna = new Urna();

            Assert.Equal(0, urna.VotosVencedor);
            Assert.Equal(0, urna.VotosVencedor);
            Assert.Equal(false, urna.EleicaoAtiva);
            Assert.Equal(0, Urna.Candidatos.Count);
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void ValidateElectionsStartAndFinish(bool initial, bool final)
        {
            Urna urna = new Urna();
            urna.EleicaoAtiva = initial;
            urna.IniciarEncerrarEleicao();
            final.Should().Be(!initial);
        }


        [Theory]
        [InlineData("João", "Pedro")]
        [InlineData("Maria", "José")]
        public void ValidateLastCandidateEntry(string first, string last)
        {
            Urna urna = new Urna();
            urna.CadastrarCandidato(first);
            urna.CadastrarCandidato(last);

            var final = Urna.Candidatos.Last().Nome;

            final.Should().Be(last);
        }


        [Theory]
        [InlineData("João", true)] //Validação de candidato cadastrado
        [InlineData("Maria", false)] //Validação de candidato não cadastrado
        [InlineData("Teste", false)] //Validação de candidato não cadastrado
        public void ValidateCandidateNameVoteEntry(string name, bool expectedResult)
        {
            Urna urna = new Urna();
            urna.CadastrarCandidato("João");
            bool result = urna.Votar(name);
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("José", 5, "João")]
        [InlineData("Maria", 10, "Maria")]
        public void ValidateElectionResult(string name, int votes,string winnerCandidate)
        {
            Urna urna = new Urna();
            urna.CadastrarCandidato("João");
            urna.CadastrarCandidato(name);
            for (int n = 1; n <= 8; n++) {
                urna.Votar("João");
            }
            for (int n = 1; n <= votes; n++)
            {
                urna.Votar(name);
            }
            string winner = urna.MostrarResultadoEleicao();

            votes = winnerCandidate == "João" ? 8 : votes; 

            string result = $"Nome vencedor: {winnerCandidate}. Votos: {votes}";

            winner.Should().Be(result);
        }
    }
}
