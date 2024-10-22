using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    [SerializeField] private float velocity = 1f;

    private Vector2 _pastPosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - _pastPosition.x);
        }
        _pastPosition = Input.mousePosition;
    }

    private void Move(float speed)
    {
        transform.position += Vector3.right * speed * velocity * Time.deltaTime;
    }
}
