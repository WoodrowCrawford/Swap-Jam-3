using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : MonoBehaviour
{
    //delegate
    public delegate void EnemyEventHandler();

    //events
    public static event EnemyEventHandler onEnemyHitPlayer;


    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;



    private void OnEnable()
    {
        onEnemyHitPlayer += () => AudioManager.PlayAudio("HitSound");
        GameManager.onGameOver += () => AudioManager.StopAudio("HitSound");
    }

    private void OnDisable()
    {
        onEnemyHitPlayer -= () => AudioManager.PlayAudio("HitSound");
        GameManager.onGameOver -= () => AudioManager.StopAudio("HitSound");
    }


    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, _target.transform.position, _speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            onEnemyHitPlayer?.Invoke();
        }
    }
}
