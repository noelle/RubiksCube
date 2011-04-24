using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube
{
    class Program
    {
        static void Main(string[] args)
        {
            RubiksCube.Model.Cube meinCube = new Model.Cube();

            Controller.CubeSolver solver = new Controller.CubeSolver(meinCube);
            solver.Cube.rotate90(Model.Direction.Right);
            meinCube.drawInConsole();

            Console.Read();
        }
    }
}
