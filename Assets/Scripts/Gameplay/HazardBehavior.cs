using UnityEngine;
using UnityEngine.Tilemaps;

public class HazardBehavior : MonoBehaviour
{
    [SerializeField] AnimatedTile AnimatedTile;

    public delegate void HazardEventHandler();

    public static event HazardEventHandler onHit;

    private void OnEnable()
    {
        onHit += () => AudioManager.PlayAudio("HitSound");
    }

    private void OnDisable()
    {
        onHit -= () => AudioManager.PlayAudio("HitSound");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            onHit?.Invoke();
        }
    }
}
