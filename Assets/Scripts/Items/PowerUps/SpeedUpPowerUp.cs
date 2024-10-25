using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPowerUp : BasePowerUp
{
    [Header("Power Up Speed Up")]
    [SerializeField] private float amountToSpeed;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.PowerUpSpeedUp(amountToSpeed);
        PlayerController.Instance.SetPowerUpText("Speed Up");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
    }

}
