using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerUp : ItemCollectibleBase
{
    [Header("Power Up")]
    [SerializeField] protected float duration = 5f;

    protected override void Collect()
    {
        base.Collect();
        StartPowerUp();
    }

    protected virtual void StartPowerUp()
    {
        Invoke("EndPowerUp", duration);
    }

    protected virtual void EndPowerUp()
    {
        PlayerController.Instance.SetPowerUpText("");
    }
}
