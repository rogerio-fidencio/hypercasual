using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{
    [SerializeField] private float duration = .2f;
    [SerializeField] private MeshRenderer meshRenderer;
    
    [SerializeField] private Color startColor = Color.white;

    private Color _correctColor;

    private void OnValidate()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Awake()
    {
        _correctColor =  meshRenderer.materials[0].GetColor("_Color");
    }

    private void Start()
    {
        LerpColor();
    }

    private void LerpColor()
    {
        meshRenderer.materials[0].SetColor("_Color", startColor);
        meshRenderer.materials[0].DOColor(_correctColor, duration).SetDelay(.5f);
    }
}
