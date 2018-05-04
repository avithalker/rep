using System.Collections.Generic;
using BusinessLogic.Enums;

namespace BusinessLogic
{
    public class GlobalDefines
    {
        public const int k_MaxNameLength = 20;
        public static readonly List<int> rs_AllowedBoardSizes = new List<int> { 6, 8, 10 };

        public static char GetSoldierSign(ePlayerTitles i_PlayerTitle, eSoldierTypes i_SoldierType)
        {
            char soldierSign = 'X';

            switch (i_PlayerTitle)
            {
                case ePlayerTitles.PlayerOne:
                    {
                        switch (i_SoldierType)
                        {
                            case eSoldierTypes.Regular:
                                {
                                    soldierSign = 'O';
                                }

                                break;
                            case eSoldierTypes.King:
                                {
                                    soldierSign = 'U';
                                }

                                break;
                        }
                    }

                    break;
                case ePlayerTitles.PlayerTwo:
                    {
                        switch (i_SoldierType)
                        {
                            case eSoldierTypes.Regular:
                                {
                                    soldierSign = 'X';
                                }

                                break;
                            case eSoldierTypes.King:
                                {
                                    soldierSign = 'K';
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
