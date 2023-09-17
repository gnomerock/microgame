# running as development
`dotnet run`

# running on docker
`docker run -it --rm -p 3000:80 --name [containername] microgame`

# scaffolding controllers sample
`dotnet aspnet-codegenerator controller -name PlayersController -async -api -m Player -dc GameContext -outDir Controllers`

# initial&migrate db
1. `dotnet tool install --global dotnet-ef`
2. `dotnet ef migrations add InitialCreate --context [contextname]`
3. `dotnet ef database update --context [contextname]`
