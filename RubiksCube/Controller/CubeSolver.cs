using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Controller
{
    public class CubeSolver
    {
        private Model.Cube cube;

        public CubeSolver(Model.Cube cube)
        {
            this.cube = cube;
        }

        /// <summary>
        /// Solves the cube
        /// </summary>
        public void solve()
        {
            makeCross();
        }

        /// <summary>
        /// 90 degree rotation of the cube in horizontal direction
        /// </summary>
        /// <param name="direction"></param>
        public void rotate90(Model.Direction direction)
        {
            cube.rotate(Model.CubeSurface.Top, direction);
            cube.rotate(Model.CubeSurface.Middle, direction);
            cube.rotate(Model.CubeSurface.Bottom, direction == Model.Direction.Right ? Model.Direction.Left : Model.Direction.Right);
        }

        /// <summary>
        /// First step in solving the cube
        /// making the cross at the top of the cube
        /// </summary>
        private void makeCross()
        {
            // Starting with the cross at the Top
            Model.Cubie topCenter = this.cube.getCubie(0,0,1);
            
            // get the front center cubie
            Model.Cubie frontCenter = this.cube.getCubie(1,0,0);
            Model.Cubie targetCubie = new Model.Cubie();

            // set the target Cubie
            targetCubie.PosX = topCenter.PosX + frontCenter.PosX; // 1
            targetCubie.PosY = topCenter.PosY + frontCenter.PosY; // 0 
            targetCubie.PosZ = topCenter.PosZ + frontCenter.PosZ; // 1
            targetCubie.ColX = frontCenter.ColX;
            targetCubie.ColY = Model.CubieColor.None;
            targetCubie.ColZ = topCenter.ColZ;

            //Model.Cubie tCubie = new Model.Cubie(Model.CubieType.Edge, 
            Model.Cubie currentCubie = this.cube.getCubie(frontCenter.ColX, topCenter.ColZ, Model.CubieColor.None);

            while (targetCubie.ColX != currentCubie.ColX)
            {
                while (targetCubie.ColY != currentCubie.ColY)
                {
                    while (targetCubie.ColZ != currentCubie.ColZ)
                    {
                        //if(currentCubie.PosX == 
                    }
                }
            }

        }
    }
}
