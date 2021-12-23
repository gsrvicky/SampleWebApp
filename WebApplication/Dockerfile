FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /usr/src/app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY *.sln .
COPY *.csproj .

COPY nuget.config ./
ARG PAT=localhost
#RUN sed -i "s|</configuration>|<packageSourceCredentials><VoltazureFeed><add key=\"Username\" value=\"PAT\" /><add key=\"ClearTextPassword\" value=\"${PAT}\" /></VoltazureFeed></packageSourceCredentials></configuration>|" nuget.config
RUN sed -i "s|</configuration>|<packageSourceCredentials><VoltazureFeed><add key=\"Username\" value=\"PAT\" /><add key=\"ClearTextPassword\" value=\"7ue2iprnxpu7orx5hjc3yr7hz3afjhhkujlawdl4q6ces7vjwpsq\" /></VoltazureFeed></packageSourceCredentials></configuration>|" nuget.config
RUN dotnet restore --configfile "./nuget.config"

# copy everything else and build app
COPY . .

WORKDIR "/src/."
RUN dotnet build "WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication.dll"]
