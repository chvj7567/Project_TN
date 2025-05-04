using System;
using System.Collections.Generic;
using CHBattle;
using CHCard;
using CHItem;
using CHMission;
using UnityEngine;

public class MainUser : UserInfo
{
    public ItemSystem ItemSystem { get; private set; }
    public MissionSystem MissionSystem { get; private set; }
    public BattleSystem BattleSystem { get; private set; }
    public CardSystem CardSystem { get; private set; }

    public override void Init(long accountID, string nickname)
    {
        base.Init(accountID, nickname);

        ItemSystem = new ItemSystem();
        MissionSystem = new MissionSystem();
        BattleSystem = new BattleSystem();
        CardSystem = new CardSystem();
    }

    public void Clear()
    {
        ItemSystem.Clear();
        MissionSystem.Clear();
        BattleSystem.Clear();
        CardSystem.Clear();
    }
}