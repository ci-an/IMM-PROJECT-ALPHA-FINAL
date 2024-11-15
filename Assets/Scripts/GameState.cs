using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private int score;

    public void isGameOver() {
    
        Debug.Log("Game Over!");
    }


    public void IncreaseScore() {
             
             score++;
        
    }
}
