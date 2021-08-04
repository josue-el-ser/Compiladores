using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANALIZADOR_LEXICO
{
    class Program
    {

       

    


        public static  void AnalizadorDePalabra(string cadena)
        {
            string[] Tokens = { "lib", "namespace", "ent", "dec", "flot", "cad", "car", "bit","cons", "var","romp", "verdadero", "falso", "public", "priv", "for", "if", "+", "*", "-", "/", "++", "--", "+=", "-=", "*=", "%", "{", "}", ";", "[", "]", "(", ")", ":" };
            string[] Operadores = { "+", "*", "-", "/", "++", "--", "+=", "-=", "*=", "%" };
            string[] Delimitadores = { "{", "}", ";", "[", "]", "(", ")", ":" };
            string[] encontrados= new string [Tokens.Length];
            string[] buscador=new string [80];
            string[] identificadores = new string [80];
            String identificador = "";

            int estado = 1;
            int t = 0;
            int c = 0;
     

            for (int i = 0; i <Tokens.Length ; i++)
            {

                if (cadena.Contains(Tokens[i]))
                {
                    encontrados[t] = Tokens[i];
                    t++;
                }
            }

            // ANALIZADOR PARA EL IDENTIFICADOR
            for (int i = 0; i < cadena.Length; i++)
            {
                switch (estado)
                {
                    case 1:
                        if (char.IsLetter(cadena[i]))
                        {
                            estado = 2;
                            identificador = identificador + cadena[i];
                            buscador[c] = identificador;
                        }

                        break;
                        
                    case 2:
                        if (char.IsLetter(cadena[i]) || char.IsDigit(cadena[i]))
                        {
                            estado = 2;
                            identificador = identificador + cadena[i];
                            buscador[c] = identificador;
                            break;
                        }
                        else
                        {
                            buscador[c] = identificador;
                            c++;
                            estado = 1;
                            identificador = "";
                            break;
                        }
                }
            }

            bool iden=true;
            int k = 0;

            for (int j = 0; j < buscador.Length; j++)
            {
                for (int h = 0; h < Tokens.Length; h++)
                {
                    
                    if (buscador[j] == Tokens[h])
                    {
                        iden = false;
                        h = Tokens.Length - 1;
                    }
                    else
                    {
                        iden = true;
                        
                    }
                }

                if (iden)
                {
                    identificadores[k] = buscador[j];
                    k++;
                }
                
            }


            Console.WriteLine("Los Tokens encontrados son:");
            foreach (string s in encontrados)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Los identificadores encontrados son:");
            foreach (string a in identificadores)
            {
                Console.WriteLine(a);
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

