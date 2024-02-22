using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem CparticleSystem;
    public float timeToHide = 3;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        //if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void HideItens()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
    }

    protected virtual void Collect()
    {
        HideItens();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
    
    protected virtual void OnCollect()
    {
        if (CparticleSystem != null)
        {
            CparticleSystem.transform.SetParent(null);
            CparticleSystem.Play();
        }
        if (audioSource != null) audioSource.Play();
    }
}
