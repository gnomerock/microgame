# running as development
`dotnet run`

# running on docker
`docker build -t microgame -f Dockerfile .`
`docker run -it --rm -p 3000:80 --name [containername] microgame`

# scaffolding controllers sample
`dotnet aspnet-codegenerator controller -name PlayersController -async -api -m Player -dc GameContext -outDir Controllers`

# initial&migrate db
1. `dotnet tool install --global dotnet-ef`
2. `dotnet ef migrations add InitialCreate --context [contextname]`
3. `dotnet ef database update --context [contextname]`

# my custom controller action
1. /player/{id}/status => return player's status (HP/AP/DP)
2. /player/{id}/attackedby/{enemyId} => player got attack by an enemy
3. /player/{id}/equipweapon/{equipmentId} => equip a weapon to a player
4. /player/{id}/equiparmor/{equipmentId} => equip an armor to a player