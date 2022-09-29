using FluentAssertions;
using testes_unitarios_exerc01;

namespace TestProjectEleicao
{
    public class Candidato_Tests
    {

        [Theory]
        [InlineData("João", 0)]
        [InlineData("C1", 0)]
        [InlineData("Maria", 0)]
        [InlineData("Sandro", 0)]
        public void ValidadeVoteNumberAfterCreation(string nome, int expectedResult)
        {
            Candidato candidato = new Candidato(nome);
            var result = candidato.RetornarVotos();
            result.Should().Be(expectedResult);
        }

      [Fact]
        public void ValidateVoteNumberAfterVoting()
        {
            Candidato candidato = new Candidato("Teste");
            int initialValue = candidato.RetornarVotos();
            candidato.AdicionarVoto();
            int finalValue = candidato.RetornarVotos();
            Assert.Equal(initialValue+1, finalValue);
        }


        [Fact]
        public void ValidateCandidateNameAfterCreation()
        {
            Candidato candidato = new Candidato("Teste");
            string finalValue = "Teste";
            Assert.Equal(candidato.Nome , finalValue);
        }
    }
}