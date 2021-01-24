using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class DiamondCollectable : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        GameManager.Instance.PlayerCoinAmount += 1;
        Destroy(gameObject);
    }
}
