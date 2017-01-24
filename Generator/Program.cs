using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfDraws;
            string path;
            Console.WriteLine("Bienvenue sur le générateur de tirages mathador !");

            do
            {
                numberOfDraws = 10;
                path = "./";

                Console.WriteLine("Choisissez le nombre de tirages désirés (10) : ");
                string numberResult = Console.ReadLine();

                if (!string.IsNullOrEmpty(numberResult))
                {
                    if (Regex.IsMatch(numberResult, @"^\d+$"))
                    {
                        numberOfDraws = Convert.ToInt32(numberResult);
                    }
                    else
                    {
                        Console.WriteLine("Ceci n'est pas un nombre");
                        numberOfDraws = 10;
                    }
                }

                Console.WriteLine("Nombre choisi : " + numberOfDraws);
                Console.WriteLine("\n\n\n");

                Console.WriteLine("Choisissez le chemin du fichier (\"./\") : ");
                string pathResult = Console.ReadLine();

                if (!string.IsNullOrEmpty(pathResult))
                {
                    if (Directory.Exists(pathResult))
                    {
                        path = pathResult;
                    }
                    else
                    {
                        Console.WriteLine("Le chemin n'existe pas");
                    }
                }

                Console.WriteLine("Chemin choisi : " + path);
                Console.WriteLine("\n\n\n");

                Console.WriteLine("Etes-vous sûr ? Tapez \"no\" pour annuler");
                string validationResult = Console.ReadLine();

                if(validationResult != "no")
                {
                    break;
                }
            }
            while (true);

            try
            {
                Console.WriteLine("Génération en cours...");
                DrawGenerator tmp = new DrawGenerator(numberOfDraws, path);
                Console.WriteLine("Fichier généré avec succès.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Une erreur est survenue : " + ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
