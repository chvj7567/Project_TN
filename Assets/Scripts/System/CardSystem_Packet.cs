using System;
using System.Collections.Generic;
using UnityEngine;

namespace CHCard
{
    public partial class CardSystem
    {
        #region Request/Response
        public void RequestAccountCardList()
        {
            //# 계정 카드 리스트 요청 패킷
        }

        public void ResponseAccountCardList()
        {

        }
        #endregion Request/Response

        #region Notice
        public void NoticeAddCard()
        {
            //# 카드 추가 패킷
        }

        public void NoticeUpdateCard()
        {
            //# 카드 정보 변경 패킷
        }

        public void NoticeRemoveCard()
        {
            //# 카드 삭제 패킷
        }
        #endregion Notice
    }
}