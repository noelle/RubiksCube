using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Model
{
    enum CubieType
    {
        Corner,
        Center,
        Edge
    }

    enum CubieColor
    {
        O,
        Y,
        B,
        G,
        R,
        W
    }

    public class Cubie
    {
        private CubieType type;

        /// <summary>
        /// Koordinate des Cubies in der Koordinaten-Achse des Cubes
        /// </summary>
        private int posX;
        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        private int posY;
        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        private int posZ;
        public int PosZ
        {
            get { return posZ; }
            set { posZ = value; }
        }

        /// <summary>
        /// Farben der Cubie Koordinaten-Flächen
        /// </summary>
        private CubieColor colX;
        public CubieColor ColX
        {
            get { return colX; }
            set { colX = value; }
        }

        private CubieColor colY;
        public CubieColor ColY
        {
            get { return colY; }
            set { colY = value; }
        }

        private CubieColor colZ;
        public CubieColor ColZ
        {
            get { return colZ; }
            set { colZ = value; }
        }

        public Cubie(CubieType type, int posX, int posY, int posZ, CubieColor colX, CubieColor colY, CubieColor colZ)
        {
            this.type = type;

            this.posX = posX;
            this.posY = posY;
            this.posZ = posZ;

            this.colX = colX;
            this.colY = colY;
            this.colZ = colZ;            
        }
    }
}
