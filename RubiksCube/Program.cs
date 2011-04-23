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

            meinCube.rotate(Model.CubeSurface.Front, Model.Direction.Right);
            meinCube.drawInConsole();

            meinCube.rotate(Model.CubeSurface.Front, Model.Direction.Left);
            meinCube.drawInConsole();

            meinCube.rotate(Model.CubeSurface.Back, Model.Direction.Right);
            meinCube.drawInConsole();

            meinCube.rotate(Model.CubeSurface.Back, Model.Direction.Left);
            meinCube.drawInConsole();

            meinCube.rotate(Model.CubeSurface.Right, Model.Direction.Right);
            meinCube.drawInConsole();

            meinCube.rotate(Model.CubeSurface.Right, Model.Direction.Left);
            meinCube.drawInConsole();

            meinCube.rotate(Model.CubeSurface.Left, Model.Direction.Right);
            meinCube.drawInConsole();

            meinCube.rotate(Model.CubeSurface.Left, Model.Direction.Left);
            meinCube.drawInConsole();

            meinCube.rotate(Model.CubeSurface.Top, Model.Direction.Right);
            meinCube.drawInConsole();

            meinCube.rotate(Model.CubeSurface.Top, Model.Direction.Left);
            meinCube.drawInConsole();

            meinCube.rotate(Model.CubeSurface.Bottom, Model.Direction.Right);
            meinCube.drawInConsole();

            meinCube.rotate(Model.CubeSurface.Bottom, Model.Direction.Left);
            meinCube.drawInConsole();


            Console.Read();
        }
    }
}
