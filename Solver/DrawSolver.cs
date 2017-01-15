using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public static class DrawSolver
    {
        public static bool IsPossible(Draw draw)
        {
            List<List<int>> Allcase = SwapElementInList(draw.Numbers); //on recupere toutes les combinaisons possibles 
            foreach (List<int> oneCase in Allcase) // on les test toutes
            {
                List<DrawResolution> AllcaseResult = TestWithOperand(oneCase, draw.Goal);
                 if ( AllcaseResult.Any( c => c.GetCurrentPoints() == 13 )) return true; //si un desl éléments est composé de 13 éléments,  alors on renvoie true car Mathador

            }
            Console.WriteLine("false");
            return false;
        }

        /// <summary>
        ///  Nous créons une liste de liste d'entier. L'objectif de cette liste est de montrer toutes les combinaisons de positionnement des éléments possibles.
        ///  Cette liste se consitute des chiffres suivants : 0 1 2 3 4 5
        ///  Elle retournera donc : (0,1,2,3,4,5),(1,0,2,3,4,5) ...etc
        /// </summary>
        /// <param name="Tirage"></param>
        /// <returns></returns>
        public static List<List<int>> SwapElementInList(List<int> Tirage)
        {
            List<List<int>> Allcase = new List<List<int>>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j == i) continue;
                    for (int k = 0; k < 5; k++)
                    {
                        if (i == k || j == k) continue;
                        for (int l = 0; l < 5; l++)
                        {
                            if (i == l || j == l || k == l) continue;
                            for (int m = 0; m < 5; m++)
                            {
                                if (i == m || j == m || k == m || l == m) continue;
                                List<int> TirageSwapped = new List<int>();
                                TirageSwapped.AddRange(new int[5] { i, j, k, l, m, }); // on remplace 0 1 2 3 4 5 par nos éléments réels de la liste
                                Allcase.Add(TirageSwapped);

                            }
                        }
                    }
                }
            }

            Console.Write("");
            Allcase = ReplaceElement(Allcase, Tirage);
            return Allcase;
        }
        /// <summary>
        /// On remplace 0 par le premier élément de notre liste,
        ///             1 par le second élément de notre liste,
        ///             2 par le troisième élément de notre liste,
        ///             3 par le quatrième élément de notre liste,
        ///             4 par le cinquième élément de notre liste,
        ///           
        /// </summary>
        /// <param name="Allcase"></param>
        /// <param name="Tirage"></param>
        /// <returns></returns>
        public static List<List<int>> ReplaceElement(List<List<int>> Allcase, List<int> Tirage)
        {
            foreach (List<int> oneCase in Allcase) // Pour tous les tirages on remplace les value
            {
                var i = oneCase.FindIndex(x => x == 0);
                oneCase[i] = Tirage[0];

                var j = oneCase.FindIndex(x => x == 1);
                oneCase[j] = Tirage[1];

                var k = oneCase.FindIndex(x => x == 2);
                oneCase[k] = Tirage[2];

                var l = oneCase.FindIndex(x => x == 3);
                oneCase[l] = Tirage[3];

                var m = oneCase.FindIndex(x => x == 4);
                oneCase[m] = Tirage[4];
            }
            return Allcase;
        }



        /// <summary>
        /// A partir d'une liste on teste toutes les opérations possibles une fois, si le résultat que l'on souhaite obtenir est possible on renvoie true
        /// </summary>
        /// <param name="Tirage"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public static List<DrawResolution> TestWithOperand(List<int> Tirage, int goal)
        {
            List<DrawResolution> SolutionOfGame = new List<DrawResolution>();
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == i) continue;
                    for (int k = 0; k < 4; k++)
                    {
                        if (i == k || j == k) continue;
                        for (int l = 0; l < 4; l++)
                        {
                            if (i == k || j == k) continue;

                            /*   Console.WriteLine(Tirage[0].ToString() +
                                            ((MathadorOperators)i).ToReadableString() +
                                            Tirage[1].ToString() +
                                            ((MathadorOperators)j).ToReadableString() +
                                            Tirage[2].ToString() +
                                            ((MathadorOperators)k).ToReadableString() +
                                            Tirage[3].ToString() +
                                            ((MathadorOperators)l).ToReadableString() +
                                             Tirage[4].ToString()
                                            );*/
                            List<DrawResolution> solution = new List<DrawResolution>();
                            solution = TestOperandWithPriority(Tirage[0],
                                           ((MathadorOperators)i).ToString(),
                                           Tirage[1],
                                           ((MathadorOperators)j).ToString(),
                                           Tirage[2],
                                           ((MathadorOperators)k).ToString(),
                                           Tirage[3],
                                           ((MathadorOperators)l).ToString(),
                                            Tirage[4]
                                           );

                        }
                    }
                }
            }

            return SolutionOfGame;
        }
        /// <summary>
        /// cette méthoe prend en entier un ordre bien précis de calcul : a 1 b 2 c 3 d 4 e , ou lettres sont des entiers et chiffres des operators
        /// L'objectif de cette méthode est de tester en fonction des priorités d'opétations si le résultat est atteint, si il l'est alors on ajoute la combinaison à la solution
        /// on cjeckera plus tard si un enchainement de type matador est atteint
        /// </summary>
        /// <param name="operator1"></param>
        /// <param name="operator2"></param>
        /// <param name="operator3"></param>
        /// <param name="operator4"></param>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        /// <param name="operand3"></param>
        /// <param name="operand4"></param>
        /// <param name="operand5"></param>
        /// <returns></returns>
        public static List<DrawResolution> TestOperandWithPriority(int operand1 , string operator1, int operand2, string operator2, int operand3, string operator3, int operand4, string operator4, int operand5)
        {


            // TODO : écrire arbre

            /*
            Stroke stroke0 = new Stroke(Tirage[0], Tirage[1], ((MathadorOperators)i).ToReadableString());
            solution.AddStroke(stroke0);
            if (solution.IsGoalReached())
            {
                SolutionOfGame.Add(solution);
            }*/

            return null;
        }




        public static List<List<Stroke>> FindSolutions(Draw draw)
        {
            List<int> Tirage = new List<int>();
            Tirage.AddRange(new int[5] { draw.Numbers[0], draw.Numbers[1], draw.Numbers[2], draw.Numbers[3], draw.Numbers[4] });
            int goal = draw.Goal;


            return null;
        }



        public delegate int Calcul(int operand1, int operand2);
        static List<Calcul> operations = new List<Calcul>() { delegate(int operand1, int operand2) { return operand1 + operand2; },
                                                              delegate(int operand1, int operand2) { if(operand2 >= operand1 ){return 0; } return operand1 - operand2; },
                                                              delegate(int operand1, int operand2) { return operand1 * operand2; },
                                                              delegate(int operand1, int operand2) { if(operand2==0){return -1; } return operand1 / operand2; },
        };
    }
}


  
