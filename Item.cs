namespace MiniRPG
{
    // Enumeração dos tipos de itens
    public enum TipoItem
    {
        Consumivel,
        Equipamento,
        Material
    }

    // Classe que representa itens do jogo
    public class Item
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoItem Tipo { get; set; }
        public int BonusVida { get; set; }
        public int BonusAtaque { get; set; }
        public int BonusDefesa { get; set; }
        public bool Consumivel { get; set; }

        public Item(string nome, string descricao, TipoItem tipo)
        {
            Nome = nome;
            Descricao = descricao;
            Tipo = tipo;
            BonusVida = 0;
            BonusAtaque = 0;
            BonusDefesa = 0;
            Consumivel = tipo == TipoItem.Consumivel;
        }

        public void Usar(Heroi heroi)
        {
            switch (Tipo)
            {
                case TipoItem.Consumivel:
                    if (BonusVida > 0)
                    {
                        heroi.Curar(BonusVida);
                        Console.WriteLine($"{heroi.Nome} recuperou {BonusVida} pontos de vida!");
                    }
                    break;

                case TipoItem.Equipamento:
                    Console.WriteLine($"{heroi.Nome} equipou {Nome}!");
                    break;

                case TipoItem.Material:
                    Console.WriteLine($"{Nome} é um material de forja.");
                    break;
            }
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine($"\n[{Nome}]");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Descrição: {Descricao}");
            if (BonusVida > 0) Console.WriteLine($"  +{BonusVida} Vida");
            if (BonusAtaque > 0) Console.WriteLine($"  +{BonusAtaque} Ataque");
            if (BonusDefesa > 0) Console.WriteLine($"  +{BonusDefesa} Defesa");
        }
    }
}