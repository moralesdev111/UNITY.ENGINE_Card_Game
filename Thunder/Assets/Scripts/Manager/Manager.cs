using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    [SerializeField] OpponentHealth opponentHealth;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] TextMeshProUGUI winLoseText;
    [SerializeField] Image endGameCanvas;
    [SerializeField] Button playAgainButton;
    public bool gameEnded = false;

    private void Update()
    {
        if(!gameEnded)
        {
            EndGame();
        }   
    }


    public void EndGame()
    {
        if(playerHealth.currentHealth < 1)
        {
            gameEnded = true;
            winLoseText.text ="You Lose";
            winLoseText.gameObject.SetActive(true);
            endGameCanvas.gameObject.SetActive(true);
            
        }
        else if(opponentHealth.currentHealth < 1)
        {
            gameEnded = true;
            winLoseText.text ="You Win";
            winLoseText.gameObject.SetActive(true);
            endGameCanvas.gameObject.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}