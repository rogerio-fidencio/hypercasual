using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPowerUp : BasePowerUp
{
    [Header("Coin Collector")]
    [SerializeField] private int sizeAmount = 7;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Coin Collector");
        PlayerController.Instance.ChangeCoinCollectorSize(sizeAmount);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ChangeCoinCollectorSize(1);
    }
}
