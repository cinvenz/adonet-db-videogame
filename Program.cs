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


v