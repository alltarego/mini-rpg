namespace MiniRPG
{
    // Classe base para todos os personagens do jogo
    public abstract class Personagem
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int VidaMaxima { get; set; }
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public bool EstaVivo => Vida > 0;

        protected Personagem(string nome, int vida, int ataque, int defesa)
        {
            Nome = nome;
            Vida = vida;
            VidaMaxima = vida;
            Ataque = ataque;
            Defesa = defesa;
        }

        public virtual int Atacar()
        {
            Random random = new Random();
            int dano = Ataque + random.Next(-2, 3); // Variação de -2 a +2
            return Math.Max(1, dano); // Mínimo 1 de dano
        }

        public virtual void ReceberDano(int dano)
        {
            int danoReal = Math.Max(1, dano - Defesa);
            Vida -= danoReal;
            if (Vida < 0) Vida = 0;
        }

        public void Curar(int quantidade)
        {
            Vida += quantidade;
            if (Vida > VidaMaxima) Vida = VidaMaxima;
        }

        public void ExibirStatus()
        {
            Console.WriteLine($"{Nome} - Vida: {Vida}/{VidaMaxima} | Ataque: {Ataque} | Defesa: {Defesa}");
        }
    }
}