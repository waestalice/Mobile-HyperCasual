using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EBAC.Core.Singleton;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    //publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    public GameObject endScreen;

    [Header("Text")]
    public TextMeshPro uiTextPowerUp;

    public bool invencible = false;
    
    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    [Header("VFX")]
    public ParticleSystem vfxDeath;
    public ParticleSystem vfxWin;


    [Header("Limits")]
    public float limit = 4;
    public Vector2 limitVector = new Vector2(-4, 4);


    [SerializeField] private BounceHelper _bounceHelper;

    //privates
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 7;


    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();

        Bounce();
    }
    
    public void Bounce()
    {
        if(_bounceHelper != null)
           _bounceHelper.Bounce();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        if(_pos.x < limitVector.x) _pos.x = limitVector.x;
        else if (_pos.x > limitVector.y) _pos.x = limitVector.y;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
            if(!invencible)
            {
            MoveBack(collision.transform);
            EndGame(AnimatorManager.AnimationType.DEAD);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheckEndLine)
        {
            if(!invencible) EndGame();
        }
    }

    private void MoveBack(Transform t)
    {
        t.DOMoveZ(1f, .3f).SetRelative();
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
        if(vfxDeath != null) vfxDeath.Play();
        if(_canRun == false) vfxWin.Play();
    }

    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedToAnimation);
    }

    #region POWER UPS
    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }
     
    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
         /*var p = transform.position;
         p.y = _startPosition.y + amount;
         transform.position = p;*/

         transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);//.OnComplete(ResetHeight);a
         Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight()
    {
         transform.DOMoveY(_startPosition.y, .1f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}
