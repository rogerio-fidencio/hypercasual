using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private TextMeshPro uiTextpowerUp;
    [SerializeField] private Collider playerCollider;

    [Header("Coin Collector Setup")]
    [SerializeField] private GameObject coinCollector;

    [Header("Tags To Compare")]
    [SerializeField] private string obstacleTag = "Obstacle";
    [SerializeField] private string endLineTag = "EndLine";

    [Header("Lerp")]
    [SerializeField] private Transform horizontalController;
    [SerializeField] private float lerpSpeed = 1f;

    //privates
    private Vector3 _startPosition;
    private Vector3 _horizontalControllerPosition;
    private bool _canRun;
    private float _currentSpeed;
    private bool _isInvencible;

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
        _isInvencible = false;
    }

    void Update()
    {
        if (!_canRun) return;

        _horizontalControllerPosition = horizontalController.position;
        _horizontalControllerPosition.y = transform.position.y;
        _horizontalControllerPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, _horizontalControllerPosition, lerpSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(obstacleTag) && !_isInvencible)
        {
            _canRun = false;
            GameManager.Instance.GameOver();
        }

        if (collision.gameObject.CompareTag(endLineTag))
        {
            _canRun = false;
            GameManager.Instance.GameOver();
        }
    }

    public void StartRunning()
    {
        _canRun = true;
    }


    #region POWER UPS
    public void SetPowerUpText(string text)
    {
        uiTextpowerUp.text = text;
    }

    public void PowerUpSpeedUp(float speed)
    {
        _currentSpeed = speed;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvencible(bool invencible)
    {
        _isInvencible = invencible;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight(float animationDuration)
    {
        transform.DOMoveY(_startPosition.y, animationDuration);
    }

    public void ChangeCoinCollectorSize(int amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}
