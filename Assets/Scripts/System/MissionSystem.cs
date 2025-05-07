using System.Collections.Generic;
using CHItem;

namespace CHMission
{
    public class MissionData
    {
        public CommonEnum.EMissionType missionType;
        public int missionID;
        public float curValue;
        public float destValue;
        public CommonEnum.EMissionState missionState;
    }

    public partial class MissionSystem
    {
        private Dictionary<int, MissionData> _dicMission = null;

        public MissionSystem()
        {
            _dicMission = new Dictionary<int, MissionData>();
        }

        public void Clear()
        {
            _dicMission.Clear();
        }

        public void AddMission(MissionData missionData)
        {
            if (_dicMission.ContainsKey(missionData.missionID))
                return;

            _dicMission.Add(missionData.missionID, missionData);
        }

        public void UpdateMission(MissionData missionDatda)
        {
            if (_dicMission.TryGetValue(missionDatda.missionID, out MissionData value) == false)
                return;

            value.missionType = missionDatda.missionType;
            value.missionID = missionDatda.missionID;
            value.curValue = missionDatda.curValue;
            value.destValue = missionDatda.destValue;
            value.missionState = missionDatda.missionState;
        }

        public bool RemoveMission(int missionID)
        {
            if (_dicMission.ContainsKey(missionID) == false)
                return default;

            return _dicMission.Remove(missionID);
        }

        public MissionData GetMission(int missionID)
        {
            if (_dicMission.TryGetValue(missionID, out MissionData missionData) == false)
                return null;

            return missionData;
        }

        public void SetMissionCurrentValue(int missionID, int curValue)
        {
            MissionData missionData = GetMission(missionID);
            if (missionData == null)
                return;

            missionData.curValue = curValue;
        }

        public float GetMissionCurrentValue(int missionID)
        {
            MissionData missionData = GetMission(missionID);
            if (missionData == null)
                return default;

            return missionData.curValue;
        }

        public float GetMissionMaxValue(int missionID)
        {
            MissionData missionData = GetMission(missionID);
            if (missionData == null)
                return default;

            return missionData.destValue;
        }
    }
}