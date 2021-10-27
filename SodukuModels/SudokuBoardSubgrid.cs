using System;
using System.Collections.Generic;
namespace SudokuModels
{
    public class SudokuBoardSubgrid
    {
        public SudokuBoardSubgrid()
        {

        }
        public List<SudokuSpace> Spaces { get; } = new List<SudokuSpace>();
    }
}
