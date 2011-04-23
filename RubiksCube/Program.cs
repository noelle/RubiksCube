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
            meinCube.drawInConsole();

            meinCube.rotateFront(Model.Direction.Left);
            meinCube.drawInConsole();

            meinCube.rotateFront(Model.Direction.Right);
            meinCube.drawInConsole();

            Console.Read();
        }
    }
}
