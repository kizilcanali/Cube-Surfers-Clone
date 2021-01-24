using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CoinPanel : MonoBehaviour
{
   public TextMeshProUGUI CoinText;

   private void OnEnable()
   {
       if(Managers.Instance == null)
           return;
       
       EventManager.OnCoinCollected.AddListener(UpdateCoin);
   }

   private void OnDisable()
   {
       if(Managers.Instance == null)
           return;
       
       EventManager.OnCoinCollected.RemoveListener(UpdateCoin);
   }

   public void UpdateCoin()
   {
       CoinText.text = GameManager.Instance.PlayerCoinAmount.ToString();
   }
}
