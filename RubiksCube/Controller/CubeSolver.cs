﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Controller
{
    public class CubeSolver
    {
        private Model.Cube cube;

        public Model.Cube Cube
        {
            get { return cube; }
            set { cube = value; }
        }

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
        /// First step in solving the cube
        /// making the cross at the top of the cube
        /// </summary>
        private void makeCross()
        {
            // Starting with the cross at the Top
            Model.Cubie topCenter = this.Cube.getCubie(0, 0, 1);

            // solve the cross
            for (int i = 0; i < 4; i++)
            {
                // get the front center cubie
                Model.Cubie frontCenter = this.Cube.getCubie(1, 0, 0);
                Model.Cubie currentCubie = this.Cube.getCubie(frontCenter.ColX, topCenter.ColZ, Model.CubieColor.None);

                switch (currentCubie.GetHashCode())
                {
                    // Front
                    case 415:
                        break;
                    case -415:
                        break;
                    case 315:
                        // nothing to do
                        break;
                    case -315:
                        break;
                    case 289:
                        break;
                    case -289:
                        break;
                        // bis hier
                    case 189:
                        break;
                    case -189:
                        break;
                    case 126:
                        break;
                    case -126:
                        break;
                    case 100:
                        break;
                    case -100:
                        break;
                }

                // hier Farbe prüfen!!

                this.cube.rotate90(Model.Direction.Right);
            }



            //Model.Cubie targetCubie = new Model.Cubie();

            // set the target Cubie
            //targetCubie.PosX = topCenter.PosX + frontCenter.PosX; // 1
            //targetCubie.PosY = topCenter.PosY + frontCenter.PosY; // 0 
            //targetCubie.PosZ = topCenter.PosZ + frontCenter.PosZ; // 1
            //targetCubie.ColX = frontCenter.ColX;
            //targetCubie.ColY = Model.CubieColor.None;
            //targetCubie.ColZ = topCenter.ColZ;

            //Model.Cubie tCubie = new Model.Cubie(Model.CubieType.Edge, 
            //Model.Cubie currentCubie = this.Cube.getCubie(frontCenter.ColX, topCenter.ColZ, Model.CubieColor.None);

            //while (targetCubie.ColX != currentCubie.ColX)
            //{
            //    while (targetCubie.ColY != currentCubie.ColY)
            //    {
            //        while (targetCubie.ColZ != currentCubie.ColZ)
            //        {
            //            //if(currentCubie.PosX == 
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Changes the colors of the edges for the startup cross
        /// </summary>
        private void changeCrossEdgeColor()
        {
            this.cube.rotateSurface(Model.CubeSurface.Front, Model.Direction.Right);
            this.cube.rotateSurface(Model.CubeSurface.Right, Model.Direction.Left);
            this.cube.rotateSurface(Model.CubeSurface.Bottom, Model.Direction.Left);
            this.cube.rotateSurface(Model.CubeSurface.Right, Model.Direction.Right);
            this.cube.rotateSurface(Model.CubeSurface.Front, Model.Direction.Right);
            this.cube.rotateSurface(Model.CubeSurface.Front, Model.Direction.Right);
        }

        /// <summary>
        /// Rotates a cube surface around 180 degrees
        /// </summary>
        /// <param name="surface"></param>
        private void rotateSurface180(Model.CubeSurface surface)
        {
            this.cube.rotateSurface(surface, Model.Direction.Right);
            this.cube.rotateSurface(surface, Model.Direction.Right);
        }
    }
}
