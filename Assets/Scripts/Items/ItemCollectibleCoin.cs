using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleCoin : ItemCollectibleBase
{

    [SerializeField] private float lerp = 5f;
    [SerializeField] private float minDistance = 1f;

    private bool _collect;

    private void Start()
    {
        CoinAnimationManager.Instance.RegisterCoin(this);
    }

    private void Update()
    {
        if (_collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);

            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                HideObject();
            }
        }
    }

    protected override void Collect()
    {
        base.Collect();
        _collect = true;
    }

    protected override void OnCollected()
    {
        base.OnCollected();
        ItemManager.Instance.AddCoin();
    }
}
