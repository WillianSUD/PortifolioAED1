'''
                Até 5 Kg                Acima de 5 Kg
File Duplo      R$ 4,90 por Kg          R$ 5,80 por Kg
Alcatra         R$ 5,90 por Kg          R$ 6,80 por Kg
Picanha         R$ 6,90 por Kg          R$ 7,80 por Kg

Para atender a todos os clientes, cada cliente poderá levar apenas um dos tipos de carne da promoção, porém não há limites para a quantidade de carne por cliente. Se compra for feita no cartão Tabajara o cliente receberá ainda um desconto de 5% sobre o total da compra. Escreva um programa que peça o tipo e a quantidade de carne comprada pelo usuário e gere um cupom fiscal, contendo as informações da compra: tipo e quantidade de carne, preço total, tipo de pagamento, valor do desconto e valor a pagar.

'''
produtos= {'001': ('file duplo', 4.90, 5.8), '002': ('alcatra', 5.9, 6.8), '003': ('picanha', 6.9, 7.8)}
formas_pagamento = {1: 'dinheiro', 2: 'cartao tabajara'}
desconto = 0
total = 0
#produto = '001'
#kg = 5.0
#pagamento = 1
produto = input('''
Informe codigo do produto:
001: File Duplo
002: Alcatra
003: Picanha: 

''')
kg = float(input('\nInforme quantidade em kg: ').replace(',','.'))
carne = produtos[produto][0]
pagamento = int(input('''
\nInforme codigo de pagamento: 
1 - Dinheiro
2 - Cartao Tabajara:

'''))
pag = formas_pagamento[pagamento]
if produto in produtos:
  if kg <= 5:
    temp = produtos[produto][1]
    total = kg*temp
  else:
    temp = produtos[produto][2]
    total = kg*temp
if pagamento in formas_pagamento:
  if pag == 'cartao tabajara':
    desconto = 0.05
  else:
    desconto = 0.00
else:
  print('Forma de pagamento não informada ou invalida\n')
total_desc = total - (total*desconto)

print('''
Cupom Fiscal

Tipo de carne: {}  
Preço Unitario: R$ {:.2f}
Quantidade(kg): {}
Forma de Pagamento: {}
Total Bruto: R$ {:.2f}
Desconto: R$ {:.2f}
Total com Desconto: R$ {:.2f}
'''.format(carne, temp, kg, pag, total, desconto, total_desc).title())
