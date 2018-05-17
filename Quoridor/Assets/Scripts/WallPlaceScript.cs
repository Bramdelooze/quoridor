using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlaceScript : MonoBehaviour {

    public GameObject wall;
    private GameObject placedWall;

    public GameObject player1;
    public GameObject player2;

    public PlayerWinCheck playerWincheck;
    public GameManager gameManager;

    public bool placeWall = false;

    static int wallDirection;
    static Vector3 wallPosOffset;
    static Quaternion wallRotOffset;

    private void Start()
    {
        playerWincheck = FindObjectOfType<PlayerWinCheck>();
        gameManager = FindObjectOfType<GameManager>();
        wallPosOffset = new Vector2(-.5f, -.5f);
        wallRotOffset = Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnMouseDown()
    {
        if (playerWincheck.functionDone)
        {
            playerWincheck.ClearLists();
            playerWincheck.positionList.Add(playerWincheck.player1.transform);
            playerWincheck.PossibleWinCheck();
        }
      //if (playerWincheck.functionDone && playerWincheck.possibleMove == 1)
      //{
      //    playerWincheck.ClearLists();
      //    playerWincheck.positionList.Add(playerWincheck.player2.transform);
      //    playerWincheck.PossibleWinCheck();
      //} else
      //{
      //    playerWincheck.possibleMove = 0;
      //    return;
      //}
        if (playerWincheck.functionDone && playerWincheck.possibleMove == 1)
        {
            placeWall = true;
            gameManager.NextPlayersTurn();
        }
        else
        {
            placeWall = false;
        }
    }

    private void OnMouseEnter()
    {
        placedWall = Instantiate(wall, transform.position + wallPosOffset, transform.rotation = wallRotOffset);
    }
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2) && !placeWall)
        {
            wallDirection ++;
            if (wallDirection > 3)
                wallDirection = 0;

            if (wallDirection == 0)
            {
                wallPosOffset = new Vector2(-.5f, -.5f);
                wallRotOffset = Quaternion.Euler(0f, 0f, 0f);
            }
            if (wallDirection == 1)
            {
                wallPosOffset = new Vector2(.5f, .5f);
                wallRotOffset = Quaternion.Euler(0f, 0f, 90f);
            }
            if (wallDirection == 2)
            {
                wallPosOffset = new Vector2(.5f, -.5f);
                wallRotOffset = Quaternion.Euler(0f,0f,0f);
            }
            if (wallDirection == 3)
            {
                wallPosOffset = new Vector2(-.5f, -.5f);
                wallRotOffset = Quaternion.Euler(0f, 0f, 90f);
            }
        }
        placedWall.transform.rotation = wallRotOffset;
        placedWall.transform.position = transform.position + wallPosOffset;
    }
    private void OnMouseExit()
    {
        if(!placeWall)
        Destroy(placedWall);
        placeWall = false;
    }
}