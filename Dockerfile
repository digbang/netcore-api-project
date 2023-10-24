FROM mcr.microsoft.com/dotnet/sdk:7.0

RUN dotnet tool install --global dotnet-ef
RUN dotnet tool install --global dotnet-aspnet-codegenerator

ENV PATH="${PATH}:/root/.dotnet/tools"

WORKDIR /app

COPY . .

CMD ["tail", "-f", "/dev/null"]
