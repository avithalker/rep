using System.Collections.Generic;
using BusinessLogic.Enums;

namespace BusinessLogic
{
    public class GlobalDefines
    {
        public const int k_MaxNameLength = 20;
        public static readonly List<int> rs_AllowedBoardSizes = new List<int> { 6, 8, 10 };

        public static char GetSoldierSign(PlayerTitles.ePlayerTitles i_PlayerTitle, SoldierTypes.eSoldierTypes i_SoldierType)
        {
            char soldierSign = 'X';

            switch (i_PlayerTitle)
            {
                case PlayerTitles.ePlayerTitles.PlayerOne:
                    {
                        switch (i_SoldierType)
                        {
                            case SoldierTypes.eSoldierTypes.Regular:
                                {
                                    soldierSign = 'X';
                                }

                                break;
                            case SoldierTypes.eSoldierTypes.King:
                                {
                                    soldierSign = 'K';
                                }

                                break;
                        }
                    }

                    break;
                case PlayerTitles.ePlayerTitles.PlayerTwo:
                    {
                        switch (i_SoldierType)
                        {
                            case SoldierTypes.eSoldierTypes.Regular:
                                {
                                    soldierSign = 'O';
                                }

                                break;
                            case SoldierTypes.eSoldierTypes.King:
                                {
                                    soldierSign = 'U';
                                }

                                break;
                        }
                    }

                    break;
            }

            return soldierSign;
        }
    }
}
