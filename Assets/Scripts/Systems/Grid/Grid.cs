using UnityEngine;
using System.Collections;


namespace BlockCity
{
    public class Grid2d
    {
        public Block[,] Grid { get; private set; }

        public int Size { get; private set; }


        public Grid2d(int size)
        {
            Grid = new Block[size, size];

            this.Size = size;
        }

        public bool AddBlock(Block block, Vector3 pos)
        {
            return AddBlock(block, (int)pos.x, (int)pos.z);
        }
        
        public bool AddBlock(Block block, int x, int y)
        {
            if (!IsFree(x, y))
            {
                return false;
            }

            Grid[x, y] = block;

            return true;
        }

        public bool IsFree(Vector3 pos)
        {
            return IsFree((int)pos.x, (int)pos.z);
        }


        public bool IsFree(int x, int y)
        {
			if (!IsValid(x, y))
            {
                return false;
            }

			bool result = GetBlock(x, y) == null;

			if (!result)
				Debug.Log ("Grid[" + x + "," + y + "] " + (result ? "Free" : "Not Free") );

			return result;
        }

        public bool IsValid(int x, int y)
        {
			bool result = x < Size && y < Size && x >= 0 && y >= 0;

			if (!result)
				Debug.Log ("Grid[" + x + "," + y + "] " + (result ? "Valid" : "Invalid") );

			return result;
        }

        public Block GetBlock(int x, int y)
        {
            /*if (!IsValid(x, y))
            {
                return null;
            }*/

            return Grid[x, y];
        }
    }
}