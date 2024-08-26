using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HudBehavior : MonoBehaviour
{
    GameManager gameManager;
    PlayerBehavior playerBehavior;

    [Header("UI")]
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _playerHealthUI;


    [Header("Game Win")]
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Button _winRetryButton;
    [SerializeField] private Button _winQuitButton;


    [Header("Game Over")]
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _quitButton;

    private void OnEnable()
    {
        GameManager.onGameWin += ShowWinScreen;
        GameManager.onGameOver += ShowGameOverScreen;
        CollectableBehavior.onCollectableCollected += UpdateScore;
        HazardBehavior.onHit += UpdateHealth;
        EnemyBehavior.onEnemyHitPlayer += UpdateHealth;
       

        //game win events
        _winRetryButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        _winQuitButton.onClick.AddListener(() => Application.Quit());


        //game over events
        _retryButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        _quitButton.onClick.AddListener(() => Application.Quit());
    }


    private void OnDisable()
    {
        GameManager.onGameWin -= ShowWinScreen;
        GameManager.onGameOver -= ShowGameOverScreen;
        CollectableBehavior.onCollectableCollected -= UpdateScore;
        HazardBehavior.onHit -= UpdateHealth;
        EnemyBehavior.onEnemyHitPlayer -= UpdateHealth;

        //game win events(remove)
        _winRetryButton.onClick.RemoveListener(() => SceneManager.LoadScene(1));
        _winQuitButton.onClick.RemoveListener(() => Application.Quit());

        //game over events(remove)
        _retryButton.onClick.RemoveListener(() => SceneManager.LoadScene(1));
        _quitButton.onClick.RemoveListener(() => Application.Quit());
    }


    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
    }


    private void Start()
    {
        _currentScore.text = gameManager.score.ToString();
        _playerHealthUI.text = playerBehavior.Health.ToString();
    }

    private void ShowGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
    }

    private void ShowWinScreen()
    {
        _winScreen.SetActive(true);

    }

    private void UpdateScore()
    {
        _currentScore.text = gameManager.score.ToString();
    }

    private void UpdateHealth()
    {
        _playerHealthUI.text = playerBehavior.Health.ToString();
    }

    
}
