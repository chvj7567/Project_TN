using System.Collections.Generic;
using UnityEngine;

namespace CHBattle
{
    public partial class BattleSystem
    {
        #region Request/Response
        public void RequestMatchBattle()
        {
            //# ��Ʋ ��Ī ��Ŷ
        }

        public void ResponseMatchBattle()
        {

        }

        public void RequestSelectCardDeck(List<int> liCardDeck)
        {
            //# �� ���� ��Ŷ
        }

        public void ResponseSelectCardDeck()
        {

        }

        public void RequestUseCard(int cardNumber)
        {
            //# ī�� ��� ��Ŷ
        }

        public void ResponseUseCard()
        {

        }
        #endregion Request/Response

        #region Notice
        public void NoticeStartBattle()
        {
            //# ��Ʋ ���� ��Ŷ
        }

        public void NoticeBattleRoundResult()
        {
            //# ��Ʋ ���� ��� ��Ŷ
        }

        public void NoticeBattleFinalResult()
        {
            //# ��Ʋ ���� ��� ��Ŷ
        }

        public void NoticeBattleMission()
        {
            //# ��Ʋ �̼� ��Ŷ
        }
        #endregion
    }
}
