using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinCheck : MonoBehaviour {

    public List<Transform> gridList;
    public List<Transform> positionList;

    public int listPointer = 0;
    public int possibleMove;

    public bool functionDone = true;

    public GameObject player1;
    public GameObject player2;

    public void ClearLists()
    {
        gridList.Clear();
        positionList.Clear();
    }

    public void PossibleWinCheck()
    {
        functionDone = false;
        if(positionList.Count == 0)
        {
            print("Niet Mogelijk!");
            possibleMove = 0;
            functionDone = true;
            return;
        }
        var playerPosition = positionList[0].position;
        // Remove position so that positions are only checked once
        positionList.Remove(positionList[0]);

        RaycastHit2D hit1 = Physics2D.Raycast(playerPosition, Vector2.left);
        RaycastHit2D hit2 = Physics2D.Raycast(playerPosition, Vector2.up);
        RaycastHit2D hit3 = Physics2D.Raycast(playerPosition, Vector2.right);
        RaycastHit2D hit4 = Physics2D.Raycast(playerPosition, Vector2.down);

        if ((hit1 && hit1.collider.name == "FinishP1") || (hit2 && hit2.collider.name == "FinishP1") || (hit3 && hit3.collider.name == "FinishP1") || (hit4 && hit4.collider.name == "FinishP1"))
        {
            print("Is Mogelijk!");
            possibleMove++;
            functionDone = true;
            return;
        }

        if (hit1 && hit1.collider.tag == "Grid" && !gridList.Exists(x => x.transform == hit1.transform))
        {
            AddToLists(hit1.transform);
        }
        if (hit2 && hit2.collider.tag == "Grid" && !gridList.Exists(x => x.transform == hit2.transform))
        {
            AddToLists(hit2.transform);
        }
        if (hit3 && hit3.collider.tag == "Grid" && !gridList.Exists(x => x.transform == hit3.transform))
        {
            AddToLists(hit3.transform);
        }
        if (hit4 && hit4.collider.tag == "Grid" && !gridList.Exists(x => x.transform == hit4.transform))
        {
            AddToLists(hit4.transform);
        }
        PossibleWinCheck();
    }
    public void AddToLists(Transform pos)
    {
        positionList.Add(pos);
        gridList.Add(pos);
    }
}