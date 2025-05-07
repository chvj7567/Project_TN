using System;
using System.Collections.Generic;
using UnityEngine;

namespace CHMission
{
    public partial class MissionSystem
    {
        #region Request/Response
        public void RequestAccountMissionList()
        {
            //# 계정 미션 리스트 요청 패킷
        }

        public void ResponseAccountMissionList()
        {

        }

        public void RequestMissionReward(List<int> liMissionID)
        {
            //# 미션 보상 패킷
        }

        public void ResponseMissionReward()
        {

        }
        #endregion Request/Response

        #region Notice
        public void NoticeUpdateMissionState()
        {
            //# 미션 상태 변경 패킷
        }
        #endregion Notice
    }
}
