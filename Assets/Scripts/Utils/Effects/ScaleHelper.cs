using System;
using DG.Tweening;
using UnityEngine;

public class ScaleHelper : MonoBehaviour
{
    [SerializeField] private float scaleDuration = .2f;
    [SerializeField] private Ease scaleEase = Ease.OutBack;
    
    private Vector3 _originalScale;

    private void Start()
    {
        _originalScale = transform.localScale;
        Scale();
    }

    private void Scale()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(_originalScale, scaleDuration).SetEase(scaleEase);
    }
}
