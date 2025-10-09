namespace MiniRPG
{
    // Classe que representa uma fase do jogo
    public class Fase
    {
        public int Numero { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public List<Vilao> Viloes { get; private set; }
        public List<Item> Recompensas { get; private set; }
        public bool Completa { get; private set; }

        public Fase(int numero, string nome, string descricao)
        {
            Numero = numero;
            Nome = nome;
            Descricao = descricao;
            Viloes = new List<Vilao>();
            Recompensas = new List<Item>();
            Completa = false;
        }

        public void AdicionarVilao(Vilao vilao)
        {
            Viloes.Add(vilao);
        }

        public void AdicionarRecompensa(Item item)
        {
            Recompensas.Add(item);
        }

        public bool Iniciar(Heroi heroi)
        {
            Console.Clear();
            ExibirIntroducao();

            foreach (var vilao in Viloes)
            {
                if (!heroi.EstaVivo)
                {
                    return false;
                }

                Console.WriteLine($"\nPreparando batalha contra {vilao.Nome}...");
                Thread.Sleep(2000);

                Batalha batalha = new Batalha(heroi, vilao);
                bool venceu = batalha.Iniciar();

                if (!venceu)
                {
                    return false;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            Completa = true;
            DistribuirRecompensas(heroi);
            return true;
        }

        private void ExibirIntroducao()
        {
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine($"║  FASE {Numero}: {Nome,-29} ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine($"\n{Descricao}");
            Console.WriteLine($"\nInimigos nesta fase: {Viloes.Count}");
            
            Thread.Sleep(2000);
        }

        private void DistribuirRecompensas(Heroi heroi)
        {
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║        FASE COMPLETA!                  ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            if (Recompensas.Count > 0)
            {
                Console.WriteLine("\nRecompensas obtidas:");
                foreach (var recompensa in Recompensas)
                {
                    heroi.Inventario.AdicionarItem(recompensa);
                    Console.WriteLine($"  • {recompensa.Nome}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

    
    }
}
