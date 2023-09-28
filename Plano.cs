using System;
using System.Linq;
using System.Collections.Generic;

public class Plano
{
    // Simula um "select" de um banco de dados
    public List<ModeloPlanos> ListarPlanos(BancoDeDados bancoDeDados)
    {
        return bancoDeDados.ListarPlanos();
    }
  
    // Simula um "select" de um banco de dados por codigo
    public ModeloPlanos ListarPlanoPorCodigo(BancoDeDados bancoDeDados, int codigoPlano)
    {
        return bancoDeDados.ListarPlanoPorCodigo(codigoPlano);
    }
    
    // Simula um "insert" de um banco de dados
    public BancoDeDados CriarPlano(BancoDeDados bancoDeDados, ModeloPlanos novoPlano) 
    {
        return bancoDeDados.CadastrarPlano(novoPlano);
    }
}