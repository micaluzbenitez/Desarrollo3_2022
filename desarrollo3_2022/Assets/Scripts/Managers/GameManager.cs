using System;
using UnityEngine;
using Entities.Player;

public class GameManager : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZED VARIABLES
    [SerializeField] public PlayerStats playerStats = null;
    [SerializeField] public PlayerEnemies playerEnemies = null; 

    #endregion

    #region STATIC VARIABLES
    public static bool GameRunning { get; private set; } = true;

    public static Action OnGameOver;

    #endregion

    #region PRIVATE VARIABLES

    private bool gameOver = false;

    #endregion
    #endregion

    #region METHODS
    #region PUBLIC METHODS

    #endregion

    #region STATIC METHODS

    #endregion

    #region PRIVATE METHODS
    private void Awake()
    {
        DeathChecker.OnReachLimit += EndGame;
    }
    private void OnDestroy()
    {
        DeathChecker.OnReachLimit -= EndGame;
    }
    private void Start()
    {
        gameOver = false;
    }
    private void OnEnable()
    {
        playerEnemies.OnLoseLife += playerStats.LoseLife;
    }

    private void OnDisable()
    {
        playerEnemies.OnLoseLife -= playerStats.LoseLife;
    }

    private void EndGame()
    {
        gameOver = true;
        GameRunning = false;
        Debug.Log("Perdiste");
        OnGameOver?.Invoke();
    }

    #endregion
    #endregion
}

