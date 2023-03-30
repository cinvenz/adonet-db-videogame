using adonet_db_videogame;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

string connStr = "Data Source=localhost;Initial Catalog = db - videogames;Integrated Security = True;Encrypt=False;";
var connessioneSql = new VideogameManager(connStr);

connessioneSql.AddVideGame(Videogame);

Console.WriteLine("Ricerca per nome");
var userName = Console.ReadLine();


var searchName = connessioneSql.GetVideogameByNameLike(userName);


foreach (var item in searchName) Console.WriteLine(item);

Console.WriteLine($"Count: {searchName.Count}");

Console.WriteLine("Elimina un videogame trammite id");
var gameId = Convert.ToInt64(Console.ReadLine());

connessioneSql.DeleteVideogame(gameId);

Console.WriteLine("Ricerca gioco per ID");
var userId = Convert.ToInt64(Console.ReadLine());


var games = connessioneSql.GetVideogameByIdLike(userId);

foreach (var game in games) Console.WriteLine(game);

Console.WriteLine("Inserisci un videogame");

Console.WriteLine("Aggiungi un nome");
var insName = Console.ReadLine();

Console.WriteLine("Aggiungi una overview");
var insOverview = Console.ReadLine();

Console.WriteLine("Aggiungi una data di rilascio");
var insDate = Convert.ToDateTime(Console.ReadLine());

Console.WriteLine("Aggiungi software house ID");
var insSoftwareHouse = Convert.ToInt64(Console.ReadLine());


