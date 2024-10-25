using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenciblePowerUp : BasePowerUp
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Invencible");
        PlayerController.Instance.SetInvencible(true);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetInvencible(false);
    }
}
