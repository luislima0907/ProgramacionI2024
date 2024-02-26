using System;

namespace Desafios
{
    class Program
    {
        static void Main(string[] args)
        {
            string decisionDesafio;

            // variables para el bucle while
            string decision;
            int compararDecision;
            string conEsto;

            decision = "si";
            conEsto = "si";

            do
            {
                Console.WriteLine("Bienvenido a mi tarea, puedes ejecutar un desafio diferente escribiendo alguna de estas opciones:\n\nDesafios Sesion 4 Parte 1:\n\nPrimer desafio '1.1'\nSegundo desafio '1.2'\nTercer desafio '1.3'\n\nDesafios Sesion 4 Parte 2:\n\nPrimer desafio '2.1'\nSegundo desafio '2.2'\n\n");
                decisionDesafio = Console.ReadLine();

                switch (decisionDesafio)
                {
                    // DESAFIOS SESION 4 PARTE 1

                    // DESAFIO NO.1
                    case "1.1":
                        Console.WriteLine("Primer desafio hecho con una instacia de una clase interna\n");
                        PromedioYSumaConInstacia sueldos = new PromedioYSumaConInstacia("Luis", 2000, 1800, 2500);

                        Console.WriteLine("Primer desafio hecho con un metodo publico de otra clase\n");
                        PromedioYSumaConLLamadaDeMetodo sueldosDesdeOtraClase = new PromedioYSumaConLLamadaDeMetodo("hola desde otra clase\n");
                        sueldosDesdeOtraClase.PromedioYSumaConMetodoDeOtraClase("Carlos", 9000, 10000, 4000);

                        Console.WriteLine("\nPrimer desafio con la llamada de un metodo static");
                        PromedioYSumaConMetodo();
                        break;

                    // DESAFIO NO.2
                    case "1.2":
                        Console.WriteLine("Metodos de suma, resta, multiplicacion y division llamados desde otra clase y con dos parametros de tipo int.\n");
                        OperacionesBasicas operaciones = new OperacionesBasicas();
                        //suma
                        Console.WriteLine($"El resultado de la suma es: {operaciones.Suma(8, 5)}\n");
                        //resta
                        Console.WriteLine($"El resultado de la resta es: {operaciones.Resta(20, 15)}\n");
                        //multiplicacion
                        Console.WriteLine($"El resultado de la multiplicacion es: {operaciones.Multiplicacion(4, 4)}\n");
                        //division
                        Console.WriteLine($"El resultado de la division es: {operaciones.Division(10, 2)}\n");
                        break;

                    // DESAFIO NO.3
                    case "1.3":
                        SumaConExcepciones();
                        break;

                    // DESAFIOS SESION 4 PARTE 2

                    // DESAFIO NO.1
                    case "2.1":
                        IngresoDeUsuarios();
                        break;

                    //DESAFIO NO.2
                    case "2.2":
                        PuntajeMasAlto();
                        break;

                    // Opcion de rescate
                    default:
                        Console.WriteLine("Esta opcion no esta dentro de las antes mencionadas, por favor intentelo de nuevo");
                        break;
                }
                Console.WriteLine("¿Deseas continuar probando los desafios?\nEscribe 'si' para continuar.\nEscribe cualquier cosa o dale enter para salir del programa.\n");
                decision = Console.ReadLine();

                compararDecision = string.Compare(decision, conEsto, true);
            } while (compararDecision == 0);
        }
        static void PromedioYSumaConMetodo()
        {
            // variables para el bucle while
            string decision;
            int compararDecision;
            string conEsto;

            // variables para las operaciones
            string nombreDelUsuario;
            int sueldoOctubre;
            int sueldoNoviembre;
            int sueldoDiciembre;
            int promedio;
            int sumaDelSueldo;

            decision = "si";
            conEsto = "si";

            try
            {
                do
                {
                    Console.WriteLine("Bienvenido a mi metodo para calcular la suma y el promedio total de tu sueldo de octubre a diciembre\n");
                    Console.WriteLine("Para empezar, Ingresa tu nombre");
                    nombreDelUsuario = Console.ReadLine();

                    Console.WriteLine("Bien, ahora ingresa el sueldo del mes de octubre");
                    sueldoOctubre = int.Parse(Console.ReadLine());

                    Console.WriteLine("Bien, ahora ingresa el sueldo del mes de noviembre");
                    sueldoNoviembre = int.Parse(Console.ReadLine());

                    Console.WriteLine("Bien, para finalizar ingresa el sueldo del mes de diciembre y te diremos la suma y el promedio de tus sueldos");
                    sueldoDiciembre = int.Parse(Console.ReadLine());

                    sumaDelSueldo = sueldoOctubre + sueldoNoviembre + sueldoDiciembre;
                    promedio = sumaDelSueldo / 3;

                    Console.WriteLine($"Hola {nombreDelUsuario}, la suma de tus sueldos de octubre a diciembre son: ${sumaDelSueldo}\nY el promedio de tus sueldos es: ${promedio}");


                    Console.WriteLine("¿Desea repetir el metodo?\nEscriba 'si' para continuar\nEscriba cualquier cosa o dele enter para salir.");
                    decision = Console.ReadLine();

                    compararDecision = string.Compare(decision, conEsto, true);
                } while (compararDecision == 0);
                Console.WriteLine("Gracias por usar mi metodo.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ha ingresado otro tipo de dato que no es un numero, intentelo de nuevo\n");
                PromedioYSumaConMetodo();
            }
        }
        static void SumaConExcepciones()
        {
            int numeroUno;
            int numeroDos;
            int resultado;

            try
            {
                Console.WriteLine("Bienvenido mi metodo de sumar dos numeros.\n");

                Console.WriteLine("Por favor, ingrese el primer numero.");
                numeroUno = int.Parse(Console.ReadLine());

                Console.WriteLine("Por favor, ingrese el segundo numero.");
                numeroDos = int.Parse(Console.ReadLine());

                resultado = numeroUno + numeroDos;

                Console.WriteLine($"El resultado de la suma de los dos numeros ingresados es: {resultado}\n");

            }
            catch (FormatException e)
            {
                Console.WriteLine("Error de Formato, no ha introducido un valor de tipo entero o dejo en blanco el espacio para ingresarlo, intentelo de nuevo\n");
                SumaConExcepciones();
            }
            finally
            {
                Console.WriteLine("El metodo SumaConExcepciones ha finalizado.\n");
            }
        }
        static void PuntajeMasAlto()
        {
            Random puntaje = new Random();

            int puntajeMasAlto;
            string jugadorRecord = "Luis";

            string jugadorQueRomperaRecordONo;
            int puntajeQueRomperaONo;

            // variables para el bucle while
            string decision;
            int compararDecision;
            string conEsto;

            decision = "si";
            conEsto = "si";


            Console.WriteLine($"Bienvenido al juego del record imaginario, ingresa tu nombre y puntaje obtenido en un juego imaginario, el rango del puntaje es entre 0 y 1000, solo {jugadorRecord} ha obtenido el mayor puntaje en este juego.\n\n¿Seras capaz de superarlo?\n\nSi quieres superarlo escribe 'si'.\nSi no quieres superarlo escribe cualquier cosa o dale enter para salir.\n");
            decision = Console.ReadLine();

            compararDecision = string.Compare(decision, conEsto, true);
            while (compararDecision == 0)
            {
                puntajeMasAlto = puntaje.Next(0, 1000);

                Console.WriteLine("Ingresa tu nombre");
                jugadorQueRomperaRecordONo = Console.ReadLine();

                if (jugadorQueRomperaRecordONo != "")
                {
                    Console.WriteLine("Bien, ahora ingresa el puntaje que obtuviste");
                    try
                    {
                        puntajeQueRomperaONo = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Error, tiene que ingresar un valor entre 0 a 1000, intentelo de nuevo");
                        puntajeQueRomperaONo = 0;
                    }
                    if ((puntajeQueRomperaONo >= 0 && puntajeQueRomperaONo <= 1000) && (puntajeQueRomperaONo > puntajeMasAlto)) Console.WriteLine($"La nueva puntuacion mas alta ahora es: {puntajeQueRomperaONo}\nLa puntuacion mas alta fue lograda por: {jugadorQueRomperaRecordONo}\nRecord anterior: {puntajeMasAlto} por {jugadorRecord}\n");
                    else if ((puntajeQueRomperaONo >= 0 && puntajeQueRomperaONo <= 1000) && (puntajeQueRomperaONo < puntajeMasAlto)) Console.WriteLine($"La puntuacion mas alta: {puntajeMasAlto} del jugador {jugadorRecord} no ha sido superada, y aun esta en manos de {jugadorQueRomperaRecordONo} para poder superarla.\n");
                    Console.WriteLine("¿Desea volver a intentarlo?\nEscriba 'si' para continuar\nEscriba cualquier cosa o dele enter para salir.");
                    decision = Console.ReadLine();

                    compararDecision = string.Compare(decision, conEsto, true);
                    if (compararDecision == 1) Console.WriteLine("Entendido, Gracias por jugar.\n");
                }
                else Console.WriteLine("No puede dejar el campo del nombre vacio, por favor intentelo de nuevo");
            }
            if (compararDecision == 1) Console.WriteLine("Entendido, sera en otra ocasion.\n");
        }
        static void IngresoDeUsuarios()
        {
            string nombreDelUsuario;
            string contraseñaDelUsuario;

            string inicioDeUsuario;
            string contraseñaParaIniciar;

            Console.WriteLine("Para iniciar sesion, debe registrarse primero.\nPor favor escriba un nombre de usuario");
            nombreDelUsuario = Console.ReadLine();

            Console.WriteLine("Bien, ahora escriba una clave para proteger su usuario");
            contraseñaDelUsuario = Console.ReadLine();

            if ((nombreDelUsuario == "" && contraseñaDelUsuario == "") || (nombreDelUsuario == "" || contraseñaDelUsuario == "")) Console.WriteLine("Debes de ingresar tu nombre de usuario y contraseña para registrarte");
            else
            {
                Console.WriteLine("\nBienvenido al programa de inicio de sesion, escribe el nombre de usuario y clave que acabas de crear para pasar\n");

                Console.WriteLine("Ingresa tu nombre de usuario");
                inicioDeUsuario = Console.ReadLine();

                Console.WriteLine("Ingresa tu clave");
                contraseñaParaIniciar = Console.ReadLine();

                if (nombreDelUsuario == inicioDeUsuario && contraseñaDelUsuario == contraseñaParaIniciar) Console.WriteLine("Inicio de sesion exitoso\n");
                else Console.WriteLine("escribiste mal tu usuario o clave, vuelvelo a intentar\n");
            }
        }
    }
}