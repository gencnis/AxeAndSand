using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Defines how the game will work
/// </summary>
public class GameBehavior : MonoBehaviour
{
    public int maxNumEnemy = 9;
    public bool showWinScreen = false;
    public string labelText = "Sandmen is trying to take your village! What will you do?";
    private int _enemyKilled;
    bool showGUI = false;


    /// <summary>
    /// Access variable for the number of enemies bar the player has collected
    /// </summary>
    public int EnemyKilled
    {
        get { return _enemyKilled; }
        set
        {
            _enemyKilled = value;
            Debug.LogFormat("You've killed {0} sandmen!", _enemyKilled);

            // If the user has collected all the snickers, the game is won
            if(_enemyKilled >= maxNumEnemy)
            {
                labelText = "You've killed them all!";
                showWinScreen = true;
                Debug.Log("Congratulations! You have killed all the sandmen.");
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Enemy down, only " + (maxNumEnemy - _enemyKilled) + " more to go!";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        showGUI = true;
    }
    void OnDisable()
    {
        showGUI = false;
    }

    //Update the GUI with the current state of the game
    void OnGUI()
    {
        if (showGUI)
        {
            GUI.Box(new Rect(20, 50, 200, 30), "Enemies killed: " + _enemyKilled);
         
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);
            if (showWinScreen)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 100,
               Screen.height / 2 - 50, 200, 100), "YOU WON!"))
                {
                    SceneManager.LoadScene(0);
                    Time.timeScale = 1.0f;
                }
            }
        }
    }
}
