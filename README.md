# Introduction 
Tech Challenge - Fase 1, Curso Arquitetura de sistemas .Net com Azure

O projeto:
- Sistema onde um comércio possa registrar clientes e promoções
	 - Vincular promoções a produtos;
	 - Fidelizar o cliente de acordo com o critério da promoção como se fosse um cartão virtual de fidelidade.
		Ex. Um salão de cabelereiro cria uma promoção em que o cliente ganha um corte grátis a cada "X" vezes que cortar o cabelo.

Nessa fase, o sistema faz:
	- CRUD de "Products" e "Promos", incluindo imagens no Blob;
	- CRUD de "Customers";


# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# Build and Test
 - Navegação baseada no Menu no topo da tela:
	- Products: CRUD de produtos.
		- A criação de um produto possui campos obrigatórios com exceção da imagem, que é opcional e será armazenada no blob;
		- O "Delete" de um produto só acontece no caso de nenhuma promoção estar atrelada ao produto.
	- Promos: CRUD de Promoções.
		- A criação de uma promoção só é iniciada a partir da escolha de um produto já registrado no sistema.
		- A criação de uma promoção possui campos obrigatórios com exceção da imagem, que é opcional e será armazenada no blob;
	- Customer: CRUD de Clientes
		- Não possui vinculo com outras entidades nessa fase do projeto.


 - Teste:
  - Realizar CRUD de "Products", "Promos" e "Customer"
  - Tentar realizar cenários em que se espera o erro, como:
	- Tentar registrar algo com campos incompletos;
	- Tentar deletar produtos atrelados a promoções existentes.

# Contribute
A proxima fase de melhoria consiste em:

 -  Implementar o Identity, onde o usuários responsáveis por Criar/Gerenciar Produtos e Promoções serão autenticados;
 - Vinculação de "Customers" e "Promos";
 - Criação de tela de apresentação das promoções vigentes onde clientes poderão ativamente se participar de promoções;

