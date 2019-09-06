# Aplicativo para visualização da Previsão do Tempo

### OpenWeather API (https://openweathermap.org)

Projeto final possuí 2 API `ASP.NETCore (Sdk .NET Core 2.2)`, conforme descrição abaixo:

### LiveWeather

Esta API possuí 2 endpoint's:

######  1° "GetCitiesDefault" tem como objetivo retornar por default 3 cidades (Porto Alegre, Florianópolis e Curitiba).
######  2° "GetWeatherForecast" tem como objetivo retornar a previsão do tempo de acordo com o filtro informado.

### WebSite

Esta SPA simples é um extra feita em React aonde a mesma consome a API LiveWeather para retorno das informações na tela..

## Como rodar

### dotnet run

Basta abrir um terminal para cada projeto listado abaixo e executar os comandos: `dotnet run` para rodar aplicação.

###### `./LiveWeatherApi/WebSite`
###### `./LiveWeatherApi/LiveWeather/Api`

### IISExpress (Caso tenha problema com o dotnet run)

Basta abrir as solutions dos projetos no VS2017 e executar as mesmas.

Após estes processos agora basta acessar o endereço local `http://localhost:5001` que a SPA estará rodando,  <br />
posteriormente acessando a porta 5002 é possivel ver o Swagger da aplicação `LiveWeather`.

###### Note: após a primeira busca, à página deve atualizar a cada 15 minutos, retornando novas informações.

Swagger LiveWeather API

```
http://localhost:5002/swagger/index.html
```

## Testes da Aplicação LiveWeather API

##### LiveWeatherApiMSTest

O teste unitário das API foi desenvolvido com o framework <b>MSTest</b>.
