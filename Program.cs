using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANALIZADOR_LEXICO
{
    class Program
    {
        private static string[] Tokens = { "lib", "namespace", "ent", "dec", "flot", "cad", "car", "bit", "cons", "var", "romp", "verdadero", "falso", "public", "priv", "for", "if", "+", "*", "-", "/", "++", "--", "+=", "-=", "*=", "%", "{", "}", ";", "[", "]", "(", ")", ":", ">" };
        private static string[] Operadores = { "+", "*", "-", "/", "++", "--", "+=", "-=", "*=", "%" };

        public static  void AnalizadorDePalabra(string cadena)
        {
           
            string[] Delimitadores = { "{", "}", ";", "[", "]", "(", ")", ":" };
            string[] encontrados= new string [Tokens.Length];
            string[] buscador=new string [80];
            string[] identificadores = new string [80];
            String identificador = "";

            int estado = 1;
            int t = 0;
            int c = 0;
     
            //for que recorre el vector de tokens para que se examine con la cadena de texto
            for (int i = 0; i <Tokens.Length ; i++)
            {

                if (cadena.Contains(Tokens[i]))
                {
                    encontrados[t] = Tokens[i];
                    t++;
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

        //metodo que evalua un identificador
        public static void AnalizadorDeIdentificador(string cadena)
        {
            int estado = 0;
            string cIdentificador = "";
            int c = 0;
            string[] recopilado = new string [50];
            string[] identificadores = new string[80];

            //for que recorre la cadena 
            for (int i = 0; i < cadena.Length; i++)
            {
                switch (estado)
                {
                    case 0:
                        if (char.IsLetter(cadena[i]))
                        {
                            estado = 1;
                            cIdentificador = cIdentificador + cadena[i];
                            recopilado[c] = cIdentificador;
                        }
                        break;

                    case 1:
                        if (char.IsLetterOrDigit(cadena[i]) || cadena[i]=='_')
                        {
                            estado = 1;
                            cIdentificador = cIdentificador + cadena[i];
                            recopilado[c] = cIdentificador;
                        }
                        else
                        {
                            estado = 0;
                            recopilado[c] = cIdentificador;
                            c++;
                            cIdentificador = "";
                        }
                        break;
                    
                }
            }

            //evaluacion para que separa las palabras reservadas de los tokens
            bool iden = true;
            int k = 0;

            for (int j = 0; j < recopilado.Length; j++)
            {
                for (int h = 0; h < Tokens.Length; h++)
                {

                    if (recopilado[j] == Tokens[h])
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
                    identificadores[k] = recopilado[j];
                    k++;
                }

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

