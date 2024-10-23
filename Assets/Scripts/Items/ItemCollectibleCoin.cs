using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleCoin : ItemCollectibleBase
{
    protected override void OnCollected()
    {
        base.OnCollected();
        ItemManager.Instance.AddCoin();
    }
}
