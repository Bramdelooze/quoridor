using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject[] players;
    public int playerPointer;
    public Text playersTurnText;
    public PlayerWinCheck playerWinCheck;

	// Use this for initialization
	void Start () {
        playerWinCheck = FindObjectOfType<PlayerWinCheck>();
	}
	
	// Update is called once per frame
	void Update () {
        playersTurnText.text = "It's Player " + (playerPointer + 1) + "'s turn!";
	}

    public void NextPlayersTurn()
    {
        playerWinCheck.possibleMove = 0;
        if (playerPointer < 1)
            playerPointer++;
        else
            playerPointer = 0; 
    }
}
