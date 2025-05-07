using System;
using System.Collections.Generic;
using UnityEngine;

namespace CHItem
{
    public partial class ItemSystem
    {
        #region Request/Response
        public void RequestAccountItemList()
        {
            //# 계정 아이템 리스트 요청 패킷
        }

        public void ResponseAccountItemList()
        {

        }
        #endregion Request/Response
        #region Notice
        public void NoticeAddItem()
        {
            //# 아이템 추가 패킷
        }

        public void NoticeUpdateItem()
        {
            //# 아이템 정보 변경 패킷
        }

        public void NoticeRemoveItem()
        {
            //# 아이템 삭제 패킷
        }
        #endregion Notice
    }
}
