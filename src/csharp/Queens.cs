using System;

namespace csharp
{
    class QueensProblem
    {
        private int numberOfQueens;
        private bool solved;

        public QueensProblem(int numberOfQueens)
        {
            this.numberOfQueens = numberOfQueens;
        }

        private void SolveBT(int queen, Stack<int> column, Stack<int> upDiagonal, Stack<int> downDiagonal)
        {
            if (queen == numberOfQueens)
            {
                solved = true;
                return;
            }

            for (int k = 1; k <= numberOfQueens; k++){
                if (!column.Contains(k) && !upDiagonal.Contains(k - queen) && !downDiagonal.Contains(k + queen)){
                    column.Push(k);
                    upDiagonal.Push(k - queen);
                    downDiagonal.Push(k + queen);

                    SolveBT(queen + 1, column, upDiagonal, downDiagonal);

                    if (solved)
                        break;
                    
                    column.Pop();
                    upDiagonal.Pop();
                    downDiagonal.Pop();
                }
            }
        }
        public bool Solve()
        {
            solved = false;
            SolveBT(0, new Stack<int>(), new Stack<int>(), new Stack<int>());

            return solved;
        }
    }
}
