using System;
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
                Model.Cubie frontCenter = this.cube.getCubie(1, 0, 0);
                Model.Cubie currentCubie = this.cube.getCubie(frontCenter.ColX, topCenter.ColZ, Model.CubieColor.None);

                switch (currentCubie.GetHashCode())
                {
                    // Front
                    case 415:
                        // 0;1;1 => RL FL RR
                        this.cube.rotateSurface(Model.CubeSurface.Right, Model.Direction.Left);
                        this.cube.rotateSurface(Model.CubeSurface.Front, Model.Direction.Left);
                        this.cube.rotateSurface(Model.CubeSurface.Right, Model.Direction.Right);
                        break;
                    case -415:
                        // 0:-1;-1 => BoR F180
                        this.cube.rotateSurface(Model.CubeSurface.Bottom, Model.Direction.Right);
                        this.cube.rotateSurface180(Model.CubeSurface.Front);
                        break;
                    case 315:
                        // 1;0;1 => nothing to do
                        break;
                    case -315:
                        // -1;0;-1 => Bo180 F180
                        this.cube.rotateSurface180(Model.CubeSurface.Bottom);
                        this.cube.rotateSurface180(Model.CubeSurface.Front);
                        break;
                    case 289:
                        // -1;0;1 => Ba180 Bo180 F180
                        this.cube.rotateSurface180(Model.CubeSurface.Back);
                        this.cube.rotateSurface180(Model.CubeSurface.Bottom);
                        this.cube.rotateSurface180(Model.CubeSurface.Front);
                        break;
                    case -289:
                        // 1;0;-1 => F180
                        this.cube.rotateSurface180(Model.CubeSurface.Front);
                        break;
                    case 189:
                        // 0;-1;1 => LR FR LL
                        this.cube.rotateSurface(Model.CubeSurface.Left, Model.Direction.Right);
                        this.cube.rotateSurface(Model.CubeSurface.Front, Model.Direction.Right);
                        this.cube.rotateSurface(Model.CubeSurface.Left, Model.Direction.Left);
                        break;
                    case -189:
                        // 0;1;-1 => BoL F180
                        this.cube.rotateSurface(Model.CubeSurface.Bottom, Model.Direction.Left);
                        this.cube.rotateSurface180(Model.CubeSurface.Front);
                        break;
                    case 126:
                        // 1;1;0 => FL
                        this.cube.rotateSurface(Model.CubeSurface.Front, Model.Direction.Left);
                        break;
                    case -126:
                        // -1;-1;0 => BaR Bo180 BaL F180
                        this.cube.rotateSurface(Model.CubeSurface.Back, Model.Direction.Right);
                        this.cube.rotateSurface180(Model.CubeSurface.Bottom);
                        this.cube.rotateSurface(Model.CubeSurface.Back, Model.Direction.Left);
                        this.cube.rotateSurface180(Model.CubeSurface.Front);
                        break;
                    case 100:
                        // -1;1;0 => BaL Bo180 BaR F180
                        this.cube.rotateSurface(Model.CubeSurface.Back, Model.Direction.Left);
                        this.cube.rotateSurface180(Model.CubeSurface.Bottom);
                        this.cube.rotateSurface(Model.CubeSurface.Back, Model.Direction.Right);
                        this.cube.rotateSurface180(Model.CubeSurface.Front);
                        break;
                    case -100:
                        // 1;-1;0 => FR
                        this.cube.rotateSurface(Model.CubeSurface.Front, Model.Direction.Right);
                        break;
                }

                // hier Farbe prüfen!!
                if (!(currentCubie.ColX == frontCenter.ColX && 
                    currentCubie.ColY == Model.CubieColor.None && 
                    currentCubie.ColZ == topCenter.ColZ))
                {
                    this.changeCrossEdgeColor();
                }

                this.cube.rotate90(Model.Direction.Right);
            }
        }

        private void getCrossEdges(int hashCode)
        {

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
    }
}
