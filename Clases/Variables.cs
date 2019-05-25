using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaposoFact.Clases
{
   static  class Variables
    {
        private static int id;

       
        public static int Id
        {
            get { return Variables.id; }
            set { Variables.id = value; }
        }
        private static string nombre;

        public static string Nombre
        {
            get { return Variables.nombre; }
            set { Variables.nombre = value; }
        }
    }
}
