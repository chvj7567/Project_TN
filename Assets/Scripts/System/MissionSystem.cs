using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using UnityEngine;

namespace CHMission
{
    public class MissionData
    {
        public int missionID;
        public float curValue;
        public float maxValue;
    }

    public class MissionSystem
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

            return missionData.maxValue;
        }
    }
}