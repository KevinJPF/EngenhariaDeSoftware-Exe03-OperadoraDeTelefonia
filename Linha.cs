using System;
using System.Linq;
using System.Collections.Generic;

public class Linha
{
    // Simula um "select" de um banco de dados
    public List<ModeloLinhas> ListarLinhas(BancoDeDados bancoDeDados)
    {
        return bancoDeDados.ListarLinhas();
    }

    // Simula um "select" de um banco de dados por codigo
    public ModeloLinhas ListarLinhaPorCodigo(BancoDeDados bancoDeDados, int codigoLinha)
    {
        return bancoDeDados.ListarLinhaPorCodigo(codigoLinha);
    }

    // Simula um "insert" de um banco de dados
    public BancoDeDados CriarLinha(BancoDeDados bancoDeDados, ModeloLinhas novaLinha)
    {
        return bancoDeDados.CadastrarLinha(novaLinha);
    }
}