using System;
using System.Collections.Generic;
using CHBattle;
using UnityEngine;

public class OtherUser : UserInfo
{
    public BattleSystem BattleSystem { get; private set; }

    public override void Init(long accountID, string nickname)
    {
        base.Init(accountID, nickname);

        BattleSystem = new BattleSystem();
    }

    public void Clear()
    {
        BattleSystem.Clear();
    }
}
