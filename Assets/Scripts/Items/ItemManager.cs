using System;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{

    public SOInt coinCount;

    public Action coinCountChange;


    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coinCount.value = 0;
    }

    public void AddCoin(int amount = 1)
    {
        coinCount.value += amount;
        coinCountChange?.Invoke();
    }

}
