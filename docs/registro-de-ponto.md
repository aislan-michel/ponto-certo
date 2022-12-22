Como funciona o registro de ponto?

* O colaborador efetua o login no sistema.
* Clica no botão registrar ponto.
* O botão registrar ponto será desabilitado, e um aviso de processamento exibido.
* O sistema ira carregar a data e hora atual do fuso horario brasileiro de brasilia.
* Este _timespan_ será computado, relacionado ao colaborador em questão e salvo na base de dados.
* O padrão a ser persistido deve ser "yyyy-MM-dd HH:mm:ss".
* Deve ser exibido um _pop-up_ informando o resultado da operação.
* Após clicar no botão, a tela será recarregada.


Regras:

* Há um intervalo minimo de 1h entre as marcações.
  * Esse intervalo pode ser alterado pela empresa.

Usuários

Há 2 tipos (?) de usuários:

1. Quem registra o ponto.
2. Quem gerencia o ponto.

Os provaveis cargos (?) que se encaixam no segundo tipo são: gestores, diretores, líderes, gerentes, profissionais de rh e departamento pessoal, sócios e proprietarios
Enquanto os provaveis cargos (?) a se encaixar no primeiro tipo são: todo resto


E se o colaborador x for mandado embora?
* Vamos guardar histórico, ou seja, o colaborar terá um status sendo eles:
  1. Em exercicio
  2. Férias
  3. Demitido por justa causa
    3.1 nesse caso, é possivel informa a causa
  4. Demitido sem justa causa
  5. Afastado

Como funciona o cadastro da empresa?
* A impresa irá preencher um formulário, será gerado um login e os dados persistidos.