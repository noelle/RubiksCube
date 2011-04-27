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
            makeTopCross();
            makeTopCorners();

            // rotate the cube 180 degree in vertical direction
            this.cube.rotateVertical90(Model.Direction.Right);
            this.cube.rotateVertical90(Model.Direction.Right);

            makeMiddleEdges();

            //// rotate the cube 180 degree in vertical direction
            //this.cube.rotateVertical90(Model.Direction.Right);
            //this.cube.rotateVertical90(Model.Direction.Right);

            makeBottomCross();



        }

        /// <summary>
        /// First step in solving the cube:
        /// Makes the cross at the top of the cube.
        /// </summary>
        private void makeTopCross()
        {
            // Starting with the cross at the Top
            Model.Cubie topCenter = this.Cube.getCubie(0, 0, 1);

            // solve the cross
            for (int i = 0; i < 4; i++)
            {
                // get the front center cubie
                Model.Cubie frontCenter = this.cube.getCubie(1, 0, 0);
                Model.Cubie currentCubie = this.cube.getCubie(frontCenter.ColX, topCenter.ColZ, Model.CubieColor.None);

                // place edges to the right place in the cross
                this.placeCrossEdge(currentCubie.GetHashCode());

                // check colors
                if (!(currentCubie.ColX == frontCenter.ColX && 
                    currentCubie.ColY == Model.CubieColor.None && 
                    currentCubie.ColZ == topCenter.ColZ))
                {
                    this.changeCrossEdgeColor();
                }

                this.cube.rotateHorizontal90(Model.Direction.Right);
            }
        }

        /// <summary>
        /// Places the found edge to the desired place in the cross.
        /// </summary>
        /// <param name="hashCode"></param>
        private void placeCrossEdge(int hashCode)
        {
            switch (hashCode)
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
        }

        /// <summary>
        /// Places the found corner to the desired place in the top.
        /// </summary>
        /// <param name="hashCode"></param>
        private void placeTopCorner(int hashCode)
        {
            switch (hashCode)
            {
                // Front
                case 428:
                    // 1;1;1 => nothing to do
                    break;
                case -428:
                    // -1;-1;-1 => Bo180
                    this.cube.rotateSurface180(Model.CubeSurface.Bottom);
                    break;
                case 402:
                    // -1;1;1 => BaL BoL BaR
                    this.cube.rotateSurface(Model.CubeSurface.Back, Model.Direction.Left);
                    this.cube.rotateSurface(Model.CubeSurface.Bottom, Model.Direction.Left);
                    this.cube.rotateSurface(Model.CubeSurface.Back, Model.Direction.Right);
                    break;
                case -402:
                    // 1;-1;-1 => BoR
                    this.cube.rotateSurface(Model.CubeSurface.Bottom, Model.Direction.Right);
                    break;
                case 202:
                    // 1;-1;1 => LR BoR LL
                    this.cube.rotateSurface(Model.CubeSurface.Left, Model.Direction.Right);
                    this.cube.rotateSurface(Model.CubeSurface.Bottom, Model.Direction.Right);
                    this.cube.rotateSurface(Model.CubeSurface.Left, Model.Direction.Left);
                    break;
                case -202:
                    // -1;1;-1 => BoL
                    this.cube.rotateSurface(Model.CubeSurface.Bottom, Model.Direction.Left);
                    break;
                case 176:
                    // -1;-1;1 => BaR Bo180 BaL
                    this.cube.rotateSurface(Model.CubeSurface.Back, Model.Direction.Right);
                    this.cube.rotateSurface180(Model.CubeSurface.Bottom);
                    this.cube.rotateSurface(Model.CubeSurface.Back, Model.Direction.Left);
                    break;
                case -176:
                    // 1;1;-1 => nothing to do
                    break;
            }
        }

        /// <summary>
        /// Algorithm to change the colors of the edges for the startup cross, if they are
        /// inverted.
        /// </summary>
        private void changeCrossEdgeColor()
        {
            // FR RL BoL RR F180
            this.cube.rotateSurface(Model.CubeSurface.Front, Model.Direction.Right);
            this.cube.rotateSurface(Model.CubeSurface.Right, Model.Direction.Left);
            this.cube.rotateSurface(Model.CubeSurface.Bottom, Model.Direction.Left);
            this.cube.rotateSurface(Model.CubeSurface.Right, Model.Direction.Right);
            this.cube.rotateSurface180(Model.CubeSurface.Front);
        }

        /// <summary>
        /// Second step of solving the cube:
        /// Places the top corners to the right place.
        /// </summary>
        private void makeTopCorners()
        {
            // get top center
            Model.Cubie topCenter = this.cube.getCubie(0, 0, 1);

            for (int i = 0; i < 4; i++)
            {
                // get front center
                Model.Cubie frontCenter = this.cube.getCubie(1, 0, 0);
                // get right center
                Model.Cubie rightCenter = this.cube.getCubie(0, 1, 0);

                // get current cubie
                Model.Cubie currentCubie = this.cube.getCubie(frontCenter.ColX, rightCenter.ColY, topCenter.ColZ);

                // place corners to the right place in top
                this.placeTopCorner(currentCubie.GetHashCode());

                // check for colors
                while (!(currentCubie.ColX == frontCenter.ColX &&
                    currentCubie.ColY == rightCenter.ColY &&
                    currentCubie.ColZ == topCenter.ColZ))
                {
                    this.changeTopCornerColor();
                }

                // go to next cube side
                this.cube.rotateHorizontal90(Model.Direction.Right);
            }
        }

        /// <summary>
        /// Algorithm to change the color of the top corners, if they are
        /// inverted.
        /// </summary>
        private void changeTopCornerColor()
        {
            // RL BoL RR BoR
            this.cube.rotateSurface(Model.CubeSurface.Right, Model.Direction.Left);
            this.cube.rotateSurface(Model.CubeSurface.Bottom, Model.Direction.Left);
            this.cube.rotateSurface(Model.CubeSurface.Right, Model.Direction.Right);
            this.cube.rotateSurface(Model.CubeSurface.Bottom, Model.Direction.Right);
        }

        /// <summary>
        /// Third step of solving the cube:
        /// Solves the middle layer of the cube.
        /// </summary>
        private void makeMiddleEdges()
        {
            for (int i = 0; i < 4; i++)
            {
                // get front center
                Model.Cubie frontCenter = this.cube.getCubie(1, 0, 0);
                // get right center
                Model.Cubie rightCenter = this.cube.getCubie(0, 1, 0);

                // get current cubie
                Model.Cubie currentCubie = this.cube.getCubie(frontCenter.ColX, rightCenter.ColY, Model.CubieColor.None);

                while (!(currentCubie.ColX == frontCenter.ColX && 
                    currentCubie.ColY == rightCenter.ColY && 
                    currentCubie.ColZ == Model.CubieColor.None &&
                    currentCubie.PosX == 1 &&
                    currentCubie.PosY == 1 &&
                    currentCubie.PosZ == 0))
                {
                    placeMiddleEdge(currentCubie.GetHashCode());

                    // get current cubie
                    currentCubie = this.cube.getCubie(frontCenter.ColX, rightCenter.ColY, Model.CubieColor.None);
                }
                

                // next surface
                this.cube.rotateHorizontal90(Model.Direction.Right);
            }
            
        }

        /// <summary>
        /// Places the found edge to the desired place in the middle layer of the cube.
        /// </summary>
        /// <param name="hashCode"></param>
        private void placeMiddleEdge(int hashCode)
        {
            switch (hashCode)
            {
                case 126:
                    // 1;1;0 => (TR RR TL RL TL FL TR FR)
                    this.moveTopEdgeToMiddleLayer();
                    break;
                case -126:
                    // -1;-1;0 => H180 (TR RR TL RL TL FL TR FR) H180
                    this.cube.rotateHorizontal180();
                    this.moveTopEdgeToMiddleLayer();
                    this.cube.rotateHorizontal180();
                    break;
                case 100:
                    // -1;1:0 => HR90 (TR RR TL RL TL FL TR FR) HL90
                    this.cube.rotateHorizontal90(Model.Direction.Right);
                    this.moveTopEdgeToMiddleLayer();
                    this.cube.rotateHorizontal90(Model.Direction.Left);
                    break;
                case -100:
                    // 1;-1:0 => HL90 (TR RR TL RL TL FL TR FR) HR90
                    this.cube.rotateHorizontal90(Model.Direction.Left);
                    this.moveTopEdgeToMiddleLayer();
                    this.cube.rotateHorizontal90(Model.Direction.Right);
                    break;
                case 315:
                    // 1;0;1 => (TR RR TL RL TL FL TR FR)
                    this.moveTopEdgeToMiddleLayer();
                    break;
                case 415:
                    // 0;1;1 => TR (TR RR TL RL TL FL TR FR)
                    this.cube.rotateSurface(Model.CubeSurface.Top, Model.Direction.Right);
                    this.moveTopEdgeToMiddleLayer();
                    break;
                case 289:
                    // -1;0;1 => T180 (TR RR TL RL TL FL TR FR)
                    this.cube.rotateSurface180(Model.CubeSurface.Top);
                    this.moveTopEdgeToMiddleLayer();
                    break;
                case 189:
                    // 0;-1;1 => TL (TR RR TL RL TL FL TR FR)
                    this.cube.rotateSurface(Model.CubeSurface.Top, Model.Direction.Left);
                    this.moveTopEdgeToMiddleLayer();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Puts the front top edge to the front right edge.
        /// </summary>
        private void moveTopEdgeToMiddleLayer()
        {
            this.cube.rotateSurface(Model.CubeSurface.Top, Model.Direction.Right);
            this.cube.rotateSurface(Model.CubeSurface.Right, Model.Direction.Right);
            this.cube.rotateSurface(Model.CubeSurface.Top, Model.Direction.Left);
            this.cube.rotateSurface(Model.CubeSurface.Right, Model.Direction.Left);
            this.cube.rotateSurface(Model.CubeSurface.Top, Model.Direction.Left);
            this.cube.rotateSurface(Model.CubeSurface.Front, Model.Direction.Left);
            this.cube.rotateSurface(Model.CubeSurface.Top, Model.Direction.Right);
            this.cube.rotateSurface(Model.CubeSurface.Front, Model.Direction.Right);
        }

        /// <summary>
        /// Fourth step of solving the cube:
        /// Makes the cross in the bottom
        /// </summary>
        private void makeBottomCross()
        {
            // viewing bottom as top
            Model.Cubie topCenter = this.cube.getCubie(0, 0, 1);
            int numberOfEdges = this.cube.Cubies.Where(q => q.Type == Model.CubieType.Edge && q.PosZ == 1 && q.ColZ == topCenter.ColZ).Count();

            while (numberOfEdges != 4)
            {
                // Falls 2 oder mehr dann entweder horizontal oder Ecke oder beides
                int numberOfVerticalEdges = this.cube.Cubies.Where(q => q.Type == Model.CubieType.Edge && q.PosZ == 1 && q.PosY == 0 && q.ColZ == topCenter.ColZ).Count();

                int numberOfHorizontalEdges = this.cube.Cubies.Where(q => q.Type == Model.CubieType.Edge && q.PosZ == 1 && q.PosX == 0 && q.ColZ == topCenter.ColZ).Count();

                if (numberOfHorizontalEdges == 2)
                {
                    // Algo für Bottom Cross
                }
                else if (numberOfHorizontalEdges == 2)
                {
                    // Drehen 90 grad, dann Algo für Bottom Cross
                    this.Cube.rotateHorizontal90(Model.Direction.Right);

                    // Algo für Bottom Cross
                }
                else if (numberOfEdges > 1)
                {
                    // drehen bis an richtiger Position => Verkehrtes "L" oben links

                    while (!(this.Cube.getCubie(0, -1, 1).ColZ == topCenter.ColZ &&
                            this.Cube.getCubie(-1, 0, 1).ColZ == topCenter.ColZ))
                    {
                        this.Cube.rotateHorizontal90(Model.Direction.Right);
                    }

                    // Algo für Bottom Cross

                }
                else
                {
                    // Algo für Bottom Cross
                }

                // Würfel von gleicher Farbe wie Center holen
                numberOfEdges = this.cube.Cubies.Where(q => q.Type == Model.CubieType.Edge && q.PosZ == 1 && q.ColZ == topCenter.ColZ).Count();
            }
            
        }
    }
}
