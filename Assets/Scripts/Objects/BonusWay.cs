using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWay : MonoBehaviour, ICrushable
{
    public int bonusAmount;
    int newPointAmount;
    
    public void CrashForBonus()
    {
        if (GameManager.Instance.bonusAmount == bonusAmount)
            return;

        GameManager.Instance.bonusAmount = bonusAmount;
        newPointAmount = GameManager.Instance.PlayerCoinAmount * bonusAmount;
        GameManager.Instance.PlayerCoinAmount = newPointAmount;

        Debug.Log(bonusAmount);
        Debug.Log(GameManager.Instance.PlayerCoinAmount);
        
        
    }
    
    
    public void Crush(GameObject g)
    {
        g.transform.parent = null;
        Rigidbody _rigidbody = g.GetComponent<Rigidbody>();
        
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        g.GetComponent<BoxCollider>().isTrigger = false;
        CubeManager.Instance.cubes.Remove(g);
        
    }
}
