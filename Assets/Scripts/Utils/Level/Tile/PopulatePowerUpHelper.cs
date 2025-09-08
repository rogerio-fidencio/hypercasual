using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PopulatePowerUpHelper : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerUps;

    private void Start()
    {
        PopulatePowerUps();
    }

    private void PopulatePowerUps()
    {
        var powerUp = Instantiate(powerUps[Random.Range(0, powerUps.Count)], transform);
        powerUp.transform.localPosition = Vector3.zero;
    }
    
}
