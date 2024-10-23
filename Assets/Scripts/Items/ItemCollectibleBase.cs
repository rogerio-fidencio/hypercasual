using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleBase : MonoBehaviour
{

    [SerializeField] private string tagToCompare = "Player";

    [SerializeField] private ParticleSystem colectEffect;
    [SerializeField] private float timeToHide = 3f;
    [SerializeField] private GameObject graphicItem;

    [Header("Sounds")]
    [SerializeField] private AudioSource collectSoundSource;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(tagToCompare))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        OnCollected();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollected()
    {
        if (colectEffect != null) colectEffect.Play();
        if (collectSoundSource != null) collectSoundSource.Play();
    }
}
