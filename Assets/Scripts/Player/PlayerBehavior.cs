using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health { get { return _health; } }

    //delegate
    public delegate void PlayerEventHandler();

    //events
    public static event PlayerEventHandler onDeath;


    private void OnEnable()
    {
        HazardBehavior.onHit += TakeDamage;
        EnemyBehavior.onEnemyHitPlayer += TakeDamage;
    }

    private void OnDisable()
    {
        HazardBehavior.onHit -= TakeDamage;
        EnemyBehavior.onEnemyHitPlayer -= TakeDamage;
    }


  

    private void TakeDamage()
    {
        _health--;

        if(_health <=0)
        {
            _health = 0;
            onDeath?.Invoke();
        }
    }
}
