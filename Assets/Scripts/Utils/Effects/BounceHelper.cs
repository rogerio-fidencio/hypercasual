using System;
using DG.Tweening;
using UnityEngine;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Ease bounceEase = Ease.Linear;
    [SerializeField] private float bounceDuration = .05f;
    [SerializeField] private float scaleBounce = 1.2f;

    public void Bounce()
    {
        transform.DOScale(scaleBounce, bounceDuration).SetEase(bounceEase).SetLoops(2, LoopType.Yoyo);
    }
}
