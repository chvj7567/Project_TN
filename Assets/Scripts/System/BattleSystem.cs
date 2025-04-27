using System.Collections.Generic;

namespace CHBattle
{
    public class BattleHistoryData
    {
        public int totalBattleCount;
        public int winCount;
        public int loseCount;
    }

    public class BattleCurrentData
    {
        public int ruleNumber;
        public int missionID;
        public List<int> liRemainCard;
    }

    public class BattleSystem
    {
        private BattleHistoryData _battleHistoryData = null;
        private BattleCurrentData _battleCurrentData = null;

        public BattleSystem()
        {
            _battleHistoryData = new BattleHistoryData();
            _battleCurrentData= new BattleCurrentData();
        }

        public void SetHistory(int winCount, int loseCount)
        {
            _battleHistoryData.totalBattleCount = winCount + loseCount;
            _battleHistoryData.winCount = winCount;
            _battleHistoryData.loseCount = loseCount;
        }

        public void SetCurrentBattle(int ruleNumber, int missionID)
        {
            _battleCurrentData.ruleNumber = ruleNumber;
            _battleCurrentData.missionID = missionID;
        }

        public void SetCurrentBattleCardList(List<int> liRemainCard)
        {
            _battleCurrentData.liRemainCard = liRemainCard;
        }
    }
}