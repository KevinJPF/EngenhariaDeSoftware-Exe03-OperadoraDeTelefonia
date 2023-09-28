using System;
using System.Collections.Generic;

class TelecomSP
{
    // Cria uma instancia da classe BancoDeDados para simular um banco de dados
    private static BancoDeDados bancoDeDados = new BancoDeDados();

    public static void Main(string[] args)
    {
        bool continua = true;

        Console.WriteLine("Bem vindo a TelecomSP, sua nova operadora de telefonia.");

        do
        {
            switch (Menu())
            {
                case 0:
                    continua = false;
                    break;
                case 1:
                    ListarLinhasCadastradas();
                    break;
                case 2:
                    CadastrarLinhaTelefonica();
                    break;
                case 3:
                    ListarPlanosCadastrados(true);
                    break;
                case 4:
                    CadastrarPlano();
                    break;
                case 5:
                    ListarTelefonesCadastrados(true);
                    break;
                case 6:
                    CadastrarTelefone();
                    break;
                default:
                    break;
            }
            Console.Clear();
        } while (continua);

        Console.WriteLine("Obrigado por confiar na TelecomSP, ate a proxima.\n");
    }

    private static int Menu()
    {
        int opcaoSelecionada = 0;

        Console.WriteLine("\n|Menu de Opcoes - TelecomSP|");
        Console.WriteLine("\n1 - Listar Linhas Cadastradas.");
        Console.WriteLine("2 - Cadastrar Nova Linha.");
        Console.WriteLine("3 - Listar Planos Cadastrados.");
        Console.WriteLine("4 - Cadastrar Novo Plano.");
        Console.WriteLine("5 - Listar Telefones Cadastrados.");
        Console.WriteLine("6 - Cadastrar Novo Telefone.");
        Console.WriteLine("0 - Sair do SmartFixConsole.\n");

        opcaoSelecionada = ValidarValorInteiro();
        Console.Clear();

        return opcaoSelecionada;
    }

    private static void ListarLinhasCadastradas()
    {
        var listaLinhas = new Linha().ListarLinhas(bancoDeDados);
        if (listaLinhas.Count > 0)
        {
            int opcaoSelecionada = 0;
            do
            {
                Console.WriteLine("\n|Lista de Linhas Cadastradas - TelecomSP|\n");

                for (int i = 0; i < listaLinhas.Count; i++)
                {
    
                    var linhaAtual = listaLinhas[i];

                    int codigoLinha = linhaAtual.codigo;
                    var telefone = new Telefone().ListarTelefonePorCodigo(bancoDeDados, linhaAtual.codigoTelefone);
                    var plano = new Plano().ListarPlanoPorCodigo(bancoDeDados, linhaAtual.codigoPlano);
                    string dataAbertura = linhaAtual.dataAbertura.Date.ToString("dd/MM/yyyy");
    
                    Console.WriteLine($"{codigoLinha} - Telefone: {telefone.NumeroCompleto}.");
                    Console.WriteLine($"Aberta em: {dataAbertura}.");
                    Console.WriteLine($"Plano: {plano.nome}");
                    Console.WriteLine("------------------------------------------------------------------------------\n");
                }
    
                Console.WriteLine("\nDigite o numero correspondente para ver mais detalhes da linha ou pressione qualquer tecla para voltar ao menu.\n");
                if (int.TryParse(Console.ReadLine(), out opcaoSelecionada))
                {
                    Console.Clear();
                    if (opcaoSelecionada > 0 && opcaoSelecionada <= listaLinhas.Count)
                      ListarDetalhesLinha(opcaoSelecionada); 
                }
            } while (opcaoSelecionada > 0 && opcaoSelecionada <= listaLinhas.Count);
        }
        else
        {
            Console.WriteLine("\nNao ha nenhuma linha telefonica cadastrada.\nPressione qualquer tecla para voltar ao menu.\n");
            Console.ReadKey();
        }
    }

    private static void ListarDetalhesLinha(int codigoLinha)
    {
        var linhaAtual = new Linha().ListarLinhaPorCodigo(bancoDeDados, codigoLinha);
      
        var telefone = new Telefone().ListarTelefonePorCodigo(bancoDeDados, linhaAtual.codigoTelefone);
        var plano = new Plano().ListarPlanoPorCodigo(bancoDeDados, linhaAtual.codigoPlano);
        string dataAbertura = linhaAtual.dataAbertura.Date.ToString("dd/MM/yyyy");
      
        Console.WriteLine($"Detalhes da linha telefonica:\n");
        Console.WriteLine($"Telefone: {telefone.NumeroCompleto}.");
        Console.WriteLine($"Aberta em: {dataAbertura}.");
        Console.WriteLine($"Plano: {plano.nome} | Valor: R$ {plano.valorIntegral}");
        Console.WriteLine($"Minutos Inclusos: {plano.minutosInclusos} | GB Inclusos: {plano.gbInclusos}");
        Console.WriteLine($"Valor por minuto excedente: R${plano.valorPorMinutoExcedente} \nValor por GB Excedente: R${plano.valorPorGbExcedente}");

        Console.WriteLine("\nPressione qualquer tecla para voltar.\n");
        Console.ReadKey();
        Console.Clear();
    }

    private static void CadastrarLinhaTelefonica()
    {
        bool continua = true;

        do
        {
            Console.WriteLine("Insira os dados necessarios para o cadastro da nova linha telefonica.");

            int codigoTelefone = ListarTelefonesCadastrados(false);
            Console.Clear();

            if (codigoTelefone == 0) return;
          
            int codigoPlano = ListarPlanosCadastrados(false);
            Console.Clear();

            if (codigoPlano == 0) return;
          
            // Cria um objeto modelo com os atributos requeridos
            ModeloLinhas novaLinha = new ModeloLinhas(codigoTelefone, codigoPlano);

            // Envia o banco de dados e o novo objeto para cadastrar e recebe o banco atualizado no banco da main
            bancoDeDados = new Linha().CriarLinha(bancoDeDados, novaLinha);

            Console.WriteLine($"\nLinha telefonica cadastrada com sucesso.");

            Console.WriteLine("\nDeseja criar uma nova linha telefonica? (Sim/Nao) ");

            continua = Console.ReadLine().ToUpper().Contains("S") ? true : false;

            Console.Clear();
        } while (continua);
    }

    private static int ListarPlanosCadastrados(bool apenasListagem)
    {
        var listaPlanos = new Plano().ListarPlanos(bancoDeDados);
        if (listaPlanos.Count > 0)
        {
            Console.WriteLine("\n|Lista de Planos Cadastrados - TelecomSP|\n");

            for (int i = 0; i < listaPlanos.Count; i++)
            {
                var planoAtual = listaPlanos[i];

                int codigo = planoAtual.codigo;
                string nome = planoAtual.nome;
                string valorIntegral = planoAtual.valorIntegral.ToString("N2");
                string minutosInclusos = planoAtual.minutosInclusos.ToString();
                string gbInclusos = planoAtual.gbInclusos.ToString();
                string valorPorMinutoExcd = planoAtual.valorPorMinutoExcedente.ToString("N2");
                string valorPorGbSxcd = planoAtual.valorPorGbExcedente.ToString("N2");

                Console.WriteLine($"{codigo} - {nome} | Valor: R${valorIntegral}");
                Console.WriteLine($"Minutos Inclusos: {minutosInclusos} | GB Inclusos: {gbInclusos}");
                Console.WriteLine($"Valor por minuto excedente: R${valorPorMinutoExcd} \nValor por GB Excedente: R${valorPorGbSxcd}");
                Console.WriteLine("------------------------------------------------------------------------------\n");
            }

            if (apenasListagem)
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.\n");
                Console.ReadKey();
                return 0;
            }
            else
            {
                int opcaoSelecionada;
                Console.WriteLine("Digite o numero correspondente para selecionar o plano:");
                do
                {
                    opcaoSelecionada = ValidarValorInteiro();
                } while (opcaoSelecionada <= 0 && opcaoSelecionada > listaPlanos.Count);
                return opcaoSelecionada;
            }
        }
        else
        {
            Console.WriteLine("\nNao ha nenhum plano cadastrado.\nPressione qualquer tecla para voltar ao menu.\n");
            Console.ReadKey();
            return 0;
        }
    }

    private static void CadastrarPlano()
    {
        bool continua = true;

        do
        {
            Console.WriteLine("Insira os dados necessarios para o cadastro da nova ordem de servico.");

            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Minutos Inclusos: ");
            int minutosInclusos = ValidarValorInteiro();

            Console.WriteLine("GB Inclusos: ");
            int gbInclusos = ValidarValorInteiro();

            Console.WriteLine("Valor Integral: ");
            double valorIntegral = ValidarValorDouble();

            Console.WriteLine("Valor Por Minutos Excedentes: ");
            double valorPorMinutoExcd = ValidarValorDouble();

            Console.WriteLine("Valor Por GBs Excedentes: ");
            double valorPorGbExcd = ValidarValorDouble();

            // Cria um objeto modelo com os atributos requeridos
            ModeloPlanos novoPlano = new ModeloPlanos(nome, minutosInclusos, gbInclusos, valorIntegral, valorPorMinutoExcd, valorPorGbExcd);

            // Envia o banco de dados e o novo objeto para cadastrar e recebe o banco atualizado no banco da main
            bancoDeDados = new Plano().CriarPlano(bancoDeDados, novoPlano);

            Console.WriteLine($"\nPlano ({nome}) cadastrado com sucesso.");

            Console.WriteLine("\nDeseja criar um novo plano? (Sim/Nao) ");

            continua = Console.ReadLine().ToUpper().Contains("S") ? true : false;

            Console.Clear();
        } while (continua);
    }

    private static int ListarTelefonesCadastrados(bool apenasListagem)
    {
        var listaTelefones = new Telefone().ListarTelefones(bancoDeDados);
        if (listaTelefones.Count > 0)
        {
            Console.WriteLine("\n|Lista de Telefones Cadastrados - TelecomSP|\n");

            for (int i = 0; i < listaTelefones.Count; i++)
            {
                var telefoneAtual = listaTelefones[i];

                int codigo = telefoneAtual.codigo;
                string numeroCompleto = telefoneAtual.NumeroCompleto;

                Console.WriteLine($"{codigo} - Telefone: {numeroCompleto}");
                Console.WriteLine("------------------------------------------------------------------------------\n");
            }

            if (apenasListagem)
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.\n");
                Console.ReadKey();
                return 0;
            }
            else
            {
                int opcaoSelecionada;
                Console.WriteLine("Digite o numero correspondente para selecionar o telefone:");
                do
                {
                    opcaoSelecionada = ValidarValorInteiro();
                } while (opcaoSelecionada <= 0 && opcaoSelecionada > listaTelefones.Count);
                return opcaoSelecionada;
            }
        }
        else
        {
            Console.WriteLine("\nNao ha nenhum telefone cadastrado.\nPressione qualquer tecla para voltar ao menu.\n");
            Console.ReadKey();
            return 0;
        }
    }

    private static void CadastrarTelefone()
    {
        bool continua = true;

        do
        {
            Console.WriteLine("Insira os dados necessarios para o cadastro do novo telefone.");

            Console.WriteLine("Codigo de Area(DDD): ");
            int codigoArea = ValidarValorInteiro();

            Console.WriteLine("Numero: ");
            string numero = Console.ReadLine();

            // Cria um objeto modelo com os atributos requeridos
            ModeloTelefones novoTelefone = new ModeloTelefones(codigoArea, numero);

            // Envia o banco de dados e o novo objeto para cadastrar e recebe o banco atualizado no banco da main
            bancoDeDados = new Telefone().CriarTelefone(bancoDeDados, novoTelefone);

            Console.WriteLine($"\nTelefone cadastrado com sucesso.");

            Console.WriteLine("\nDeseja cadastrar um novo telefone? (Sim/Nao) ");

            continua = Console.ReadLine().ToUpper().Contains("S") ? true : false;

            Console.Clear();
        } while (continua);
    }

    private static int ValidarValorInteiro()
    {
        int valorConvertido;

        while (!int.TryParse(Console.ReadLine(), out valorConvertido))
        {
            Console.WriteLine("Valor inserido inválido.");
        }

        return valorConvertido;
    }

    private static double ValidarValorDouble()
    {
        double valorConvertido;

        while (!double.TryParse(Console.ReadLine().Replace(",", "."), out valorConvertido))
        {
            Console.WriteLine("Valor inserido inválido.");
        }

        return valorConvertido;
    }
}