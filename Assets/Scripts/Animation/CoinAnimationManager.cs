using System.Linq;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CoinAnimationManager : Singleton<CoinAnimationManager>
{
    
    [Header("Animation")]
    [SerializeField] private Ease scaleCoinEase = Ease.InOutBack;
    [SerializeField] private float scaleCoinDuration = .2f;
    [SerializeField] private float scaleCoinDelayTime =.2f;

    private List<ItemCollectibleCoin> _coins;

    private void Start()
    {
        _coins = new List<ItemCollectibleCoin>();
    }

    public void RegisterCoin(ItemCollectibleCoin coin)
    {
        if (!_coins.Contains(coin))
        {
            coin.transform.localScale = Vector3.zero;
            _coins.Add(coin);
        }
    }

    public void StartAnimation()
    {
        StartCoroutine(ScaleCoins());
    }
    
    private IEnumerator ScaleCoins()
    {
        foreach (var spawnedTile in _coins)
        {
            spawnedTile.transform.localScale = Vector3.zero;
        }

        SortCoins();
        yield return null;

        for (int i = 0; i < _coins.Count; i++)
        {
            _coins[i].transform.DOScale(.7f, scaleCoinDuration).SetEase(scaleCoinEase);
            yield return new WaitForSeconds(scaleCoinDelayTime);
        }
    }

    private void SortCoins()
    {
        _coins = _coins.OrderBy(
            x => Vector3.Distance(this.transform.position, x.transform.position))
            .ToList();
    }


}
