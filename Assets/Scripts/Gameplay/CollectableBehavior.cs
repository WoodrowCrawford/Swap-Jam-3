using UnityEngine;

public class CollectableBehavior : MonoBehaviour
{
    //delegate
    public delegate void CollectableEventHandler();

    //events
    public static CollectableEventHandler onCollectableCollected;

    private void OnEnable()
    {
        onCollectableCollected += () => AudioManager.PlayAudio("CollectSound");
    }

    private void OnDisable()
    {
        onCollectableCollected -= () => AudioManager.PlayAudio("CollectSound");

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            onCollectableCollected?.Invoke();

            Destroy(gameObject);
        }
    }

   
}
