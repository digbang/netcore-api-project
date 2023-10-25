# netcore-api-project

## Setup
> `docker-compose up -d --build`
>
> `copy .env.example .env` (after build, inside app container)

## Containers
> **App** `docker-compose exec app bash`
>
> **Database** `docker-compose exec db bash`

## Server
> **RUN** `docker-compose exec app bash`
>
> **RUN** `dotnet run --urls http://0.0.0.0:80` or `dotnet watch run --urls http://0.0.0.0:80`

## Endpoints
> `GET /api/ping`

```
{
  "data": {
    "message": "Pong!"
  }
}
```
## Tools
> **Entity Framework** https://learn.microsoft.com/en-us/ef/core/cli/dotnet
>
> **Scaffolding** https://learn.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator
