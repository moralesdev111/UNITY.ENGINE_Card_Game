using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


public class Manager : MonoBehaviour
{
    [SerializeField] OpponentHealth opponentHealth;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] TextMeshProUGUI winLoseText;
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
            winLoseText.gameObject.SetActive(true);
            winLoseText.text ="You Lose";
        }
        else if(opponentHealth.currentHealth < 1)
        {
            winLoseText.gameObject.SetActive(true);
            gameEnded = true;
            winLoseText.text ="You Win";
        }
    }
}