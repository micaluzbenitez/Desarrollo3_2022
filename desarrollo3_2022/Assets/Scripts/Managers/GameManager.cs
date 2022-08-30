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
    #endregion

    #region PRIVATE VARIABLES

    #endregion
    #endregion

    #region METHODS
    #region PUBLIC METHODS

    #endregion

    #region STATIC METHODS

    #endregion

    #region PRIVATE METHODS
    private void OnEnable()
    {
        playerEnemies.OnLoseLife += playerStats.LoseLife;
    }

    private void OnDisable()
    {
        playerEnemies.OnLoseLife -= playerStats.LoseLife;
    }
    #endregion
    #endregion
}

