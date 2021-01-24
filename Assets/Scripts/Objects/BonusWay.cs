using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWay : ICrushable
{
    public int bonusAmount;
    
    public void CrashForBonus()
    {
        GameManager.Instance.bonusAmount = bonusAmount;
        int newPointAmount;
        newPointAmount = GameManager.Instance.PlayerCoinAmount * bonusAmount;
    }

    public void Crush(GameObject g){}
}
