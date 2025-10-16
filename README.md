# 🎮 Mini RPG - Aventura Épica

## Descrição
Jogo de RPG em console desenvolvido em C# onde o jogador controla um herói que enfrenta vilões em batalhas épicas através de múltiplas fases. O projeto demonstra programação orientada a objetos e trabalho colaborativo com Git/GitHub.

## Objetivo do Projeto
Este projeto foi desenvolvido para demonstrar:
- **Trabalho colaborativo** usando Git e GitHub
- **Organização de código** em múltiplas classes
- **Uso de branches** para desenvolvimento em equipe

## Estrutura de Desenvolvimento com Git/GitHub

### Divisão de Trabalho (Branches)
O projeto foi dividido em quatro áreas principais, cada uma desenvolvida em uma branch separada:


### Fluxo de Trabalho Git Recomendado

bash
# 1. Clonar o repositório
git clone <url-do-repositorio>
cd MiniRPG

# 2. Criar sua branch de desenvolvimento
git checkout -b feature/sua-funcionalidade

# 3. Fazer alterações e commits
git add .
git commit -m "Descrição clara das alterações"

# 4. Enviar para o repositório remoto
git push origin feature/sua-funcionalidade

# 5. Criar Pull Request no GitHub para revisão

# 6. Após aprovação, fazer merge na branch main
git checkout main
git merge feature/sua-funcionalidade
git push origin main

## 🎮 Mecânicas do Jogo

### Sistema de Combate
- Batalhas por turnos contra vilões
- Opções: Atacar, Usar Item ou Fugir
- Ataques críticos e variação de dano
- Sistema de defesa que reduz dano recebido

### Sistema de Progressão
- Sistema de níveis e experiência (XP)
- Atributos aumentam ao subir de nível
- 4 fases com dificuldade crescente
- Boss final desafiador

### Sistema de Itens
- **Consumíveis**: Poções que restauram vida
- **Equipamentos**: Armas e armaduras que aumentam atributos
- **Materiais**: Itens para forja (sistema em desenvolvimento)
- Inventário com capacidade de 20 itens

### Fases do Jogo
1. **Floresta Sombria** - Goblin e Lobo Selvagem
2. **Caverna Profunda** - Morcego Gigante e Aranha Venenosa
3. **Ruínas Antigas** - Esqueletos Guerreiros
4. **Torre do Mago Sombrio** - Boss Final

## Estrutura do Projeto

MiniRPG/
├── Program.cs              # Ponto de entrada do programa
├── GeralJogo.cs           # Gerenciador principal do jogo
├── OrganizadorTelas.cs    # Organização de interface
│
├── Personagens/
│   ├── Personagem.cs      # Classe base abstrata
│   ├── Heroi.cs          # Herói jogável
│   └── Vilao.cs          # Inimigos
│
├── Sistema de Batalha/
│   ├── Batalha.cs        # Lógica de combate
│   └── Fase.cs           # Gerenciamento de fases
│
├── Sistema de Itens/
│   ├── Item.cs           # Definição de itens
│   ├── Inventario.cs     # Gerenciamento de inventário
│   └── Forja.cs          # Sistema de forja
│
├── MiniRPG.csproj        # Configuração do projeto
└── README.md             # Este arquivo

## Conceitos de Programação Demonstrados

### Orientação a Objetos
- **Herança**: `Heroi` e `Vilao` herdam de `Personagem`
- **Polimorfismo**: Método `Atacar()` sobrescrito nas classes filhas
- **Encapsulamento**: Propriedades privadas com getters/setters
- **Abstração**: Classe base `Personagem` é abstrata

### Boas Práticas
- Separação de responsabilidades (cada classe tem um propósito)
- Código modular e reutilizável
- Comentários explicativos
- Nomenclatura clara e descritiva

## Aprendizados com Git/GitHub

Este projeto ensina:
- Criação e gerenciamento de branches
- Commits com mensagens descritivas
- Push e pull de código
- Merge de branches
- Trabalho colaborativo em equipe

## Comandos Git Essenciais Usados

# Configuração inicial
git config user.name "Seu Nome"
git config user.email "seu@email.com"

# Operações básicas
git status                    # Ver status dos arquivos
git add .                     # Adicionar todos os arquivos
git commit -m "mensagem"      # Fazer commit
git push origin main          # Enviar para repositório remoto
git pull origin main          # Baixar atualizações

# Trabalho com branches
git branch                    # Listar branches
git branch nome-branch        # Criar nova branch
git checkout nome-branch      # Trocar de branch
git merge nome-branch         # Fazer merge de branch

## Como Jogar

1. **Inicie o jogo** e escolha "Nova Aventura"
2. **Digite o nome** do seu herói
3. **Escolha "Continuar Aventura"** para iniciar a primeira fase
4. **Durante batalhas**:
   - Escolha atacar para causar dano
   - Use itens para recuperar vida
   - Fuja se estiver em perigo
5. **Entre batalhas**:
   - Verifique seu status e nível
   - Gerencie seu inventário
   - Descanse para recuperar vida
   - Visite a forja (em desenvolvimento)
6. **Complete todas as 4 fases** para vencer!

## Licença
Projeto educacional desenvolvido para fins de aprendizado de Git/GitHub.
