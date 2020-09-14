FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /app
COPY ./publish /app/publish
ENTRYPOINT ["dotnet", "/app/publish/MasterChechBotWebApi.dll"]