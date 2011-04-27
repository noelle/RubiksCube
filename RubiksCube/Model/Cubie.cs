using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Model
{
    public enum CubieType
    {
        Corner,
        Center,
        Edge
    }

    public enum CubieColor
    {
        O,
        Y,
        B,
        G,
        R,
        W,
        None
    }

    public class Cubie
    {
        private CubieType type;

        public CubieType Type
        {
            get { return type; }
            set { type = value; }
        }

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

        public Cubie() { }

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

        public Cubie(CubieColor colX, CubieColor colY, CubieColor colZ)
        {
            this.colX = colX;
            this.colY = colY;
            this.colZ = colZ;
        }

        public override bool Equals(object obj)
        {
            Cubie cmpCubie = (Cubie)obj;

            if (cmpCubie != null)
            {
                if (cmpCubie.posX == this.posX && cmpCubie.posY == this.posY && cmpCubie.posZ == this.posZ)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (13 * this.posX + 113 * this.posY + 373 * this.posZ - 71 * this.posZ);
        }

        /// <summary>
        /// Compares if the cubies contains the same colors
        /// </summary>
        /// <param name="cubie">Cubie to compare with</param>
        /// <returns>true or false</returns>
        public bool hasSameColors(Model.Cubie cubie)
        {
            return(this.colX == cubie.colX && this.colY == cubie.colY && this.colZ == cubie.colZ ||
                   this.colX == cubie.colX && this.colY == cubie.colZ && this.colZ == cubie.colY ||
                   this.colX == cubie.colY && this.colY == cubie.colX && this.colZ == cubie.colZ ||
                   this.colX == cubie.colY && this.colY == cubie.colZ && this.colZ == cubie.colX ||
                   this.colX == cubie.colZ && this.colY == cubie.colX && this.colZ == cubie.colY ||
                   this.colX == cubie.colZ && this.colY == cubie.colY && this.colZ == cubie.colX );
            
        }
    }
}
