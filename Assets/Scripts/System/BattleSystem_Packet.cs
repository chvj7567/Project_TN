using System.Collections.Generic;
using UnityEngine;

namespace CHBattle
{
    public partial class BattleSystem
    {
        #region Request/Response
        public void RequestMatchBattle()
        {
            //# 배틀 매칭 패킷
        }

        public void ResponseMatchBattle()
        {

        }

        public void RequestSelectCardDeck(List<int> liCardDeck)
        {
            //# 덱 선택 패킷
        }

        public void ResponseSelectCardDeck()
        {

        }

        public void RequestUseCard(int cardNumber)
        {
            //# 카드 사용 패킷
        }

        public void ResponseUseCard()
        {

        }
        #endregion Request/Response

        #region Notice
        public void NoticeStartBattle()
        {
            //# 배틀 시작 패킷
        }

        public void NoticeBattleRoundResult()
        {
            //# 배틀 라운드 결과 패킷
        }

        public void NoticeBattleFinalResult()
        {
            //# 배틀 최종 결과 패킷
        }

        public void NoticeBattleMission()
        {
            //# 배틀 미션 패킷
        }
        #endregion
    }
}
