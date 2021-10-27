using System;
using Xunit;
using SudokuModels;
namespace SudokuModelTests
{
    public class SudokuBoardTests
    {
        [Fact]
        public void TestBoardInit()
        {
            var testBoard = new SudokuBoard();
            Assert.False(testBoard.HasErrors);
        }
    }
}
