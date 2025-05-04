using System;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
    public long AccountID { get; private set; }
    public string Nickname { get; private set; }

    public virtual void Init(long accountID, string nickname)
    {
        AccountID = accountID;
        Nickname = nickname;
    }
}
