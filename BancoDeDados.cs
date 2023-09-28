using System;
using System.Linq;
using System.Collections.Generic;

// Classe criada para simular um banco de dados
public class BancoDeDados 
{
  // Cria listas que simulam tabelas em um "banco de dados" para armazenar os dados
  public List<ModeloPlanos> tabelaPlanos { get; set; }
  public List<ModeloTelefones> tabelaTelefones { get; set; }
  public List<ModeloLinhas> tabelaLinhas { get; set; }

  // Instancias das "tabelas do banco"
  public BancoDeDados() 
  {
    tabelaPlanos = new List<ModeloPlanos>();
    tabelaTelefones = new List<ModeloTelefones>();
    tabelaLinhas = new List<ModeloLinhas>();
  }

  // Planos
  public List<ModeloPlanos> ListarPlanos()
  {
      return tabelaPlanos;
  }
  
  public ModeloPlanos ListarPlanoPorCodigo(int codigoPlano)
  {
      return tabelaPlanos.Where(plano => plano.codigo.Equals(codigoPlano)).First();
  }

  public BancoDeDados CadastrarPlano(ModeloPlanos novoPlano)
  {
      // Simulacao de 'auto-increment' do banco de dados
      novoPlano.codigo = tabelaPlanos.Count + 1;

      // Simulacao de 'insert' do banco de dados
      tabelaPlanos.Add(novoPlano);

      return this;
  }

  // Linhas Telefonicas
  public List<ModeloLinhas> ListarLinhas()
  {
      return tabelaLinhas;
  }

  public ModeloLinhas ListarLinhaPorCodigo(int codigoLinha)
  {
      return tabelaLinhas.Where(plano => plano.codigo.Equals(codigoLinha)).First();
  }

  public BancoDeDados CadastrarLinha(ModeloLinhas novaLinha)
  {
      // Simulacao de 'auto-increment' do banco de dados
      novaLinha.codigo = tabelaLinhas.Count + 1;

      // Simulacao de 'insert' do banco de dados
      tabelaLinhas.Add(novaLinha);

      return this;
  }

  // Telefones
  public List<ModeloTelefones> ListarTelefones()
  {
      return tabelaTelefones;
  }

  public ModeloTelefones ListarTelefonePorCodigo(int codigoTelefone)
  {
      return tabelaTelefones.Where(plano => plano.codigo.Equals(codigoTelefone)).First();
  }

  public BancoDeDados CadastrarTelefone(ModeloTelefones novoTelefone)
  {
      // Simulacao de 'auto-increment' do banco de dados
      novoTelefone.codigo = tabelaTelefones.Count + 1;

      // Simulacao de 'insert' do banco de dados
      tabelaTelefones.Add(novoTelefone);

      return this;
  }
}