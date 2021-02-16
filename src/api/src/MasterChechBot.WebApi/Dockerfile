FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /app
EXPOSE 80
COPY ./publish /app/publish
ENTRYPOINT ["dotnet", "/app/publish/MasterChechBot.WebApi.dll"]