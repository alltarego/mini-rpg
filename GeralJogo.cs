namespace MiniRPG
{
    // Classe principal que gerencia o fluxo geral do jogo
    public class GeralJogo
    {
        private Heroi? heroi;
        private List<Fase> fases;
        private int faseAtual;
        private Forja forja;
        private bool jogoAtivo;

        public GeralJogo()
        {
            fases = new List<Fase>();
            faseAtual = 0;
            forja = new Forja();
            jogoAtivo = true;
        }

        public void Iniciar()
        {
            while (jogoAtivo)
            {
                OrganizadorTelas.ExibirTitulo();
                OrganizadorTelas.ExibirMenuPrincipal();

                Console.Write("\nEscolha uma opção: ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        IniciarNovaAventura();
                        break;
                    case "2":
                        OrganizadorTelas.ExibirComoJogar();
                        break;
                    case "3":
                        OrganizadorTelas.ExibirCreditos();
                        break;
                    case "0":
                        jogoAtivo = false;
                        Console.WriteLine("\nObrigado por jogar! Até a próxima aventura!");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private void IniciarNovaAventura()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║        NOVA AVENTURA                   ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            Console.Write("\nDigite o nome do seu herói: ");
            string? nome = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(nome))
            {
                nome = "Aventureiro";
            }

            heroi = new Heroi(nome);
            InicializarFases();
            InicializarItensIniciais();

            Console.WriteLine($"\nBem-vindo, {heroi.Nome}!");
            Console.WriteLine("Sua jornada está prestes a começar...");
            Thread.Sleep(2000);

            ExecutarLoopJogo();
        }

        private void InicializarFases()
        {
            fases.Clear();
            faseAtual = 0;

            // Fase 1: Floresta Sombria
            Fase fase1 = new Fase(1, "Floresta Sombria", 
                "Uma floresta escura onde criaturas perigosas espreitam nas sombras.");
            
            Vilao goblin = new Vilao("Goblin", 30, 8, 2, 50);
            goblin.AdicionarItemDropavel(new Item("Poção Pequena", "Restaura 20 HP", TipoItem.Consumivel) { BonusVida = 20 });
            
            Vilao lobo = new Vilao("Lobo Selvagem", 40, 10, 3, 60);
            lobo.AdicionarItemDropavel(new Item("Couro", "Material de forja", TipoItem.Material));
            
            fase1.AdicionarVilao(goblin);
            fase1.AdicionarVilao(lobo);
            fase1.AdicionarRecompensa(new Item("Espada Curta", "Uma espada básica", TipoItem.Equipamento) { BonusAtaque = 3 });
            
            fases.Add(fase1);

            // Fase 2: Caverna Profunda
            Fase fase2 = new Fase(2, "Caverna Profunda", 
                "Uma caverna úmida habitada por criaturas das trevas.");
            
            Vilao morcego = new Vilao("Morcego Gigante", 35, 12, 2, 55);
            Vilao aranha = new Vilao("Aranha Venenosa", 45, 14, 4, 70);
            aranha.AdicionarItemDropavel(new Item("Cristal", "Material raro de forja", TipoItem.Material));
            
            fase2.AdicionarVilao(morcego);
            fase2.AdicionarVilao(aranha);
            fase2.AdicionarRecompensa(new Item("Armadura Leve", "Proteção básica", TipoItem.Equipamento) { BonusDefesa = 3 });
            
            fases.Add(fase2);

            // Fase 3: Ruínas Antigas
            Fase fase3 = new Fase(3, "Ruínas Antigas", 
                "Ruínas de uma civilização perdida, guardadas por esqueletos guerreiros.");
            
            Vilao esqueleto1 = new Vilao("Esqueleto Guerreiro", 50, 15, 5, 80);
            Vilao esqueleto2 = new Vilao("Esqueleto Arqueiro", 40, 18, 3, 75);
            
            fase3.AdicionarVilao(esqueleto1);
            fase3.AdicionarVilao(esqueleto2);
            fase3.AdicionarRecompensa(new Item("Poção Média", "Restaura 35 HP", TipoItem.Consumivel) { BonusVida = 35 });
            
            fases.Add(fase3);

            // Fase 4: Torre do Mago Sombrio (Boss Final)
            Fase fase4 = new Fase(4, "Torre do Mago Sombrio", 
                "O covil do temível Mago Sombrio, responsável por todo o mal na região.");
            
            Vilao boss = new Vilao("Mago Sombrio", 100, 20, 8, 200);
            boss.AdicionarItemDropavel(new Item("Cajado Místico", "Arma lendária", TipoItem.Equipamento) { BonusAtaque = 10 });
            
            fase4.AdicionarVilao(boss);
            fase4.AdicionarRecompensa(new Item("Coroa do Herói", "Símbolo de vitória", TipoItem.Equipamento) { BonusAtaque = 5, BonusDefesa = 5 });
            
            fases.Add(fase4);
        }

        private void InicializarItensIniciais()
        {
            if (heroi == null) return;

            // Dar alguns itens iniciais ao herói
            heroi.Inventario.AdicionarItem(new Item("Poção Pequena", "Restaura 20 HP", TipoItem.Consumivel) { BonusVida = 20 });
            heroi.Inventario.AdicionarItem(new Item("Poção Pequena", "Restaura 20 HP", TipoItem.Consumivel) { BonusVida = 20 });
        }

        private void ExecutarLoopJogo()
        {
            if (heroi == null) return;

            bool continuarJogando = true;

            while (continuarJogando && heroi.EstaVivo && faseAtual < fases.Count)
            {
                Console.Clear();
                OrganizadorTelas.ExibirMenuJogo(heroi);

                Console.Write("\nEscolha uma opção: ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ContinuarAventura();
                        break;
                    case "2":
                        heroi.ExibirStatusCompleto();
                        OrganizadorTelas.Pausar();
                        break;
                    case "3":
                        heroi.Inventario.ExibirInventario();
                        OrganizadorTelas.Pausar();
                        break;
                    case "4":
                        forja.ExibirMenuForja(heroi);
                        break;
                    case "5":
                        Descansar();
                        break;
                    case "0":
                        continuarJogando = false;
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!");
                        Thread.Sleep(1000);
                        break;
                }
            }

            VerificarFimDeJogo();
        }

        private void ContinuarAventura()
        {
            if (heroi == null || faseAtual >= fases.Count) return;

            Fase faseAtualObj = fases[faseAtual];
            bool sucesso = faseAtualObj.Iniciar(heroi);

            if (sucesso)
            {
                faseAtual++;
            }
            else if (!heroi.EstaVivo)
            {
                OrganizadorTelas.ExibirGameOver();
            }
        }

        private void Descansar()
        {
            if (heroi == null) return;

            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║           DESCANSANDO...               ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            
            Console.WriteLine($"\n{heroi.Nome} encontrou um lugar seguro para descansar.");
            Thread.Sleep(1500);
            
            int vidaRecuperada = heroi.VidaMaxima - heroi.Vida;
            heroi.Curar(vidaRecuperada);
            
            Console.WriteLine($"Vida completamente restaurada! ({heroi.Vida}/{heroi.VidaMaxima} HP)");
            OrganizadorTelas.Pausar();
        }

        private void VerificarFimDeJogo()
        {
            if (heroi == null) return;

            if (!heroi.EstaVivo)
            {
                OrganizadorTelas.ExibirGameOver();
            }
            else if (faseAtual >= fases.Count)
            {
                OrganizadorTelas.ExibirVitoria();
                Console.WriteLine($"\n{heroi.Nome} completou a jornada!");
                heroi.ExibirStatusCompleto();
                OrganizadorTelas.Pausar();
            }
        }
    }
}
