using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    [Header("Lerp")]
    [SerializeField] private Transform horizontalController;
    [SerializeField] private float lerpSpeed = 1f;

    private Vector3 _horizontalControllerPosition;
    private bool _canRun;

    private void Start()
    {
        _canRun = true;
    }

    void Update()
    {
        if (!_canRun) return;

        _horizontalControllerPosition = horizontalController.position;
        _horizontalControllerPosition.y = transform.position.y;
        _horizontalControllerPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, _horizontalControllerPosition, lerpSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _canRun = false;
        }
    }
}
