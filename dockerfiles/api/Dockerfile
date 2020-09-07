FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /app
COPY ./deploy/api/ /app/publish
ENTRYPOINT ["dotnet", "/app/publish/MasterChechBotWebApi.dll"]