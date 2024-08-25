using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;

    public int scoreNeededToWin;
   



    //delegate
    public delegate void GameManagerEventHandler();

    //events
    public static event GameManagerEventHandler onGameWin;
    public static event GameManagerEventHandler onGameOver;


   

    private void OnEnable()
    {

        CollectableBehavior.onCollectableCollected += IncreaseScore;
        PlayerBehavior.onDeath += () => onGameOver?.Invoke();

        //scene
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;


        onGameOver += () => AudioManager.PlayAudio("GameOverSound");
    }

    private void OnDisable()
    {
        CollectableBehavior.onCollectableCollected -= IncreaseScore;
        PlayerBehavior.onDeath -= () => onGameOver?.Invoke();

        onGameOver -= () => AudioManager.PlayAudio("GameOverSound");
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene == SceneManager.GetSceneByBuildIndex(0))
        {
            //play audio here
           

        }

    }

    public void OnSceneUnloaded(Scene scene)
    {

    }

    public void IncreaseScore()
    {
        score = score + 1;

        if(score >= scoreNeededToWin)
        {
            onGameWin?.Invoke();
        }
    }
}
