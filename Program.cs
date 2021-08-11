using System;

namespace ANALIZADOR_LEXICO
{
    class Program
    {
        // Vector general que contiene a todos los tokens del lenguaje
        private static string[] Tokens = { "lib", "namespace", "ent", "dec", "flot", "cad", "car", "bit", "cons", "var", "romp", "verdadero", "falso", "public", "priv","vac","est","nue","retor","interfaz","intentar","cap","enum","bol","clase","virtual","releer","abs","base","this","si","sino", "mientras", "para","encaso","caso","defecto","hacer","imprimir","nulo", "+", "*", "-", "/", "++", "--", "+=", "-=", "*=", "%","==","=",">","<",">=", "<=", "||","|","!","&&","^","!=","<>","?:","{", "}", ";", "[", "]", "(", ")", ":", "'", "/", "/*","*/" };
        //vectores especificos que contienen a una parte de los tokens 
        private static string[] PalabrasReservadas = { "lib", "namespace", "ent", "dec", "flot", "cad", "car", "bit", "cons", "var", "romp", "verdadero", "falso", "public", "priv", "vac", "est", "nue", "retor", "interfaz", "intentar", "cap", "enum", "bol", "clase", "virtual", "releer", "abs", "base", "this", "si", "sino", "mientras", "para", "encaso", "caso", "defecto", "hacer", "imprimir", "nulo" };
        private static string[] Delimitadores = { "{", "}", ";", "[", "]", "(", ")", ":", "'", "/", "/*", "*/" };
        private static string[] Operadores = { "+", "*", "-", "/", "++", "--", "+=", "-=", "*=", "%" , "==", "=", ">", "<", ">=", "<=", "||", "|", "!", "&&", "^", "!=", "<>", "?:" };

        //metodo que analiza si se encuentra tokens en la cadena de entrada
        public static  void AnalizadorDeTokens(string cadena)
        {
            string[] encontrados= new string [Tokens.Length];
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
            //Imprime los tokens encontrados
            Console.WriteLine("Los Tokens encontrados son:");
            foreach (string s in encontrados)
            {
                Console.WriteLine(s);
            }
   
            
        }
        
        /*-----------------------------------------------------------------------------------------------------------------------
        -------------------------------------------------------------------------------------------------------------------------
        */
        
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

            //evaluacion que separa las palabras reservadas de los tokens
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
            
            //Imprime los identificadores encontrados
            Console.WriteLine("Los identificadores encontrados son:");
            foreach (string a in identificadores)
            {
                Console.WriteLine(a);
            }
        }

        //principal
        static void Main(string[] args)
        {
            Console.WriteLine("Escriba algo");
            string cadena = Console.ReadLine();
            AnalizadorDeTokens(cadena);
            AnalizadorDeIdentificador(cadena);
            Console.ReadKey();

        }
    }
}
