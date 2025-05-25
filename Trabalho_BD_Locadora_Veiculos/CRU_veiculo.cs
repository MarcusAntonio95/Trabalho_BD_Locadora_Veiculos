using Npgsql;
using System;
using System.Collections.Generic;
using Trabalho_BD_Locadora_Veiculos;

namespace Trabalho_BD_Locadora_Veiculos
{
    //classe de implementação de Create, Read e Update no Banco de Dados
    class CRU_veiculo 
    {
        //identificação do BD
        private string connectionString = "Host=localhost;Username=postgres;Password=dbadmin;Database=locadora_veiculos";

        
        //Método Create
        public void AdicionarVeiculo(Veiculo veiculo)
        {
            //conexão com o BD
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            //inserção dos dados no BD
            var cmd = new NpgsqlCommand("INSERT INTO veiculos (modelo, marca, ano, disponivel) VALUES (@modelo, @marca, @ano, @disponivel)", connection);
            cmd.Parameters.AddWithValue("modelo", veiculo.Modelo);
            cmd.Parameters.AddWithValue("marca", veiculo.Marca);
            cmd.Parameters.AddWithValue("ano", veiculo.Ano);
            cmd.Parameters.AddWithValue("disponivel", veiculo.Disponivel);
            cmd.ExecuteNonQuery();
        }

        //Método Read
        public List<Veiculo> ListarVeiculos()
        {
            var veiculos = new List<Veiculo>();

            //conexão com o BD
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            //leitura dos dados do BD
            var cmd = new NpgsqlCommand("SELECT * FROM veiculos", connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                veiculos.Add(new Veiculo
                {
                    Id = reader.GetInt32(0),
                    Modelo = reader.GetString(1),
                    Marca = reader.GetString(2),
                    Ano = reader.GetInt32(3),
                    Disponivel = reader.GetBoolean(4)
                });
            }

            return veiculos;
        }

        //Método Update
        public void AtualizarDisponibilidade(int id, bool disponivel)
        {
            //conexão com o BD
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            //alterando os dados no BD
            var cmd = new NpgsqlCommand("UPDATE veiculos SET disponivel = @disponivel WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("disponivel", disponivel);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
