using adonet_db_videogame;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

string connStr = "Data Source=localhost;Initial Catalog = db - videogames;Integrated Security = True;Encrypt=False;";
var connessioneSql = new VideogameManager(connStr);

Console.WriteLine("Elimina un videogame dall'elenco");
Console.WriteLine("Inserisci l'id del gioco che vuoi eliminare");
var gameId = Convert.ToInt64(Console.ReadLine());

connessioneSql.DeleteVideogame(gameId);

Console.WriteLine("Ricerca gioco per ID");
var userId = Convert.ToInt64(Console.ReadLine());


var videogame = connessioneSql.GetVideogameByIdLike(userId);

foreach (var item in videogame) Console.WriteLine(item);

Console.WriteLine("Inserisci un videogioco");

Console.WriteLine("Aggiungi un nome");
var gameName = Console.ReadLine();

Console.WriteLine("Aggiungi una overview");
var gameOverview = Console.ReadLine();

Console.WriteLine("Aggiungi una data di rilascio");
var gameRelease = Convert.ToDateTime(Console.ReadLine());

Console.WriteLine("Aggiungi software house ID");
var gameSoftwareHouse = Convert.ToInt64(Console.ReadLine());

videogameManager.AddVideoGame(gameName, gameOverview, gameRelease, gameSoftwareHouse);

Console.WriteLine("Ricerca per nome");
var userName = Console.ReadLine();


var videogameName = videogameManager.GetVideoGameByNameLike(userName);


foreach (var item in videogameName) Console.WriteLine(item);

Console.WriteLine($"Count: {videogameName.Count}");
