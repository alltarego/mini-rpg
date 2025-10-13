namespace MiniRPG
{
    // Classe que representa os vilões/inimigos do jogo
    public class Vilao : Personagem
    {
        public int ExperienciaRecompensa { get; private set; }
        public List<Item> ItensDropaveis { get; private set; }

        public Vilao(string nome, int vida, int ataque, int defesa, int expRecompensa) 
            : base(nome, vida, ataque, defesa)
        {
            ExperienciaRecompensa = expRecompensa;
            ItensDropaveis = new List<Item>();
        }

        public void AdicionarItemDropavel(Item item)
        {
            ItensDropaveis.Add(item);
        }

        public Item? DroparItem()
        {
            if (ItensDropaveis.Count == 0) return null;

            Random random = new Random();
            // 60% de chance de dropar um item
            if (random.Next(100) < 60)
            {
                int index = random.Next(ItensDropaveis.Count);
                return ItensDropaveis[index];
            }

            return null;
        }

        public override int Atacar()
        {
            // Vilões podem ter ataques mais agressivos
            Random random = new Random();
            int dano = base.Atacar();
            
            // 20% de chance de ataque crítico
            if (random.Next(100) < 20)
            {
                dano = (int)(dano * 1.5);
                Console.WriteLine($"{Nome} realizou um ATAQUE CRÍTICO!");
            }

            return dano;
        }
    }
}