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

    public abstract class Cubie
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
        private string colX;
        public string ColX
        {
            get { return colX; }
            set { colX = value; }
        }

        private string colY;
        public string ColY
        {
            get { return colY; }
            set { colY = value; }
        }

        private string colZ;
        public string ColZ
        {
            get { return colZ; }
            set { colZ = value; }
        }
        

        public Cubie(CubieType type, int xPos, int yPos, int zPos, string xCol, string yCol, string zCol)
        {
            this.type = type;

            this.posX = xPos;
            this.posY = yPos;
            this.posZ = zPos;

            this.colX = xCol;
            this.colY = yCol;
            this.colZ = zCol;            
        }
    }
}
