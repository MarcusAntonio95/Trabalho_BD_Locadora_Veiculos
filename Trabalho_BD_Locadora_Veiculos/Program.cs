using System;
using System.Collections.Generic;
using Trabalho_BD_Locadora_Veiculos;

class Program
{
    static void Main()
    {
        var repositorio = new CRU_veiculo();


        Console.WriteLine("=== Cadastro de Novo Veículo ===");

        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();

        Console.Write("Marca: ");
        string marca = Console.ReadLine();

        Console.Write("Ano: ");
        int ano;
        while (!int.TryParse(Console.ReadLine(), out ano))
        {
            Console.Write("Ano inválido. Digite um número válido: ");
        }

        Console.Write("Disponível (s/n): ");
        string disponivelInput = Console.ReadLine().ToLower();
        bool disponivel = disponivelInput == "s" || disponivelInput == "sim";

        // Create
        var novoVeiculo = new Veiculo()
        {
            Modelo = modelo,
            Marca = marca,
            Ano = ano,
            Disponivel = disponivel
        };
        repositorio.AdicionarVeiculo(novoVeiculo);
        Console.WriteLine("Veículo adicionado com sucesso!");

        // Read
        var veiculos = repositorio.ListarVeiculos();
        Console.WriteLine("Lista de veículos:");
        foreach (var v in veiculos)
        {
            Console.WriteLine($"ID: {v.Id} | Modelo: {v.Modelo} | Marca: {v.Marca} | Ano: {v.Ano} | Disponível: {v.Disponivel}");
        }

        // Update
        Console.WriteLine("Atualizando disponibilidade do veículo com ID 1 para 'false'...");
        repositorio.AtualizarDisponibilidade(1, false);
        Console.WriteLine("Atualização feita com sucesso.");
    }
}

