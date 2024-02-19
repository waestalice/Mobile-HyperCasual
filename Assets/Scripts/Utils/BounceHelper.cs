using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleBounce = 1.5f;
    public float startScale = 1f;
    public float scalePowerUps = 1.2f;
    public Ease ease = Ease.OutBack;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
        }
    }

    public void Bounce()
    {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }

    public void BouncePowerUps()
    {
        transform.DOScale(scalePowerUps, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}
