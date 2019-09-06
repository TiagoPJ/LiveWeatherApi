# Aplicativo para visualização da Previsão do Tempo

### OpenWeather API (https://openweathermap.org)

Projeto final possuí 2 API `ASP.NETCore (Sdk .NET Core 2.2)`, conforme descrição abaixo:

### LiveWeather

Esta API possuí 2 endpoint's:

######  1° "GetCitiesDefault" tem como objetivo retornar por default 3 cidades (Porto Alegre, Florianópolis e Curitiba).
######  2° "GetWeatherForecast" tem como objetivo retornar a previsão do tempo de acordo com o filtro informado.

### WebSite

Esta SPA simples é um extra feita em React aonde a mesma consome a API LiveWeather para retorno das informações na tela.

## Como rodar

### dotnet run

Basta abrir um terminal para cada projeto listado abaixo e executar os comandos: `dotnet run` para rodar aplicação.

###### `./LiveWeatherApi/WebSite`
###### `./LiveWeatherApi/LiveWeather/Api`

### IISExpress (Caso tenha problema com o dotnet run)

Basta abrir as solutions dos projetos no VS2017 e executar as mesmas.

Após estes processos agora basta acessar o endereço local `http://localhost:5001` que a SPA estará rodando,
posteriormente acessando a porta 5002 é possivel ver o Swagger da aplicação `LiveWeather`.

Swagger LiveWeather API

```
http://localhost:5002/swagger/index.html
```

## Testes da Aplicação LiveWeather API

##### LiveWeatherApiMSTest

O teste unitário das API foi desenvolvido com o framework <b>MSTest</b>.


## Perguntas Técnicas

1 - Quanto tempo você usou para completar a solução apresentada? O que você faria se tivesse mais tempo?
	 
	Trabalhei no projeto do dia (02/09 - 03/09 - 05/09 e 06/09) a noite em vista do compromisso com o trabalho atual. 
  Abaixo segue uns pontos caso tivesse mais tempo:
  
	- Melhoria no design da aplicação UX
	- Página de erros (404)
	- Refactoring
	- Buscar outras informações da API openweathermap.org
	- Projeto de teste melhorado utilizando uma ferramenta como Selenium

2 - Se usou algum framework javascript ou c#, qual foi o motivo de ter usado este?
Caso contrário, por que não utilizou nenhum?

	Utilizei o React, por ser uma tendência atual de mercado e estar aprimorando meu conhecimento com o mesmo,
  também utilizei o 'reactstrap' para layout e componentes, 'moment' para formatação das datas,
  'Flatpickr' para o calendário na seleção das datas e o <br /> 'axios' para chamada da Api LiveWeather.

3 - Descreva você mesmo utlizando json.

{  
   "pessoa":{  
      "nome":"Tiago Pereira de Jesus",
      "idade":31,
	  "sexo":"Masculino",
	  "data_nascimento":"26-08-1988",
	  "naturalidade":"Porto Alegre - RS",
	  "cidade":"Viamão -RS",
	  "estado_civil":"Casado",
	  "conjuge": {
				"nome":"Nathalia Bilhao",
				"idade":"29"
	   },
	  "filhos":[
			{
				"nome":"Charlote",
				"idade":"2 anos e 4 meses",
				"obs": "É uma linda Pug"
			},
			{
				"nome":"Marina",
				"idade":"5 Meses",
				"obs": "Chegando ao mundo, em formação"
			}
		]
   },
   "educacao":{
	   "cursos":[
			{
				"tipo":"técnico",
				"nome_curso":"Técnico em Informática",
				"instituicao":"Escola Técnica Alcides Maya"
			},
			{
				"tipo":"técnico",
				"nome_curso":"Espcialização Web",
				"instituicao":"Escola Técnica Alcides Maya"
			},
			{
				"tipo":"graduação",
				"nome_curso":"Sistemas Para Internet",
				"instituicao":"Faculdade de Tecnologia Pastor Dohms"
			},
			{
				"tipo":"pós_graduação",
				"nome_curso":"Gestão de Projetos com ênfase em TI",
				"instituicao":"Faculdade de Tecnologia Pastor Dohms"
			}
		]
	},
	"top1qualidade":{
		"qualidade":"Honestidade"
	},
	"top1defeitos":{
		"defeito":"Confiar demais nos outros"
	},
	"experiencias":{
		"profissional":[
			{
				"nome_empresa":"Mumbai Produtora Web",
				"cargo":"Desenvolvedor .NET"
			},
			{
				"nome_empresa":"DBC Company",
				"cargo":"Desenvolvedor .NET"
			},
			{
				"nome_empresa":"QI ESCOLAS E FACULDADES",
				"cargo":"Instrutor de cursos livres"
			},
			{
				"nome_empresa":"TOTVS S/A",
				"cargo":"Analista de sistemas (.NET)"
			},
			{
				"nome_empresa":"DBC Company",
				"cargo":"Analista Desenvolvedor FullStack"
			}
		]
	},
	"observacoes":{
		"livros":{
			"top3livrostecnicos":[
				{
					"titulo":"Código Limpo",
					"autor":"Robert C. Martin"
				},
				{
					"titulo":"Sprint Google",
					"autor":"Jake Knapp, John Zeratsky, Braden Kowitz"
				},
				{
					"titulo":"Dominando o Android - 2ª edição",
					"autor":"Nelson Glauber"
				}
			]
		},
		"eventos":{
			"ultimos_eventos":[
				{
					"nome":"TheDevConf",
					"assunto":".NET"
				},
				{
					"nome":"Congresso PMI RS",
					"assunto":"Gestão de Projetos"
				}
			]
		}
	}
}

-------------------------------------------------------------------------------
