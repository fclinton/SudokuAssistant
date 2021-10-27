using System;
using System.Collections.Generic;
using System.Linq;
namespace SudokuModels
{
    public class SudokuSpace:IComparable<SudokuSpace>,IEquatable<SudokuSpace>
    {
        private readonly SudokuBoard board;
        private readonly SudokuBoardSubgrid subgrid;

        public SudokuSpace(SudokuBoard board, SudokuBoardSubgrid subgrid, uint x,uint y,uint? Value = null, bool IsGiven = false)
        {
            this.IsGiven = IsGiven;
            this.Value = Value;
            this.board = board ?? throw new ArgumentNullException(nameof(board));
            this.subgrid = subgrid ?? throw new ArgumentNullException(nameof(subgrid));
            this.X = x;
            this.Y = y;
            this.subgrid.Spaces.Add(this);
        }
        public bool IsKnown
        {
            get
            {
                return IsGiven;
            }
        }
        public List<SudokuSpace> ConfictingSpaces
        {
            get
            {
                var returnList = new List<SudokuSpace>();
                returnList.AddRange(subgrid.Spaces.AsParallel().Where(x => x.Equals(this)));
                returnList.AddRange(Enumerable.Range(0, 9).AsParallel().Select(y => board[X, (uint)y]).Where(space => space.Equals(this)));
                returnList.AddRange(Enumerable.Range(0, 9).AsParallel().Select(x => board[(uint)x, Y]).Where(space => space.Equals(this)));
                return returnList;
            }
        }
        public bool HasErrors
        {
            get
            {
                List<Func<bool>> Functions = new List<Func<bool>>()
                {
                    ()=>Enumerable.Range(0, 9).AsParallel().Select(y => board[X, (uint)y]).Any(space => space.Equals(this)),
                    ()=>Enumerable.Range(0, 9).AsParallel().Select(x => board[x, (int)Y]).Any(space => space.Equals(this)),
                    ()=>subgrid.Spaces.AsParallel().Any(x => x.Equals(this)),
                };
                return Functions.AsParallel().Any(x => x.Invoke());
            }
        }




        public uint? Value { set; get; }
        public bool IsGiven { set; get; }
        public uint X { private set; get; }
        public uint Y { private set; get; }
        ///<inheritdoc/>
        public int CompareTo(SudokuSpace other)
        {
            throw new NotImplementedException();
        }
        ///<inheritdoc/>
        public bool Equals(SudokuSpace other)
        {
            if(this.Value.HasValue && other.Value.HasValue)
            {
                return this.Value.Equals(other.Value);
            }
            else
            {
                return false;
            }
        }
    }
}
