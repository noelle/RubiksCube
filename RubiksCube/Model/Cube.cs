using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Model
{

    public enum Direction
    {
        Left,
        Right
    }

    public enum CubeSurface
    {
        Top,
        Front,
        Left,
        Right,
        Bottom,
        Back,
        MiddleHorizontal,
        MiddleVertical,
        MiddleCircular
    }

    public class Cube
    {
        List<Cubie> cubies;

        public List<Cubie> Cubies
        {
            get { return cubies; }
            set { cubies = value; }
        }

        private List<HistoryItem> history = new List<HistoryItem>();

        public List<HistoryItem> History
        {
            get { return history; }
            set { history = value; }
        }

        public Cube()
        {
            this.cubies = new List<Cubie>();

            // build the cube
            this.createCube();
        }

        private int numberSteps = 0;
        public int NumberSteps
        {
            get { return numberSteps; }
            set { numberSteps = value; }
        }

        /// <summary>
        /// Checks if the cube is solved
        /// </summary>
        public bool isSolved
        {
            get
            {
                return (isFrontSolved && isMiddleLayerSolved && isBackSolved);
            }
        }

        public bool isFrontSolved
        {
            get
            {
                return !(this.getCubeSurface(CubeSurface.Front).Any(q => q.ColX != this.getCubie(1, 0, 0).ColX));
            }
        }

        public bool isBackSolved
        {
            get
            {
                return !(this.getCubeSurface(CubeSurface.Back).Any(q => q.ColX != this.getCubie(-1, 0, 0).ColX));
            }
        }

        public bool isMiddleLayerSolved
        {
            get
            {
                return !(this.getCubeSurface(CubeSurface.Right).Any(q => q.ColY != this.getCubie(0, 1, 0).ColY) ||
                this.getCubeSurface(CubeSurface.Bottom).Any(q => q.ColZ != this.getCubie(0, 0, -1).ColZ) ||
                this.getCubeSurface(CubeSurface.Left).Any(q => q.ColY != this.getCubie(0, -1, 0).ColY) ||
                this.getCubeSurface(CubeSurface.Top).Any(q => q.ColZ != this.getCubie(0, 0, 1).ColZ));
            }
        }

        /// <summary>
        /// Checks if the first step of the top is solved
        /// </summary>
        public bool isTopCrossSolved
        {
            get
            {
                // check top cross colors
                int topCrossCubies = this.Cubies.Where(q => q.Type == CubieType.Edge && q.PosZ == 1 && q.ColZ == this.getCubie(0, 0, 1).ColZ).Count();

                if (topCrossCubies != 4)
                {
                    return false;
                }

                for (int i = 0; i < 4; i++)
                {
                    int frontCrossCubies = this.Cubies.Where(q => q.PosX == 1 && q.PosY == 0 && q.PosZ == 1 && q.ColX == this.getCubie(1, 0, 0).ColX).Count();

                    if (frontCrossCubies != 1)
                    {
                        return false;
                    }

                    this.rotateVertical90(Direction.Right, false);
                }
                return true;
            }
        }

        /// <summary>
        /// Checks if the first step of the bottom is solved
        /// </summary>
        public bool isBottomCrossSolved
        {
            get
            {
                // check bottom cross colors
                int topCrossCubies = this.Cubies.Where(q => q.Type == CubieType.Edge && q.PosZ == -1 && q.ColZ == this.getCubie(0, 0, -1).ColZ).Count();

                if (topCrossCubies != 4)
                {
                    return false;
                }

                for (int i = 0; i < 4; i++)
                {
                    int frontCrossCubies = this.Cubies.Where(q => q.PosX == 1 && q.PosY == 0 && q.PosZ == -1 && q.ColX == this.getCubie(1, 0, 0).ColX).Count();

                    if (frontCrossCubies != 1)
                    {
                        return false;
                    }

                    this.rotateVertical90(Direction.Right, false);
                }
                return true;
            }
        }

        /// <summary>
        /// Checks if the first step of the front is solved
        /// </summary>
        public bool isFrontCrossSolved
        {
            get
            {
                // check bottom cross colors
                int topCrossCubies = this.Cubies.Where(q => q.Type == CubieType.Edge && q.PosX == 1 && q.ColX == this.getCubie(1, 0, 0).ColX).Count();

                if (topCrossCubies != 4)
                {
                    return false;
                }

                for (int i = 0; i < 4; i++)
                {
                    int frontCrossCubies = this.Cubies.Where(q => q.PosX == 1 && q.PosY == 0 && q.PosZ == 1 && q.ColZ == this.getCubie(0, 0, 1).ColZ).Count();

                    if (frontCrossCubies != 1)
                    {
                        return false;
                    }

                    this.rotateCircular90(Direction.Right, false);
                }
                return true;
            }
        }

        /// <summary>
        /// Checks if the first step of the back is solved
        /// </summary>
        public bool isBackCrossSolved
        {
            get
            {
                // check bottom cross colors
                int backCrossCubies = this.Cubies.Where(q => q.Type == CubieType.Edge && q.PosX == -1 && q.ColX == this.getCubie(-1, 0, 0).ColX).Count();

                if (backCrossCubies != 4)
                {
                    return false;
                }

                for (int i = 0; i < 4; i++)
                {
                    int frontCrossCubies = this.Cubies.Where(q => q.PosX == -1 && q.PosY == 0 && q.PosZ == 1 && q.ColZ == this.getCubie(0, 0, 1).ColZ).Count();

                    if (frontCrossCubies != 1)
                    {
                        return false;
                    }

                    this.rotateCircular90(Direction.Right, false);
                }
                return true;
            }
        }

        /// <summary>
        /// Checks if the first step of the left is solved
        /// </summary>
        public bool isLeftCrossSolved
        {
            get
            {
                // check bottom cross colors
                int leftCrossCubies = this.Cubies.Where(q => q.Type == CubieType.Edge && q.PosY == -1 && q.ColY == this.getCubie(0, -1, 0).ColY).Count();

                if (leftCrossCubies != 4)
                {
                    return false;
                }

                for (int i = 0; i < 4; i++)
                {
                    int frontCrossCubies = this.Cubies.Where(q => q.PosX == 0 && q.PosY == -1 && q.PosZ == 1 && q.ColZ == this.getCubie(0, 0, 1).ColZ).Count();

                    if (frontCrossCubies != 1)
                    {
                        return false;
                    }

                    this.rotateVertical90(Direction.Right, false);
                }
                return true;
            }
        }

        /// <summary>
        /// Checks if the first step of the right is solved
        /// </summary>
        public bool isRightCrossSolved
        {
            get
            {
                // check bottom cross colors
                int rightCrossCubies = this.Cubies.Where(q => q.Type == CubieType.Edge && q.PosY == 1 && q.ColY == this.getCubie(0, 1, 0).ColY).Count();

                if (rightCrossCubies != 4)
                {
                    return false;
                }

                for (int i = 0; i < 4; i++)
                {
                    int frontCrossCubies = this.Cubies.Where(q => q.PosX == 0 && q.PosY == 1 && q.PosZ == 1 && q.ColZ == this.getCubie(0, 0, 1).ColZ).Count();

                    if (frontCrossCubies != 1)
                    {
                        return false;
                    }

                    this.rotateVertical90(Direction.Right, false);
                }
                return true;
            }
        }
        
        /// <summary>
        /// Creates a test cube
        /// </summary>
        private void createCube()
        {
            //Cubie frontCubie1 = new Cubie(CubieType.Corner, 1, -1, 1, CubieColor.Y, CubieColor.B, CubieColor.O);
            //Cubie frontCubie2 = new Cubie(CubieType.Edge, 1, 0, 1, CubieColor.R, CubieColor.None, CubieColor.W);
            //Cubie frontCubie3 = new Cubie(CubieType.Corner, 1, 1, 1, CubieColor.O, CubieColor.W, CubieColor.B);
            //Cubie frontCubie4 = new Cubie(CubieType.Edge, 1, -1, 0, CubieColor.G, CubieColor.Y, CubieColor.None);
            //Cubie frontCubie5 = new Cubie(CubieType.Center, 1, 0, 0, CubieColor.G, CubieColor.None, CubieColor.None);
            //Cubie frontCubie6 = new Cubie(CubieType.Edge, 1, 1, 0, CubieColor.R, CubieColor.B, CubieColor.None);
            //Cubie frontCubie7 = new Cubie(CubieType.Corner, 1, -1, -1, CubieColor.R, CubieColor.Y, CubieColor.B);
            //Cubie frontCubie8 = new Cubie(CubieType.Edge, 1, 0, -1, CubieColor.W, CubieColor.None, CubieColor.G);
            //Cubie frontCubie9 = new Cubie(CubieType.Corner, 1, 1, -1, CubieColor.R, CubieColor.W, CubieColor.B);

            //Cubie backCubie1 = new Cubie(CubieType.Corner, -1, -1, -1, CubieColor.Y, CubieColor.O, CubieColor.G);
            //Cubie backCubie2 = new Cubie(CubieType.Edge, -1, 0, -1, CubieColor.B, CubieColor.None, CubieColor.O);
            //Cubie backCubie3 = new Cubie(CubieType.Corner, -1, 1, -1, CubieColor.O, CubieColor.G, CubieColor.W);
            //Cubie backCubie4 = new Cubie(CubieType.Edge, -1, -1, 0, CubieColor.W, CubieColor.O, CubieColor.None);
            //Cubie backCubie5 = new Cubie(CubieType.Center, -1, 0, 0, CubieColor.B, CubieColor.None, CubieColor.None);
            //Cubie backCubie6 = new Cubie(CubieType.Edge, -1, 1, 0, CubieColor.Y, CubieColor.R, CubieColor.None);
            //Cubie backCubie7 = new Cubie(CubieType.Corner, -1, -1, 1, CubieColor.G, CubieColor.Y, CubieColor.R);
            //Cubie backCubie8 = new Cubie(CubieType.Edge, -1, 0, 1, CubieColor.O, CubieColor.None, CubieColor.Y);
            //Cubie backCubie9 = new Cubie(CubieType.Corner, -1, 1, 1, CubieColor.G, CubieColor.W, CubieColor.R);

            //Cubie middleCubie1 = new Cubie(CubieType.Edge, 0, -1, 1, CubieColor.None, CubieColor.B, CubieColor.W);
            //Cubie middleCubie2 = new Cubie(CubieType.Center, 0, 0, 1, CubieColor.None, CubieColor.None, CubieColor.W);
            //Cubie middleCubie3 = new Cubie(CubieType.Edge, 0, 1, 1, CubieColor.None, CubieColor.O, CubieColor.G);
            //Cubie middleCubie4 = new Cubie(CubieType.Center, 0, 1, 0, CubieColor.None, CubieColor.R, CubieColor.None);
            //Cubie middleCubie5 = new Cubie(CubieType.Edge, 0, 1, -1, CubieColor.None, CubieColor.B, CubieColor.Y);
            //Cubie middleCubie6 = new Cubie(CubieType.Center, 0, 0, -1, CubieColor.None, CubieColor.None, CubieColor.Y);
            //Cubie middleCubie7 = new Cubie(CubieType.Edge, 0, -1, -1, CubieColor.None, CubieColor.R, CubieColor.G);
            //Cubie middleCubie8 = new Cubie(CubieType.Center, 0, -1, 0, CubieColor.None, CubieColor.O, CubieColor.None);

            Cubie frontCubie1 = new Cubie(CubieType.Corner, 1, -1, 1, CubieColor.B, CubieColor.Y, CubieColor.R);
            Cubie frontCubie2 = new Cubie(CubieType.Edge, 1, 0, 1, CubieColor.W, CubieColor.None, CubieColor.R);
            Cubie frontCubie3 = new Cubie(CubieType.Corner, 1, 1, 1, CubieColor.W, CubieColor.B, CubieColor.O);
            Cubie frontCubie4 = new Cubie(CubieType.Edge, 1, -1, 0, CubieColor.G, CubieColor.R, CubieColor.None);
            Cubie frontCubie5 = new Cubie(CubieType.Center, 1, 0, 0, CubieColor.G, CubieColor.None, CubieColor.None);
            Cubie frontCubie6 = new Cubie(CubieType.Edge, 1, 1, 0, CubieColor.Y, CubieColor.O, CubieColor.None);
            Cubie frontCubie7 = new Cubie(CubieType.Corner, 1, -1, -1, CubieColor.W, CubieColor.R, CubieColor.B);
            Cubie frontCubie8 = new Cubie(CubieType.Edge, 1, 0, -1, CubieColor.Y, CubieColor.None, CubieColor.R);
            Cubie frontCubie9 = new Cubie(CubieType.Corner, 1, 1, -1, CubieColor.O, CubieColor.G, CubieColor.Y);

            Cubie backCubie1 = new Cubie(CubieType.Corner, -1, -1, -1, CubieColor.O, CubieColor.Y, CubieColor.B);
            Cubie backCubie2 = new Cubie(CubieType.Edge, -1, 0, -1, CubieColor.O, CubieColor.None, CubieColor.B);
            Cubie backCubie3 = new Cubie(CubieType.Corner, -1, 1, -1, CubieColor.R, CubieColor.W, CubieColor.G);
            Cubie backCubie4 = new Cubie(CubieType.Edge, -1, -1, 0, CubieColor.Y, CubieColor.B, CubieColor.None);
            Cubie backCubie5 = new Cubie(CubieType.Center, -1, 0, 0, CubieColor.B, CubieColor.None, CubieColor.None);
            Cubie backCubie6 = new Cubie(CubieType.Edge, -1, 1, 0, CubieColor.O, CubieColor.G, CubieColor.None);
            Cubie backCubie7 = new Cubie(CubieType.Corner, -1, -1, 1, CubieColor.Y, CubieColor.R, CubieColor.G);
            Cubie backCubie8 = new Cubie(CubieType.Edge, -1, 0, 1, CubieColor.G, CubieColor.None, CubieColor.W);
            Cubie backCubie9 = new Cubie(CubieType.Corner, -1, 1, 1, CubieColor.W, CubieColor.G, CubieColor.O);

            Cubie middleCubie1 = new Cubie(CubieType.Edge, 0, -1, 1, CubieColor.None, CubieColor.G, CubieColor.Y);
            Cubie middleCubie2 = new Cubie(CubieType.Center, 0, 0, 1, CubieColor.None, CubieColor.None, CubieColor.W);
            Cubie middleCubie3 = new Cubie(CubieType.Edge, 0, 1, 1, CubieColor.None, CubieColor.B, CubieColor.R);
            Cubie middleCubie4 = new Cubie(CubieType.Center, 0, 1, 0, CubieColor.None, CubieColor.R, CubieColor.None);
            Cubie middleCubie5 = new Cubie(CubieType.Edge, 0, 1, -1, CubieColor.None, CubieColor.B, CubieColor.W);
            Cubie middleCubie6 = new Cubie(CubieType.Center, 0, 0, -1, CubieColor.None, CubieColor.None, CubieColor.Y);
            Cubie middleCubie7 = new Cubie(CubieType.Edge, 0, -1, -1, CubieColor.None, CubieColor.O, CubieColor.W);
            Cubie middleCubie8 = new Cubie(CubieType.Center, 0, -1, 0, CubieColor.None, CubieColor.O, CubieColor.None);

            this.cubies.Add(frontCubie1);
            this.cubies.Add(frontCubie2);
            this.cubies.Add(frontCubie3);
            this.cubies.Add(frontCubie4);
            this.cubies.Add(frontCubie5);
            this.cubies.Add(frontCubie6);
            this.cubies.Add(frontCubie7);
            this.cubies.Add(frontCubie8);
            this.cubies.Add(frontCubie9);

            this.cubies.Add(backCubie1);
            this.cubies.Add(backCubie2);
            this.cubies.Add(backCubie3);
            this.cubies.Add(backCubie4);
            this.cubies.Add(backCubie5);
            this.cubies.Add(backCubie6);
            this.cubies.Add(backCubie7);
            this.cubies.Add(backCubie8);
            this.cubies.Add(backCubie9);

            this.cubies.Add(middleCubie1);
            this.cubies.Add(middleCubie2);
            this.cubies.Add(middleCubie3);
            this.cubies.Add(middleCubie4);
            this.cubies.Add(middleCubie5);
            this.cubies.Add(middleCubie6);
            this.cubies.Add(middleCubie7);
            this.cubies.Add(middleCubie8);
        }

        /// <summary>
        /// 90 degree rotation of the cube with rotation axis-y in horizontal direction
        /// </summary>
        /// <param name="direction">The direction (left/right) of the cube</param>
        public void rotateHorizontal90(Model.Direction direction, bool isRecorded = true)
        {
            string directionText = direction.ToString();

            rotateSurface(Model.CubeSurface.Top, direction, false);
            rotateSurface(Model.CubeSurface.MiddleHorizontal, direction, false);
            rotateSurface(Model.CubeSurface.Bottom, direction == Model.Direction.Right ? Model.Direction.Left : Model.Direction.Right, false);

            if (isRecorded)
            {
                // Step +1
                this.numberSteps++;
                this.History.Add(new Model.HistoryItem(this.Clone(), NumberSteps, String.Format("90 degree horizontal {0}", directionText)));
            }
        }

        /// <summary>
        /// Rotates the cube about 180 degrees in horizontal direction
        /// </summary>
        public void rotateHorizontal180()
        {
            rotateHorizontal90(Direction.Right, false);
            rotateHorizontal90(Direction.Right, false);

            // Step +1
            this.numberSteps++;
            this.History.Add(new Model.HistoryItem(this.Clone(), NumberSteps, String.Format("180 degree horizontal")));
        }

        /// <summary>
        /// 90 degree rotation of the cube with rotation axis-z in vertical direction
        /// </summary>
        /// <param name="direction">The direction (left/right) of the cube</param>
        public void rotateVertical90(Model.Direction direction, bool isRecorded = true)
        {
            string directionText = direction.ToString();

            rotateSurface(Model.CubeSurface.Right, direction, false);
            rotateSurface(Model.CubeSurface.MiddleVertical, direction, false);
            rotateSurface(Model.CubeSurface.Left, direction == Model.Direction.Right ? Model.Direction.Left : Model.Direction.Right, false);

            if (isRecorded)
            {
                // Step +1
                this.numberSteps++;
                this.History.Add(new Model.HistoryItem(this.Clone(), NumberSteps, String.Format("90 degree vertical {0}", directionText)));
            }

        }

        /// <summary>
        /// Rotates the cube about 180 degrees in vertical direction
        /// </summary>
        public void rotateVertical180()
        {
            rotateVertical90(Direction.Right, false);
            rotateVertical90(Direction.Right, false);

            // Step +1
            this.numberSteps++;
            this.History.Add(new Model.HistoryItem(this.Clone(), NumberSteps, String.Format("180 degree vertical")));
        }

        /// <summary>
        /// 90 degree rotation of the cube in circular with rotation axis-x direction
        /// </summary>
        /// <param name="direction">The direction (left/right) of the cube</param>
        public void rotateCircular90(Model.Direction direction, bool isRecorded = true)
        {
            string directionText = direction.ToString();

            rotateSurface(Model.CubeSurface.Front, direction, false);
            rotateSurface(Model.CubeSurface.MiddleCircular, direction, false);
            rotateSurface(Model.CubeSurface.Back, direction == Model.Direction.Right ? Model.Direction.Left : Model.Direction.Right, false);

            if (isRecorded)
            {
                // Step +1
                this.numberSteps++;
                this.History.Add(new Model.HistoryItem(this.Clone(), NumberSteps, String.Format("90 degree circular {0}", directionText)));
            }
        }

        /// <summary>
        /// Rotates the cube about 180 degrees in circular direction
        /// </summary>
        public void rotateCircular180()
        {
            rotateCircular90(Direction.Right, false);
            rotateCircular90(Direction.Right, false);

            // Step +1
            this.numberSteps++;
            this.History.Add(new Model.HistoryItem(this.Clone(), NumberSteps, String.Format("180 degree circular")));
        }

        /// <summary>
        /// Rotates a cube surface around 180 degrees
        /// </summary>
        /// <param name="surface">The direction (left/right) of the cube</param>
        public void rotateSurface180(Model.CubeSurface surface, bool isRecorded = true)
        {
            rotateSurface(surface, Model.Direction.Right, isRecorded);
            rotateSurface(surface, Model.Direction.Right, isRecorded);
        }

        /// <summary>
        /// Rotates a cube surface to a wished direction
        /// </summary>
        /// <param name="cubeSurface">The surface of the cube to rotate</param>
        /// <param name="direction">The direction (left/right) of the cube</param>
        public void rotateSurface(CubeSurface cubeSurface, Direction direction, bool isRecorded = true)
        {
            // get the cubies of the wished cube surface
            List<Cubie> cubies = this.getCubeSurface(cubeSurface);
            int tempPos;
            CubieColor tempCol;
            int multX = 1;
            int multY = 1;
            int multZ = 1;

            string surfaceText = cubeSurface.ToString();
            string directionText = direction.ToString();

            switch (cubeSurface)
            {
                case CubeSurface.Front:
                    multY = direction == Direction.Left ? -1 : 1;
                    multZ = direction == Direction.Right ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosY;
                        cubie.PosY = cubie.PosZ * multY;
                        cubie.PosZ = tempPos * multZ;

                        // change cubie colors
                        tempCol = cubie.ColY;
                        cubie.ColY = cubie.ColZ;
                        cubie.ColZ = tempCol;
                    }
                    break;

                case CubeSurface.Back:
                    multY = direction == Direction.Right ? -1 : 1;
                    multZ = direction == Direction.Left ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosY;
                        cubie.PosY = cubie.PosZ * multY;
                        cubie.PosZ = tempPos * multZ;

                        // change cubie colors
                        tempCol = cubie.ColY;
                        cubie.ColY = cubie.ColZ;
                        cubie.ColZ = tempCol;
                    }
                    break;

                case CubeSurface.Top:
                    multX = direction == Direction.Left ? -1 : 1;
                    multY = direction == Direction.Right ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosX;
                        cubie.PosX = cubie.PosY * multX;
                        cubie.PosY = tempPos * multY;

                        // change cubie colors
                        tempCol = cubie.ColY;
                        cubie.ColY = cubie.ColX;
                        cubie.ColX = tempCol;
                    }
                    break;

                case CubeSurface.Bottom:
                    multX = direction == Direction.Right ? -1 : 1;
                    multY = direction == Direction.Left ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        tempPos = cubie.PosX;
                        cubie.PosX = cubie.PosY * multX;
                        cubie.PosY = tempPos * multY;

                        // change cubie colors
                        tempCol = cubie.ColY;
                        cubie.ColY = cubie.ColX;
                        cubie.ColX = tempCol;
                    }
                    break;

                case CubeSurface.Left:
                    multX = direction == Direction.Left ? -1 : 1;
                    multZ = direction == Direction.Right ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosX;
                        cubie.PosX = cubie.PosZ * multX;
                        cubie.PosZ = tempPos * multZ;

                        // change cubie colors
                        tempCol = cubie.ColZ;
                        cubie.ColZ = cubie.ColX;
                        cubie.ColX = tempCol;
                    }
                    break;

                case CubeSurface.Right:
                    multX = direction == Direction.Right ? -1 : 1;
                    multZ = direction == Direction.Left ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosX;
                        cubie.PosX = cubie.PosZ * multX;
                        cubie.PosZ = tempPos * multZ;

                        // change cubie colors
                        tempCol = cubie.ColZ;
                        cubie.ColZ = cubie.ColX;
                        cubie.ColX = tempCol;
                    }
                    break;
                case CubeSurface.MiddleHorizontal:
                    multX = direction == Direction.Left ? -1 : 1;
                    multY = direction == Direction.Right ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosX;
                        cubie.PosX = cubie.PosY * multX;
                        cubie.PosY = tempPos * multY;

                        // change cubie colors
                        tempCol = cubie.ColY;
                        cubie.ColY = cubie.ColX;
                        cubie.ColX = tempCol;
                    }
                    break;
                case CubeSurface.MiddleVertical:
                    multX = direction == Direction.Right ? -1 : 1;
                    multZ = direction == Direction.Left ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosX;
                        cubie.PosX = cubie.PosZ * multX;
                        cubie.PosZ = tempPos * multZ;

                        // change cubie colors
                        tempCol = cubie.ColZ;
                        cubie.ColZ = cubie.ColX;
                        cubie.ColX = tempCol;
                    }
                    break;
                case CubeSurface.MiddleCircular:
                    multY = direction == Direction.Left ? -1 : 1;
                    multZ = direction == Direction.Right ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosY;
                        cubie.PosY = cubie.PosZ * multY;
                        cubie.PosZ = tempPos * multZ;

                        // change cubie colors
                        tempCol = cubie.ColY;
                        cubie.ColY = cubie.ColZ;
                        cubie.ColZ = tempCol;
                    }
                    break;

                default:
                    break;

            }

            if (isRecorded)
            {
                // Step +1
                this.numberSteps++;
                this.History.Add(new HistoryItem(this.Clone(), numberSteps, String.Format("{0} {1}", surfaceText, directionText)));
            }

        }

        /// <summary>
        /// 2D Output of the cube in console
        /// </summary>
        public void drawInConsole()
        {
            System.Console.WriteLine();

            // Obere Reihe
            List<CubieColor> topCubies = this.cubies.Where(q => q.PosZ == 1).OrderBy(q => q.PosX).ThenBy(q => q.PosY).Select(q => q.ColZ).ToList();
            System.Console.WriteLine("    {0}{1}{2}   ", topCubies.ElementAt(0), topCubies.ElementAt(1), topCubies.ElementAt(2));
            System.Console.WriteLine("    {0}{1}{2}   ", topCubies.ElementAt(3), topCubies.ElementAt(4), topCubies.ElementAt(5));
            System.Console.WriteLine("    {0}{1}{2}   ", topCubies.ElementAt(6), topCubies.ElementAt(7), topCubies.ElementAt(8));
            System.Console.WriteLine("    ---   ");

            // Mittlere 1. Reihe
            List<CubieColor> midCubies1 = this.cubies.Where(q => q.PosY == -1 && q.PosZ == 1).OrderBy(q => q.PosX).Select(q => q.ColY).ToList();
            midCubies1.AddRange(this.cubies.Where(q => q.PosX == 1 && q.PosZ == 1).OrderBy(q => q.PosY).Select(q => q.ColX).ToList());
            midCubies1.AddRange(this.cubies.Where(q => q.PosY == 1 && q.PosZ == 1).OrderByDescending(q => q.PosX).Select(q => q.ColY).ToList());
            System.Console.WriteLine("{0}{1}{2}|{3}{4}{5}|{6}{7}{8}", midCubies1.ElementAt(0), midCubies1.ElementAt(1), midCubies1.ElementAt(2),
                midCubies1.ElementAt(3), midCubies1.ElementAt(4), midCubies1.ElementAt(5),
                midCubies1.ElementAt(6), midCubies1.ElementAt(7), midCubies1.ElementAt(8));

            // Mittlere 2. Reihe
            List<CubieColor> midCubies2 = this.cubies.Where(q => q.PosY == -1 && q.PosZ == 0).OrderBy(q => q.PosX).Select(q => q.ColY).ToList();
            midCubies2.AddRange(this.cubies.Where(q => q.PosX == 1 && q.PosZ == 0).OrderBy(q => q.PosY).Select(q => q.ColX).ToList());
            midCubies2.AddRange(this.cubies.Where(q => q.PosY == 1 && q.PosZ == 0).OrderByDescending(q => q.PosX).Select(q => q.ColY).ToList());
            System.Console.WriteLine("{0}{1}{2}|{3}{4}{5}|{6}{7}{8}", midCubies2.ElementAt(0), midCubies2.ElementAt(1), midCubies2.ElementAt(2),
                midCubies2.ElementAt(3), midCubies2.ElementAt(4), midCubies2.ElementAt(5),
                midCubies2.ElementAt(6), midCubies2.ElementAt(7), midCubies2.ElementAt(8));

            // Mittlere 3. Reihe
            List<CubieColor> midCubies3 = this.cubies.Where(q => q.PosY == -1 && q.PosZ == -1).OrderBy(q => q.PosX).Select(q => q.ColY).ToList();
            midCubies3.AddRange(this.cubies.Where(q => q.PosX == 1 && q.PosZ == -1).OrderBy(q => q.PosY).Select(q => q.ColX).ToList());
            midCubies3.AddRange(this.cubies.Where(q => q.PosY == 1 && q.PosZ == -1).OrderByDescending(q => q.PosX).Select(q => q.ColY).ToList());
            System.Console.WriteLine("{0}{1}{2}|{3}{4}{5}|{6}{7}{8}", midCubies3.ElementAt(0), midCubies3.ElementAt(1), midCubies3.ElementAt(2),
                midCubies3.ElementAt(3), midCubies3.ElementAt(4), midCubies3.ElementAt(5),
                midCubies3.ElementAt(6), midCubies3.ElementAt(7), midCubies3.ElementAt(8));
            System.Console.WriteLine("    ---   ");

            // Untere Reihe
            List<CubieColor> bottomCubies = this.cubies.Where(q => q.PosZ == -1).OrderByDescending(q => q.PosX).ThenBy(q => q.PosY).Select(q => q.ColZ).ToList();
            System.Console.WriteLine("    {0}{1}{2}   ", bottomCubies.ElementAt(0), bottomCubies.ElementAt(1), bottomCubies.ElementAt(2));
            System.Console.WriteLine("    {0}{1}{2}   ", bottomCubies.ElementAt(3), bottomCubies.ElementAt(4), bottomCubies.ElementAt(5));
            System.Console.WriteLine("    {0}{1}{2}   ", bottomCubies.ElementAt(6), bottomCubies.ElementAt(7), bottomCubies.ElementAt(8));
            System.Console.WriteLine("    ---   ");

            // Hintere Reihe
            List<CubieColor> backCubies = this.cubies.Where(q => q.PosX == -1).OrderBy(q => q.PosZ).ThenBy(q => q.PosY).Select(q => q.ColX).ToList();
            System.Console.WriteLine("    {0}{1}{2}   ", backCubies.ElementAt(0), backCubies.ElementAt(1), backCubies.ElementAt(2));
            System.Console.WriteLine("    {0}{1}{2}   ", backCubies.ElementAt(3), backCubies.ElementAt(4), backCubies.ElementAt(5));
            System.Console.WriteLine("    {0}{1}{2}   ", backCubies.ElementAt(6), backCubies.ElementAt(7), backCubies.ElementAt(8));

        }

        /// <summary>
        /// Returns a list of all of the cubies of a cube surface
        /// </summary>
        /// <param name="surface">the cube surface</param>
        /// <returns>List of the cubies of the cube surface</returns>
        private List<Cubie> getCubeSurface(CubeSurface surface)
        {
            List<Cubie> cubies;

            switch (surface)
            {
                case CubeSurface.Front:
                    cubies = this.cubies.Where(q => q.PosX == 1).ToList();
                    break;

                case CubeSurface.Back:
                    cubies = this.cubies.Where(q => q.PosX == -1).ToList();
                    break;

                case CubeSurface.Left:
                    cubies = this.cubies.Where(q => q.PosY == -1).ToList();
                    break;

                case CubeSurface.Right:
                    cubies = this.cubies.Where(q => q.PosY == 1).ToList();
                    break;

                case CubeSurface.Top:
                    cubies = this.cubies.Where(q => q.PosZ == 1).ToList();
                    break;

                case CubeSurface.Bottom:
                    cubies = this.cubies.Where(q => q.PosZ == -1).ToList();
                    break;

                case CubeSurface.MiddleHorizontal:
                    cubies = this.cubies.Where(q => q.PosZ == 0).ToList();
                    break;
                case CubeSurface.MiddleVertical:
                    cubies = this.cubies.Where(q => q.PosY == 0).ToList();
                    break;
                case CubeSurface.MiddleCircular:
                    cubies = this.cubies.Where(q => q.PosX == 0).ToList();
                    break;
                default:
                    cubies = null;
                    break;
            }

            return cubies;
        }

        /// <summary>
        /// Returns a cubie by colors
        /// </summary>
        /// <param name="col1">color 1</param>
        /// <param name="col2">color 2</param>
        /// <param name="col3">color 3</param>
        /// <returns></returns>
        public Cubie getCubie(CubieColor col1, CubieColor col2, CubieColor col3)
        {
            Cubie cube = this.cubies.Where(q => ((q.ColX == col1 && q.ColY == col2 && q.ColZ == col3) ||
                                                (q.ColX == col1 && q.ColY == col3 && q.ColZ == col2) ||
                                                (q.ColX == col2 && q.ColY == col1 && q.ColZ == col3) ||
                                                (q.ColX == col2 && q.ColY == col3 && q.ColZ == col1) ||
                                                (q.ColX == col3 && q.ColY == col1 && q.ColZ == col2) ||
                                                (q.ColX == col3 && q.ColY == col2 && q.ColZ == col1))).Select(q => q).FirstOrDefault();
            return cube;
        }

        /// <summary>
        /// Returns a Cubie by X-, Y- and Z-position
        /// </summary>
        /// <param name="posX">X-position</param>
        /// <param name="posY">Y-position</param>
        /// <param name="posZ">Z-position</param>
        /// <returns></returns>
        public Cubie getCubie(int posX, int posY, int posZ)
        {
            return this.cubies.Where(q => q.PosX == posX && q.PosY == posY && q.PosZ == posZ).Select(q => q).FirstOrDefault();
        }

        public Cube Clone()
        {
            Cube clone = new Cube();
            clone.cubies.Clear();

            foreach (Cubie cloneCubie in this.cubies)
            {
                clone.cubies.Add(cloneCubie.Clone());
            }

            return clone;
        }
    }
}
