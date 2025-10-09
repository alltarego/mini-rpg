namespace MiniRPG
{
    // Classe que representa o herói controlado pelo jogador
    public class Heroi : Personagem
    {
        public int Nivel { get; private set; }
        public int Experiencia { get; private set; }
        public int ExperienciaParaProximoNivel { get; private set; }
        public Inventario Inventario { get; private set; }

        public Heroi(string nome) : base(nome, 100, 15, 5)
        {
            Nivel = 1;
            Experiencia = 0;
            ExperienciaParaProximoNivel = 100;
            Inventario = new Inventario();
        }

        public void GanharExperiencia(int exp)
        {
            Experiencia += exp;
            Console.WriteLine($"\n{Nome} ganhou {exp} pontos de experiência!");

            while (Experiencia >= ExperienciaParaProximoNivel)
            {
                SubirNivel();
            }
        }

        private void SubirNivel()
        {
            Nivel++;
            Experiencia -= ExperienciaParaProximoNivel;
            ExperienciaParaProximoNivel = (int)(ExperienciaParaProximoNivel * 1.5);

            // Aumenta atributos ao subir de nível
            VidaMaxima += 20;
            Vida = VidaMaxima;
            Ataque += 3;
            Defesa += 2;

            Console.WriteLine($"\n*** LEVEL UP! {Nome} agora é nível {Nivel}! ***");
            Console.WriteLine($"Vida Máxima: {VidaMaxima} | Ataque: {Ataque} | Defesa: {Defesa}");
        }

        public override int Atacar()
        {
            // Herói pode ter ataques especiais baseados em itens
            int danoBase = base.Atacar();
            int bonusItens = Inventario.CalcularBonusAtaque();
            return danoBase + bonusItens;
        }

        public void UsarItem(Item item)
        {
            if (Inventario.UsarItem(item, this))
            {
                Console.WriteLine($"{Nome} usou {item.Nome}!");
            }
        }
    }
}