using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

string connStr = "Data Source=localhost; Initial Catalog = db - videogames; Integrated Security = True";
var connessioneSql = new SqlConnection(connStr);