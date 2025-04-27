using UnityEngine;

public class CommonEnum
{
    public enum EAddressableKey
    {
        UI,
        Json,
        Scene,
    }

    public enum EUI
    {
        None = 0,
        UIAlarm,
    }

    public enum EAudio
    {
        None = 0,
        BGM,
        Click,
    }

    public enum EJson
    {
        String,
    }

    public enum EFont
    {
        Arvo
    }

    public enum EAtlas
    {
        Item
    }

    public enum EScene
    {
        StartScene,
        TestScene,
    }

    public enum EItemAbililty
    {
        None = 0, //# 능력 없음
        EnhanceSuccessRateUp = 1, //# 강화 확률 증가
    }

    public enum EConstantValue
    {
        None = 0,
        BattleCardCount,
    }

    public enum EMissionType
    {
        None = 0,
        Battle_Win,
        Battle_Lose,
        Battle_Diff,
    }
}
