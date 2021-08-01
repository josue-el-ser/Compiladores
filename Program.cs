using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANALIZADOR_LEXICO
{
    class Program
    {

       

       public String[] Ayuda = new String[50];


        public static  void AnalizadorDePalabra(string cadena)
        {
            string[] PalabrasReservadas = { "lib", "namespace", "ent", "dec", "flot", "cad", "car", "bit","cons", "var","romp", "verdadero", "falso", "public", "priv", "for", "if", "+", "*", "-", "/", "++", "--", "+=", "-=", "*=", "%", "{", "}", ";", "[", "]", "(", ")", ":" };
            string[] Operadores = { "+", "*", "-", "/", "++", "--", "+=", "-=", "*=", "%" };
            string[] Delimitadores = { "{", "}", ";", "[", "]", "(", ")", ":" };

          String[] encontrados= new String [PalabrasReservadas.Length];

            for (int i = 0; i <PalabrasReservadas.Length ; i++)
            {

                if (cadena.Contains(PalabrasReservadas[i]))
                {
                    encontrados[i] = PalabrasReservadas[i];
                }
            }

            Console.WriteLine("Los Tokens encontrados son:");
            foreach (string s in encontrados)
            {
                Console.Write(s);
            }
        
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Escriba algo");
            string cadena = Console.ReadLine();
            AnalizadorDePalabra(cadena);
            Console.ReadKey();

        }
    }
}
