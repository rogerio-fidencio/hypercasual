using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightPowerUp : BasePowerUp
{
    [Header("Power Up Height")]
    [SerializeField] private float amountHeight = 2f;
    [SerializeField] private float animationDuration = .1f;
    [SerializeField] private DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.ChangeHeight(amountHeight, duration, animationDuration, ease);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetHeight(animationDuration);
    }
}
