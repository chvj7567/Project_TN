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
        ItemBase,
        ItemAbility,
        ConstantValue,
        MissionBase,
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
        None = 0, //# �ɷ� ����
        EnhanceSuccessRateUp = 1, //# ��ȭ Ȯ�� ����
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
        UseCard,
    }

    public enum EMissionState
    {
        None = 0,
        InProgess, //# �̼� ���� ��
        Completed, //# �̼� �Ϸ�(���� �ޱ� ��)
        RecvRewarded, //# �̼� �Ϸ�(���� ���� ��)
    }
}
