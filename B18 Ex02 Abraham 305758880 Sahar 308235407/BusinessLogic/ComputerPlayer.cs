using System;
using System.Collections.Generic;
using BusinessLogic.GameBoard;

namespace BusinessLogic
{
    public class ComputerPlayer
    {
        public static Move SelectMoveAction(List<Move> i_AvailableMoves)
        {
            int selectionIndex = 0;
            Random moveSelector = new Random();

            selectionIndex = moveSelector.Next(0, i_AvailableMoves.Count);
            return i_AvailableMoves[selectionIndex];
        }
    }
}
