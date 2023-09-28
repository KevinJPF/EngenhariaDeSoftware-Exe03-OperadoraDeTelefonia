using System;
using System.Linq;

public class ModeloPlanos
{
    public int codigo { get; set; }
    public string nome { get; set; }
    public int minutosInclusos { get; set; }
    public int gbInclusos { get; set; }
    public double valorIntegral { get; set; }
    public double valorPorMinutoExcedente { get; set; }
    public double valorPorGbExcedente { get; set; }

    public ModeloPlanos(string nome, int minutosInclusos, int gbInclusos, double valorIntegral, double valorMinutoExcedente, double valorGbExcedente)
    {
        this.nome = nome;
        this.minutosInclusos = minutosInclusos;
        this.gbInclusos = gbInclusos;
        this.valorIntegral = valorIntegral;
        this.valorPorMinutoExcedente = valorMinutoExcedente;
        this.valorPorGbExcedente = valorGbExcedente;
    }
}

public class ModeloLinhas
{
    public int codigo { get; set; }
    public DateTime dataAbertura { get; set; }
    public int codigoTelefone { get; set; }
    public int codigoPlano { get; set; }

    public ModeloLinhas(int codigoTelefone, int codigoPlano)
    {
        dataAbertura = DateTime.Now;
        this.codigoTelefone = codigoTelefone;
        this.codigoPlano = codigoPlano;
    }
}

public class ModeloTelefones
{
    public int codigo { get; set; }
    private string _numero;
    private int _codigoArea;

    public ModeloTelefones(int codigoArea, string numero)
    {
        CodigoArea = codigoArea;
        Numero = numero;
    }

    private int CodigoArea
    {
        get { return _codigoArea; }
        set
        {
            if (value >= 11 && value <= 19)
            {
                _codigoArea = value;
            }
            else
            {
                throw new Exception("DDD fora da area de cobertura.");
            }
        }
    }

    public string NumeroCompleto
    {
        get { return $"({_codigoArea.ToString()}) {_numero}"; }
    }

    private string Numero
    {
        get { return _numero; }
        set
        {
            string valorSemMascara = new string(value.Where(char.IsDigit).ToArray());

            if (valorSemMascara.Length == 9)
            {
                _numero = $"{valorSemMascara.Substring(0, 5)}-{valorSemMascara.Substring(5)}";
            }
            else
            {
                _numero = value;
            }
        }
    }
}