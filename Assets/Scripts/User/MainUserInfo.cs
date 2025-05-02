using System;
using System.Collections.Generic;
using CHBattle;
using CHCard;
using CHItem;
using CHMission;
using UnityEngine;

public class MainUserInfo : UserInfo
{
    private ItemSystem _itemSystem;
    private MissionSystem _missionSystem;
    private BattleSystem _battleSystem;
    private CardSystem _cardSystem;

    public void Init(long accountID, string nickname)
    {
        AccountID = accountID;
        Nickname = nickname;

        _itemSystem = new ItemSystem();
        _missionSystem = new MissionSystem();
        _battleSystem = new BattleSystem();
        _cardSystem = new CardSystem();
    }

    public void Clear()
    {
        _itemSystem.Clear();
        _missionSystem.Clear();
        _battleSystem.Clear();
        _cardSystem.Clear();
    }

    public void UseCard(int cardNumber)
    {
        if (_battleSystem.UseCard(cardNumber) == false)
            return;

        //# 미션 정보 패킷 보내기
        int missionID = _battleSystem.GetBattleMissionID();
    }
}