using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
namespace Solver
{
    public class Branch
    {
        DrawResolution Set;
        Draw draw;

        public Branch(Stroke Stroke1, Stroke Stroke2, Stroke Stroke3, Stroke Stroke4, Draw draw)
        {
            this.Set = new DrawResolution(draw);
            Set.AddStroke(Stroke1);
            Set.AddStroke(Stroke2);
            Set.AddStroke(Stroke3);
            Set.AddStroke(Stroke4);

            this.draw = draw;
        }

        public bool IsGoalReached()
        {
            return Set.IsGoalReached();
        }

        public bool IsMathador()
        {
            return Set.GetCurrentPoints() == 13; //si nombre de points =13 alors il y a mathador
        }

        public bool HasAnyStrokeReachTheGoal()
        {
            return Set.HasAnyStrokeReachTheGoal();
        }

        public DrawResolution GetDrawResolution()
        {
            return Set;
        }

    }
    public class Tree
    {
        public List<Branch> Combinaisons { get; private set; }
        private Draw draw;
        
        public Tree(Draw draw, int[] operators)
        {
            int A = draw.Numbers[0];
            int B = draw.Numbers[1];
            int C = draw.Numbers[2];
            int D = draw.Numbers[3];
            int E = draw.Numbers[4];
            this.Combinaisons = new List<Branch>();

            Stroke AB = new Stroke(A, B, ((MathadorOperators)operators[0]).ToReadableChar());
            try
            {
               
                Stroke CD1 = new Stroke(C, D, ((MathadorOperators)operators[2]).ToReadableChar());
                Stroke BD1 = new Stroke(AB.Result, CD1.Result, ((MathadorOperators)operators[1]).ToReadableChar());
                Stroke DE1 = new Stroke(BD1.Result, E, ((MathadorOperators)operators[3]).ToReadableChar());
                Branch firstBranch = new Branch(AB, CD1, BD1, DE1, draw);
                Combinaisons.Add(firstBranch);
            }catch(Exception e) { }

            try
            {
                Stroke CD1 = new Stroke(C, D, ((MathadorOperators)operators[2]).ToReadableChar());
                Stroke DE2 = new Stroke(CD1.Result, E, ((MathadorOperators)operators[3]).ToReadableChar());
                Stroke BE2 = new Stroke(AB.Result, DE2.Result, ((MathadorOperators)operators[1]).ToReadableChar());
                Branch secondBranch = new Branch(AB, CD1, DE2, BE2, draw);
                Combinaisons.Add(secondBranch);
            }
            catch (Exception e) { }

            try
            {
                Stroke BC3 = new Stroke(AB.Result, C, ((MathadorOperators)operators[1]).ToReadableChar());
                Stroke DE3 = new Stroke(D, E, ((MathadorOperators)operators[3]).ToReadableChar());
                Stroke CE3 = new Stroke(BC3.Result, DE3.Result, ((MathadorOperators)operators[2]).ToReadableChar());
                Branch thirdBranch = new Branch(AB, BC3, DE3, CE3, draw);
                Combinaisons.Add(thirdBranch);
            }
            catch (Exception e) { }

            try
            {

                Stroke BC3 = new Stroke(AB.Result, C, ((MathadorOperators)operators[1]).ToReadableChar());
                Stroke CD4 = new Stroke(BC3.Result, D, ((MathadorOperators)operators[2]).ToReadableChar());
                Stroke DE4 = new Stroke(CD4.Result, E, ((MathadorOperators)operators[3]).ToReadableChar());
                Branch fourthBranch = new Branch(AB, BC3, CD4, DE4, draw);
                Combinaisons.Add(fourthBranch);
            }
            catch (Exception e) { }

            try
            {
                Stroke DE5 = new Stroke(D, E, ((MathadorOperators)operators[3]).ToReadableChar());
                Stroke BC5 = new Stroke(AB.Result, C, ((MathadorOperators)operators[1]).ToReadableChar());
                Stroke CE5 = new Stroke(BC5.Result, DE5.Result, ((MathadorOperators)operators[2]).ToReadableChar());
                Branch fifthBranch = new Branch(AB, DE5, BC5, CE5, draw);
                Combinaisons.Add(fifthBranch);
            }
            catch (Exception e) { }

            try
            {

                Stroke DE5 = new Stroke(D, E, ((MathadorOperators)operators[3]).ToReadableChar());
                Stroke CE6 = new Stroke(C, DE5.Result, ((MathadorOperators)operators[2]).ToReadableChar());
                Stroke BE6 = new Stroke(AB.Result, CE6.Result, ((MathadorOperators)operators[1]).ToReadableChar());
                Branch sixthBranch = new Branch(AB, DE5, CE6, BE6, draw);
                Combinaisons.Add(sixthBranch);
            }
            catch (Exception e) { }

            this.draw = draw;

        }
        
    }

   
}
