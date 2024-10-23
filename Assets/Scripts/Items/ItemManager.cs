using System;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public static ItemManager Instance;

    public SOInt coinCount;

    public Action coinCountChange;



    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
