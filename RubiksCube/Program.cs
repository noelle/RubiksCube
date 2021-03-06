﻿using System;
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
            meinCube.drawInConsole();

            Controller.CubeSolver solver = new Controller.CubeSolver(meinCube);
            solver.solve();

            Console.Read();
        }
    }
}
