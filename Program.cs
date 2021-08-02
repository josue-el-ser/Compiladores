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

            int j=o;
            
            for (int i = 0; i <PalabrasReservadas.Length ; i++)
            {
                
                if (cadena.Contains(PalabrasReservadas[i]))
                {
                    encontrados[j] = PalabrasReservadas[i];
                    j++;
                }
            }

            Console.WriteLine("Los Tokens encontrados son:");
            foreach (string s in encontrados)
            {
                Console.Write(s);
            }
        
        }


        public static void AnalizadorIden(string cadena){
            String identificador ="";
            int estado = 1;
            
            for (int i=0; i<cadena.length; i++){
                switch (estado){
                    case 1: if(cadena[i].Ischar()){
                    
                    
                    }
                }
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
