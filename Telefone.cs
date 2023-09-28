using System;
using System.Collections.Generic;

public class Telefone
{
    // Simula um "select" de um banco de dados
    public List<ModeloTelefones> ListarTelefones(BancoDeDados bancoDeDados)
    {
        return bancoDeDados.ListarTelefones();
    }

    // Simula um "select" de um banco de dados por codigo
    public ModeloTelefones ListarTelefonePorCodigo(BancoDeDados bancoDeDados, int codigoTelefone)
    {
        return bancoDeDados.ListarTelefonePorCodigo(codigoTelefone);
    }

    // Simula um "insert" de um banco de dados
    public BancoDeDados CriarTelefone(BancoDeDados bancoDeDados, ModeloTelefones novoTelefone)
    {
        return bancoDeDados.CadastrarTelefone(novoTelefone);
    }
}