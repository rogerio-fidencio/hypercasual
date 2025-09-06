using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class AutoMovimentHelper : MonoBehaviour
{
    [SerializeField] private List<Transform> positions;

    [SerializeField] private float duration = 1f;

    private int _index;

    private void Start()
    {
        NextIndex();
        transform.position = positions[Random.Range(0, positions.Count)].position;
        StartCoroutine(StartMoviment());
    }

    IEnumerator StartMoviment()
    {

        float time = 0;
        
        while (true)
        {
            var currentPosition = transform.position;
            
            while (time < duration)
            {
                transform.position = Vector3.Lerp(
                    currentPosition,
                    positions[_index].transform.position,
                    time / duration
                );
                
                time += Time.deltaTime;
                yield return null;
            }

            NextIndex();
            
            time = 0;
            
            yield return null;
        }
        
        
    }

    private void NextIndex()
    {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }
}
