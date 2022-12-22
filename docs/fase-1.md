Pra que serve o sistema?
* Para que empresas possam ter a gestão do registro de ponto de seus colaboradores.

Quem usa o sistema?
* Empresas e colaboradores

Quais as principais funcionalidades?

* É necessário que a empresa possa:
  1. Efetuar cadastro e login.
  2. Visualizar a lista de colaboradores.
  3. Cadastrar, editar e visualizar 1 colaborador por vez.
  4. Cadastrar uma lista de colaboradores via planilha csv ou excel.
  5. Ativar e inativar o acesso de 1 colaborador.
  6. Alterar senha.

* É necessário que o colaborador possa:
  1. Efetuar login, suas credenciais de acesso serão enviadas por e-mail.
  2. Efetuar o registro de ponto.
  3. Visualizar o histórico de registros de ponto.
  4. Alterar senha.

Quais dados serão coletados da Empresa?

* Nome ou Razão Social
* CNPJ
* Endereço (logradouro, número, bairro, cidade, estado)
* Quantidade de funcionários
* E-mail(s) para notificações
* Segmento (tecnologia, finanças, agro...)

Quais outros dados podem ser fornecidos pela empresa?

* Intervalo entre os registros de ponto, o padrão é de 1h. 
  * É possivel zerar esse tempo.

Quais dados serão coletados do colaborador?

* Nome e sobrenome
* Data de nascimento
* E-mail para notificações
* Qual empresa pertence

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