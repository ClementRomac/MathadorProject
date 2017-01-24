using Framework;
using System.Collections.Generic;
using System.Linq;

namespace Solver
{
    public static class DrawSolver
    {
        public static bool IsPossible(Draw draw)
        {
            List<List<int>> swappedDrawNumbers = SwapElementsInList(draw.Numbers); //on recupere toutes les combinaisons possibles 
            List<List<int>> swappedOperators = SwapOperators();
            foreach (List<int> oneCaseOfSwappedNumbers in swappedDrawNumbers) // on les test toutes
            {
                foreach (List<int> oneCaseOfSwappedOperators in swappedOperators)
                {
                    Tree tree = new Tree(draw, oneCaseOfSwappedNumbers, oneCaseOfSwappedOperators);
                    List<Branch> mathadorBranches = tree.Combinaisons.Where(b => b.IsMathador()).ToList();

                    if (mathadorBranches.Count != 0){
                        return true;
                    }
                }
            }

            return false;
        }

        public static List<DrawResolution> GetSolutions(Draw draw)
        {
            List<List<int>> swappedDrawNumbers = SwapElementsInList(draw.Numbers); //on recupere toutes les combinaisons possibles 
            List<List<int>> swappedOperators = SwapOperators();
            List<DrawResolution> solutionsOfDraw = new List<DrawResolution>();

            foreach (List<int> oneCaseOfSwappedNumbers in swappedDrawNumbers) // on les test toutes
            {
                foreach (List<int> oneCaseOfSwappedOperators in swappedOperators)
                {
                    Tree tree = new Tree(draw, oneCaseOfSwappedNumbers, oneCaseOfSwappedOperators);
                    foreach (Branch result in tree.Combinaisons.Where(b => b.IsGoalReached()).ToList())//renvoie une liste de branches où le Goal est atteind
                    {
                        solutionsOfDraw.Add(result.DrawResolution);
                    }
                }
            }

            return solutionsOfDraw;
        }


        /// <summary>
        ///  Nous créons une liste de liste d'entier. L'objectif de cette liste est de montrer toutes les combinaisons de positionnement des éléments possibles.
        ///  Cette liste se consitute des chiffres suivants : 0 1 2 3 4 5
        ///  Elle retournera donc : (0,1,2,3,4,5),(1,0,2,3,4,5) ...etc
        /// </summary>
        /// <param name="drawNumbers"></param>
        /// <returns></returns>
        private static List<List<int>> SwapElementsInList(List<int> drawNumbers)
        {
            List<List<int>> possibleSwaps = new List<List<int>>();
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
                                List<int> swap = new List<int>();
                                swap.AddRange(new int[5] { i, j, k, l, m, });
                                possibleSwaps.Add(swap);


                            }
                        }
                    }
                }
            }

            possibleSwaps = ReplaceElements(possibleSwaps, drawNumbers); // on remplace 0 1 2 3 4 5 par nos éléments réels de la liste
            return possibleSwaps;
        }


        /// <summary>
        /// On remplace 0 par le premier élément de notre liste,
        ///             1 par le second élément de notre liste,
        ///             2 par le troisième élément de notre liste,
        ///             3 par le quatrième élément de notre liste,
        ///             4 par le cinquième élément de notre liste,
        ///           
        /// </summary>
        /// <param name="possibleSwaps"></param>
        /// <param name="drawNumbers"></param>
        /// <returns></returns>
        private static List<List<int>> ReplaceElements(List<List<int>> possibleSwaps, List<int> drawNumbers)
        {
            foreach (List<int> swap in possibleSwaps) // Pour tous les tirages on remplace les value
            {
                var i = swap.FindIndex(x => x == 0);
                swap[i] = drawNumbers[0];

                var j = swap.FindIndex(x => x == 1);
                swap[j] = drawNumbers[1];

                var k = swap.FindIndex(x => x == 2);
                swap[k] = drawNumbers[2];

                var l = swap.FindIndex(x => x == 3);
                swap[l] = drawNumbers[3];

                var m = swap.FindIndex(x => x == 4);
                swap[m] = drawNumbers[4];

            }

            return possibleSwaps;
        }



        /// <summary>
        ///Retourne toutes les combinaisons d'operateurs possibles
        /// </summary>
        /// <returns></returns>
        private static List<List<int>> SwapOperators()
        {
            List<List<int>> possibleOperatorsSwaps = new List<List<int>>();
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
                            if (i == l || j == l || k == l) continue;
                            List<int> operators = new List<int>();
                            operators.AddRange(new int[4] { i, j, k, l });
                            possibleOperatorsSwaps.Add(operators);

                        }
                    }
                }
            }

            return possibleOperatorsSwaps;
        }

        public delegate int Calcul(int operand1, int operand2);
        static List<Calcul> operations = new List<Calcul>() { delegate(int operand1, int operand2) { return operand1 + operand2; },
                                                              delegate(int operand1, int operand2) { if(operand2 >= operand1 ){return 0; } return operand1 - operand2; },
                                                              delegate(int operand1, int operand2) { return operand1 * operand2; },
                                                              delegate(int operand1, int operand2) { if(operand2==0){return -1; } return operand1 / operand2; },
        };
    }
}


  
