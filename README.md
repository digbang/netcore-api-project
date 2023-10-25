# netcore-api-project

## Setup
> `copy .env.example .env`
>
> `docker-compose up -d --build`

## Containers
> **App** `docker-compose exec app bash`
>
> **Database** `docker-compose exec db bash`

## Server
> **RUN** `docker-compose exec app bash`
>
> **RUN (run)** `dotnet run --urls http://0.0.0.0:80` or `dotnet watch run --urls http://0.0.0.0:80`

## Endpoints
> `GET /api/ping`

```
{
  "data": {
    "message": "Pong!"
  }
}
```
