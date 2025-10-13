namespace MiniRPG
{
    // Classe que gerencia a forja de itens
    public class Forja
    {
        private Dictionary<string, (List<Item> materiais, Item resultado)> receitas;

        public Forja()
        {
            receitas = new Dictionary<string, (List<Item>, Item)>();
            InicializarReceitas();
        }

        private void InicializarReceitas()
        {
            // Receita: Espada de Ferro
            var espadaFerro = new Item("Espada de Ferro", "Uma espada forjada com ferro puro", TipoItem.Equipamento)
            {
                BonusAtaque = 5
            };

            // Receita: Armadura de Couro
            var armaduraCouro = new Item("Armadura de Couro", "Armadura leve mas resistente", TipoItem.Equipamento)
            {
                BonusDefesa = 4
            };

            // Receita: Poção Grande
            var pocaoGrande = new Item("Poção de Vida Grande", "Restaura 50 pontos de vida", TipoItem.Consumivel)
            {
                BonusVida = 50
            };

            Console.WriteLine("Sistema de forja inicializado com receitas básicas.");
        }

        public void ExibirMenuForja(Heroi heroi)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║              FORJA                     ║");
                Console.WriteLine("╠════════════════════════════════════════╣");
                Console.WriteLine("║  1. Ver Receitas Disponíveis           ║");
                Console.WriteLine("║  2. Forjar Item                        ║");
                Console.WriteLine("║  3. Ver Materiais                      ║");
                Console.WriteLine("║  0. Voltar                             ║");
                Console.WriteLine("╚════════════════════════════════════════╝");

                Console.Write("\nEscolha uma opção: ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ExibirReceitas();
                        break;
                    case "2":
                        ForjarItem(heroi);
                        break;
                    case "3":
                        ExibirMateriais(heroi);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void ExibirReceitas()
        {
            Console.WriteLine("\n[RECEITAS DISPONÍVEIS]");
            Console.WriteLine("1. Espada de Ferro: 3x Ferro + 1x Madeira (+5 Ataque)");
            Console.WriteLine("2. Armadura de Couro: 5x Couro (+4 Defesa)");
            Console.WriteLine("3. Poção Grande: 2x Erva + 1x Cristal (Cura 50 HP)");
        }

        private void ForjarItem(Heroi heroi)
        {
            Console.WriteLine("\n[FORJAR ITEM]");
            Console.WriteLine("Sistema de forja em desenvolvimento...");
            Console.WriteLine("Em breve você poderá combinar materiais para criar itens poderosos!");
        }

        private void ExibirMateriais(Heroi heroi)
        {
            var materiais = heroi.Inventario.ObterMateriais();
            
            Console.WriteLine("\n[MATERIAIS NO INVENTÁRIO]");
            if (materiais.Count == 0)
            {
                Console.WriteLine("Você não possui materiais de forja.");
            }
            else
            {
                foreach (var material in materiais)
                {
                    Console.WriteLine($"  • {material.Nome}");
                }
            }
        }
    }
}