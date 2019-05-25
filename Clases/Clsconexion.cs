using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using Npgsql;
namespace RaposoFact.Clases
{
    class Clsconexion
    {
        public NpgsqlConnection cn = new NpgsqlConnection("Server=192.168.1.21;Port=5432;User Id=postgres;Password=sistemas;Database=BdRaposo;"); 
    }
}
