# Halloween Candy Rush

Projeto individual em Unity desenvolvido para a disciplina **Jogos Digitais 2026.1** do **Insper**.

## Sobre o jogo

**Halloween Candy Rush** é um jogo 2D top-down com tema de Halloween.  
O jogador controla uma criança fantasiada que precisa coletar doces pela vizinhança antes que a taxa do tempo cobre seu preço.

O jogo foi pensado como uma experiência arcade:
- fácil de entender
- rápida de jogar
- com tensão crescente
- e dificuldade escalando ao longo da partida

## Como jogar

O objetivo é sobreviver o máximo possível enquanto coleta doces.

### Regras principais
- Doces aparecem aleatoriamente em frente às casas.
- Uma seta aponta na direção do doce atual.
- Cada doce coletado aumenta sua pontuação e sua quantidade de doces.
- O doce desaparece depois de alguns segundos se não for coletado a tempo.
- Existe um cronômetro global.
- Quando esse cronômetro zera, o jogador precisa pagar uma taxa em doces.
- Se não tiver doces suficientes para pagar a taxa, o jogo termina.

### Obstáculos
Ao longo da partida, obstáculos aparecem no mapa e prejudicam o jogador. Existem quatro tipos:
- faz perder 1 doce
- reduz o tempo restante do doce atual
- reduz o tempo restante do cronômetro global
- deixa o jogador lento por alguns segundos

A dificuldade aumenta progressivamente conforme a pontuação sobe.

## Controles

### Teclado
- **WASD** ou **Setas**: mover o personagem

### Controle
O jogo utiliza movimentação baseada em input horizontal/vertical e possui suporte a gamepad compatível com movimentação por analógico/direcional.

## Funcionalidades implementadas

- movimentação 2D top-down
- câmera seguindo o jogador
- sistema de coleta de doces
- cronômetro global e cronômetro do doce
- sistema de taxa periódica
- obstáculos com efeitos diferentes
- seta indicadora do doce atual
- HUD com informações da partida
- menu inicial
- tela de game over
- sistema de recorde (high score)
- persistência de recorde entre sessões com `PlayerPrefs`
- áudio de menu, gameplay, coleta e obstáculos

## Tecnologias utilizadas

- **Unity**
- **C#**
- **TextMeshPro**

## Estrutura do projeto

As principais pastas do projeto são:

- `Assets/_Scripts` → scripts em C#
- `Assets/Art` → sprites e imagens
- `Assets/Audio` → músicas e efeitos sonoros
- `Assets/Prefabs` → prefabs utilizados no jogo
- `Assets/Scenes` → cenas do menu e gameplay

## Créditos

### Imagens
Todas as imagens são imagens licenciáveis retiradas diretamente do Google.

### Áudios
- Todos os áudios foram retirados diretamente do Pixabay de forma gratuita;
- Música do Menu: Halloween Track by Soundore. Free Music Archive. Licença CC BY-ND.
- Música do Menu: Halloween Free Music by Soundore. Free Music Archive. Licença CC BY-ND.

## Autor

**Gustavo Nicacio Aydelkop**

## Link do jogo

Adicione aqui o link do projeto no itch.io quando ele estiver publicado.

## Observações

Este projeto foi desenvolvido com fins acadêmicos para a disciplina de Jogos Digitais.  