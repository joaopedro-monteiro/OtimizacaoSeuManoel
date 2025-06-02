# OtimizacaoSeuManoel.API

[![Docker Hub](https://img.shields.io/badge/Docker%20Hub-joaopedromonteiro%2Fdocker--seu--manoel--app-blue)](https://hub.docker.com/r/joaopedromonteiro/docker-seu-manoel-app)

API para otimização de empacotamento 3D de produtos em caixas utilizando a biblioteca 3DContainerPacking.

## 📦 Sobre o Projeto

Este projeto utiliza a biblioteca [3DContainerPacking](https://github.com/davidmchapman/3DContainerPacking) para resolver problemas de empacotamento tridimensional, com as seguintes características:

- Armazena itens separadamente em cada caixa
- Avalia qual caixa obteve o melhor desempenho no empacotamento
- Considera a rotação dos itens para otimização do espaço
- Seleciona a caixa que melhor aproveita o espaço com o menor número de unidades utilizadas

Esse projeto utiliza uma biblioteca que resolve problemas de empacotamento de produtos em caixas 3D. Porém a biblioteca não realiza todo o trabalho: a biblioteca é capaz de, baseado em uma quantidade de caixas, armazenar separadamente os itens em cada caixa, e o resultado do armazenamento é exclusivo daquela caixa. Para o projeto foram feitas verificações para saber qual caixa obteve o melhor desempenho ao embalar os itens, ou seja, a caixa que teve seu melhor espaço ocupado de uma forma onde o menor número de caixas foi gasto.   

## ⚠️ Observação Importante

A biblioteca considera que os itens podem ser rotacionados, o que resulta em:
- Dimensões dos itens podem variar (mantendo o mesmo volume)
- Possibilidade de itens serem colocados em caixas que aparentemente não os comportariam
- Resultados diferentes de uma abordagem estática sem rotação

**Exemplo Prático:**
- PS5: Altura 40cm × Largura 10cm × Comprimento 25cm
- Caixa 1: Altura 30cm × Largura 40cm × Comprimento 80cm

Na abordagem estática, a Caixa 1 seria descartada (altura do PS5 > altura da caixa). Porém, com rotação, o PS5 pode ser acomodado.

Sendo assim, algoritmo desenvolvido considera essas rotações para armazenar da maneira mais otimizada, acarretando em uma saida.json diferente.

## 🚀 Como Executar

### Pré-requisitos
- Docker Desktop instalado e rodando
- Git instalado

### Instalação
```bash
git clone https://github.com/joaopedro-monteiro/OtimizacaoSeuManoel.git
cd OtimizacaoSeuManoel
docker-compose up -d
```

## Banco de Dados
```
localhost
user: sa
password: ef66b58b-6ff2-4c78-bcec-6b279312b625
```

## 🔐 Autenticação
O sistema utiliza ASP.NET Identity. Siga estes passos:

Observação muito importante: o sistema possui um sistema de autenticação, utilizando Asp.Net Identity, então é necessário que o usuário crie uma conta no endpoint '/register', a senha poderá ser qualquer uma, não há verificação de força da senha, o e-mail também poderá ser qualquer um desde que seja no formato de e-mail.

Note que também existem duas opções: 'useCookies' e 'useSessionCookies', marque como 'true' apenas a 'useCookies', dessa maneira a aplicação registra o token no cookie do seu navegador e ao fazer uma requisição para o end-point '/api/pedidos/embalar' você estará autenticado para acessá-lo

1. Crie uma conta:
```
POST /register
{
  "email": "seu@email.com",
  "password": "suaSenha"
}
```
2. Faça login (remova os campos opcionais):
```
POST /login
{
  "email": "seu@email.com",
  "password": "suaSenha"
}
```

## 📦 Endpoint de Empacotamento
```
POST /api/pedidos/embalar
{
  "pedidos": [
    {
      "pedido_id": 0,
      "produtos": [
        {
          "produto_id": "string",
          "dimensoes": {
            "altura": 0,
            "largura": 0,
            "comprimento": 0
          }
        }
      ]
    }
  ]
}
```

# OtimizacaoSeuManoel.Test

Projeto de testes unitários para a API.

## 🧪 Sobre os Testes

Testes unitários desenvolvidos para validar o algoritmo de empacotamento da aplicação, utilizando:

- **XUnit** como framework de testes
- **Casos de teste** representativos:
  - Pedido 1: Caso básico de empacotamento
  - Pedido 5: Caso onde nenhuma das caixas é capaz de embalar o produto
  - Pedido 11: Caso com grande volume de itens (teste de estresse) -> Este caso não está no entrada.json, foi gerado por mim

## 🏗️ Estrutura do Projeto
-Endpoints CRUD para Pedidos e Produtos (demonstração)

-Endpoint especializado /api/pedidos/embalar para cálculo de empacotamento com autenticação necessária

-Classes dedicadas para o endpoint de empacotamento

## 🐳 Docker
```
docker pull joaopedromonteiro/docker-seu-manoel-app
```
