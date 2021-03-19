using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<PuzzlePiece> puzzlePieces = new List<PuzzlePiece>();

    public Transform objectToShow = null;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool allGood = true;
        int amount = 0;
        foreach (PuzzlePiece puzzlePiece in puzzlePieces)
        {
            if (!puzzlePiece.isGood())
            {
                allGood = false;
                break;
            }
            amount++;
        }
        Debug.Log(amount);

        if (allGood)
        {
            Debug.Log("All Good");
            objectToShow.gameObject.SetActive(true);
        }
    }
}
