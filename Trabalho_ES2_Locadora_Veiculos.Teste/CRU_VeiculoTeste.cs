using Xunit;
using Trabalho_BD_Locadora_Veiculos;
using System.Linq;

namespace Trabalho_BD_Locadora_Veiculos.Teste
{
    public class CRUVeiculoTeste
    {
        [Fact]
        public void AdicionarVeiculo_DeveAdicionarNovoVeiculo()
        {
            // Arrange
            var repo = new CRU_veiculo();
            var veiculo = new Veiculo
            {
                Modelo = "Teste Modelo",
                Marca = "Teste Marca",
                Ano = 2023,
                Disponivel = true
            };

            // Act
            repo.AdicionarVeiculo(veiculo);
            var lista = repo.ListarVeiculos();

            // Assert
            Assert.Contains(lista, v => v.Modelo == "Teste Modelo" && v.Marca == "Teste Marca" && v.Ano == 2023 && v.Disponivel);
        }

        [Fact]
        public void AtualizarDisponibilidade_DeveAtualizarStatus()
        {
            // Arrange
            var repo = new CRU_veiculo();

            // Primeiro adiciona um veículo para garantir que exista um ID conhecido
            var veiculo = new Veiculo
            {
                Modelo = "Atualizar Modelo",
                Marca = "Atualizar Marca",
                Ano = 2022,
                Disponivel = true
            };
            repo.AdicionarVeiculo(veiculo);

            var lista = repo.ListarVeiculos();
            var veiculoParaAtualizar = lista.LastOrDefault(v => v.Modelo == "Atualizar Modelo");

            Xunit.Assert.NotNull(veiculoParaAtualizar); // Confirma que achou

            // Act
            repo.AtualizarDisponibilidade(veiculoParaAtualizar.Id, false);

            var veiculoAtualizado = repo.ListarVeiculos().FirstOrDefault(v => v.Id == veiculoParaAtualizar.Id);

            // Assert
            Xunit.Assert.False(veiculoAtualizado.Disponivel);
        }
    }
}
