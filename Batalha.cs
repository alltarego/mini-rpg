namespace MiniRPG
{
    // Classe que gerencia o sistema de batalha
    public class Batalha
    {
        private Heroi heroi;
        private Vilao vilao;
        private bool fugiu;

        public Batalha(Heroi heroi, Vilao vilao)
        {
            this.heroi = heroi;
            this.vilao = vilao;
            this.fugiu = false;
        }

        public bool Iniciar()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║          BATALHA INICIADA!             ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine($"\n{heroi.Nome} encontrou {vilao.Nome}!");
            
            Thread.Sleep(1500);

            while (heroi.EstaVivo && vilao.EstaVivo && !fugiu)
            {
                ExibirStatusBatalha();
                ExecutarTurnoJogador();

                if (!vilao.EstaVivo || fugiu) break;

                ExecutarTurnoInimigo();
            }

            return FinalizarBatalha();
        }

        private void ExibirStatusBatalha()
        {
            Console.WriteLine("\n" + new string('═', 50));
            Console.WriteLine($"{heroi.Nome}: {heroi.Vida}/{heroi.VidaMaxima} HP");
            Console.WriteLine($"{vilao.Nome}: {vilao.Vida}/{vilao.VidaMaxima} HP");
            Console.WriteLine(new string('═', 50));
        }

        private void ExecutarTurnoJogador()
        {
            Console.WriteLine("\n[SEU TURNO]");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Usar Item");
            Console.WriteLine("3. Fugir");
            Console.Write("\nEscolha sua ação: ");

            string? escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    AtacarInimigo();
                    break;
                case "2":
                    UsarItemBatalha();
                    break;
                case "3":
                    TentarFugir();
                    break;
                default:
                    Console.WriteLine("Ação inválida! Você perdeu seu turno.");
                    break;
            }

            Thread.Sleep(1000);
        }

        private void AtacarInimigo()
        {
            int dano = heroi.Atacar();
            vilao.ReceberDano(dano);
            
            Console.WriteLine($"\n{heroi.Nome} atacou {vilao.Nome}!");
            Console.WriteLine($"{vilao.Nome} recebeu {dano} de dano!");

            if (!vilao.EstaVivo)
            {
                Console.WriteLine($"\n*** {vilao.Nome} foi derrotado! ***");
            }
        }

        private void UsarItemBatalha()
        {
            var itens = heroi.Inventario.ObterItens();
            var consumiveis = itens.Where(i => i.Tipo == TipoItem.Consumivel).ToList();

            if (consumiveis.Count == 0)
            {
                Console.WriteLine("Você não possui itens consumíveis!");
                return;
            }

            Console.WriteLine("\n[ITENS DISPONÍVEIS]");
            for (int i = 0; i < consumiveis.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {consumiveis[i].Nome}");
            }

            Console.Write("\nEscolha um item (0 para cancelar): ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= consumiveis.Count)
            {
                heroi.UsarItem(consumiveis[escolha - 1]);
            }
        }

        private void TentarFugir()
        {
            Random random = new Random();
            int chance = random.Next(100);

            if (chance < 50) // 50% de chance de fugir
            {
                Console.WriteLine($"\n{heroi.Nome} fugiu da batalha com sucesso!");
                fugiu = true;
            }
            else
            {
                Console.WriteLine($"\n{heroi.Nome} tentou fugir mas falhou!");
            }
        }

        private void ExecutarTurnoInimigo()
        {
            Console.WriteLine($"\n[TURNO DO {vilao.Nome.ToUpper()}]");
            Thread.Sleep(800);

            int dano = vilao.Atacar();
            heroi.ReceberDano(dano);

            Console.WriteLine($"{vilao.Nome} atacou {heroi.Nome}!");
            Console.WriteLine($"{heroi.Nome} recebeu {dano} de dano!");

            if (!heroi.EstaVivo)
            {
                Console.WriteLine($"\n*** {heroi.Nome} foi derrotado! ***");
            }

            Thread.Sleep(1500);
        }

        private bool FinalizarBatalha()
        {
            Console.WriteLine("\n" + new string('═', 50));

            if (fugiu)
            {
                Console.WriteLine("Você fugiu da batalha!");
                return false;
            }

            if (!heroi.EstaVivo)
            {
                Console.WriteLine("VOCÊ FOI DERROTADO!");
                return false;
            }

            if (!vilao.EstaVivo)
            {
                Console.WriteLine("VITÓRIA!");
                heroi.GanharExperiencia(vilao.ExperienciaRecompensa);

                // Chance de dropar item
                Item? itemDropado = vilao.DroparItem();
                if (itemDropado != null)
                {
                    Console.WriteLine($"\n{vilao.Nome} dropou: {itemDropado.Nome}!");
                    heroi.Inventario.AdicionarItem(itemDropado);
                }

                return true;
            }

            return false;
        }
    }
}