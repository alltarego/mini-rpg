namespace MiniRPG
{
    // Classe responsável por organizar e exibir as telas do jogo
    public static class OrganizadorTelas
    {
        public static void ExibirTitulo()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("║            MINI RPG                    ║");
            Console.WriteLine("║         Aventura Épica                 ║");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
        }

        public static void ExibirMenuPrincipal()
        {
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║          MENU PRINCIPAL                ║");
            Console.WriteLine("╠════════════════════════════════════════╣");
            Console.WriteLine("║  1. Nova Aventura                      ║");
            Console.WriteLine("║  2. Como Jogar                         ║");
            Console.WriteLine("║  3. Créditos                           ║");
            Console.WriteLine("║  0. Sair                               ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
        }

        public static void ExibirComoJogar()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║           COMO JOGAR                   ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("\nBem-vindo ao Mini RPG!");
            Console.WriteLine("\nObjetivo:");
            Console.WriteLine("  • Complete todas as fases derrotando vilões");
            Console.WriteLine("  • Colete itens e melhore seu herói");
            Console.WriteLine("  • Sobreviva até o final!");
            Console.WriteLine("\nMecânicas:");
            Console.WriteLine("  • Batalhas por turnos contra vilões");
            Console.WriteLine("  • Sistema de níveis e experiência");
            Console.WriteLine("  • Inventário para guardar itens");
            Console.WriteLine("  • Forja para criar equipamentos");
            Console.WriteLine("\nDicas:");
            Console.WriteLine("  • Use poções durante batalhas difíceis");
            Console.WriteLine("  • Equipe itens para aumentar seus atributos");
            Console.WriteLine("  • Explore todas as opções disponíveis");
            
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        public static void ExibirCreditos()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║            CRÉDITOS                    ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("\nProjeto desenvolvido para demonstrar:");
            Console.WriteLine("  • Programação Orientada a Objetos em C#");
            Console.WriteLine("  • Trabalho colaborativo com Git/GitHub");
            Console.WriteLine("  • Estruturação de projetos em equipe");
            Console.WriteLine("\nEquipe de Desenvolvimento:");
            Console.WriteLine("  • Desenvolvedor 1 - Classes base e personagens");
            Console.WriteLine("  • Desenvolvedor 2 - Sistema de batalha e fases");
            Console.WriteLine("  • Desenvolvedor 3 - Inventário, itens e forja");
            Console.WriteLine("\nTecnologias:");
            Console.WriteLine("  • C# (.NET 6.0+)");
            Console.WriteLine("  • Git & GitHub");
            Console.WriteLine("  • Console Application");
            
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        public static void ExibirMenuJogo(Heroi heroi)
        {
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║           MENU DO JOGO                 ║");
            Console.WriteLine("╠════════════════════════════════════════╣");
            Console.WriteLine("║  1. Continuar Aventura                 ║");
            Console.WriteLine("║  2. Ver Status                         ║");
            Console.WriteLine("║  3. Inventário                         ║");
            Console.WriteLine("║  4. Forja                              ║");
            Console.WriteLine("║  5. Descansar (Recuperar Vida)         ║");
            Console.WriteLine("║  0. Voltar ao Menu Principal           ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
        }

        public static void ExibirGameOver()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("║            GAME OVER                   ║");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("║      Você foi derrotado...             ║");
            Console.WriteLine("║      Tente novamente!                  ║");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            
            Thread.Sleep(3000);
        }

        public static void ExibirVitoria()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("║          PARABÉNS!                     ║");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("║    Você completou todas as fases!      ║");
            Console.WriteLine("║      Você é um verdadeiro herói!       ║");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            
            Thread.Sleep(3000);
        }

        public static void ExibirMensagem(string mensagem)
        {
            Console.WriteLine($"\n{mensagem}");
        }

        public static void Pausar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public static void LimparTela()
        {
            Console.Clear();
        }
    }
}
