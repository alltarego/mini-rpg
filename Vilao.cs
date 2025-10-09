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
    }
}