namespace MiniRPG
{
    // Classe que gerencia o inventário do herói
    public class Inventario
    {
        private List<Item> itens;
        private List<Item> equipamentos;
        private const int CapacidadeMaxima = 20;

        public Inventario()
        {
            itens = new List<Item>();
            equipamentos = new List<Item>();
        }

        public bool AdicionarItem(Item item)
        {
            if (itens.Count >= CapacidadeMaxima)
            {
                Console.WriteLine("Inventário cheio! Não é possível adicionar mais itens.");
                return false;
            }

            itens.Add(item);
            Console.WriteLine($"Item '{item.Nome}' adicionado ao inventário!");
            return true;
        }

        public bool RemoverItem(Item item)
        {
            return itens.Remove(item);
        }

        public bool UsarItem(Item item, Heroi heroi)
        {
            if (!itens.Contains(item))
            {
                Console.WriteLine("Item não encontrado no inventário!");
                return false;
            }

            item.Usar(heroi);

            if (item.Consumivel)
            {
                RemoverItem(item);
            }
            else if (item.Tipo == TipoItem.Equipamento)
            {
                EquiparItem(item);
            }

            return true;
        }

        private void EquiparItem(Item item)
        {
            if (!equipamentos.Contains(item))
            {
                equipamentos.Add(item);
                Console.WriteLine($"{item.Nome} foi equipado!");
            }
        }

        public int CalcularBonusAtaque()
        {
            return equipamentos.Sum(e => e.BonusAtaque);
        }

        public int CalcularBonusDefesa()
        {
            return equipamentos.Sum(e => e.BonusDefesa);
        }

        public void ExibirInventario()
        {
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║            INVENTÁRIO                  ║");
            Console.WriteLine("╠════════════════════════════════════════╣");

            if (itens.Count == 0)
            {
                Console.WriteLine("║  Inventário vazio                      ║");
            }
            else
            {
                for (int i = 0; i < itens.Count; i++)
                {
                    string linha = $"║  {i + 1}. {itens[i].Nome,-34} ║";
                    Console.WriteLine(linha);
                }
            }

            Console.WriteLine($"║  Espaço: {itens.Count}/{CapacidadeMaxima,-27} ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            if (equipamentos.Count > 0)
            {
                Console.WriteLine("\n[EQUIPAMENTOS ATIVOS]");
                foreach (var eq in equipamentos)
                {
                    Console.WriteLine($"  • {eq.Nome}");
                }
            }
        }

        public List<Item> ObterItens()
        {
            return new List<Item>(itens);
        }

        public List<Item> ObterMateriais()
        {
            return itens.Where(i => i.Tipo == TipoItem.Material).ToList();
        }
    }
}