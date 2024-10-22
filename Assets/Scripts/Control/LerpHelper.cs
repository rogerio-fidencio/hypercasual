using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHelper : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float lerpSpeed = 1f;


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed * Time.deltaTime);
    }
}
