using System;
using System.Linq;

namespace SudokuModels
{
    public class SudokuBoard
    {
        public SudokuBoard()
        {
            for(int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Subgrids[x, y] = new SudokuBoardSubgrid();
                }
            }
            for (uint x = 0; x < 9; x++)
            {
                var subgridX = x / 3;
                for(uint y = 0; y < 9; y++)
                {
                    var subgridY = y / 3;
                    array[x,y] = new SudokuSpace(this, Subgrids[subgridX,subgridY], x, y);    
                }
            }

        }
        internal readonly SudokuSpace[,] array = new SudokuSpace[9,9];
        public SudokuSpace this[int x,int y]
        {
            get
            {
                return array[x,y];
            }
        }
        public SudokuSpace this[uint x, uint y]
        {
            get
            {
                return array[x, y];
            }
        }
        public bool HasErrors { get
            {
                foreach(var item in array)
                {
                    if (item.HasErrors)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public bool IsCompletelyFilled
        {
            get
            {
                return false;
            }
        }
        private SudokuBoardSubgrid[,] Subgrids = new SudokuBoardSubgrid[3, 3];
    }
}
