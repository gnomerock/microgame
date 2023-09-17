# running as development
`dotnet run`

# running on docker
`docker run -it --rm -p 3000:80 --name [containername] microgame`

# scaffolding controllers sample
`dotnet aspnet-codegenerator controller -name PlayersController -async -api -m Player -dc PlayerContext -outDir Controllers`