using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceSide : MonoBehaviour
{
    [SerializeField]
    private PuzzlePiece puzzlePiece;

    [SerializeField]
    [Tooltip("0-left, 1-up, 2-right, 3-down")]
    [Range(0, 3)]
    private int side;

    private int lookForPuzzleId;

    private int piecesInCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        lookForPuzzleId = puzzlePiece.puzzleIdForSide((PuzzlePiece.Side)side);
    }

    public bool isOppositeSideTo(int otherPieceSide)
    {
        switch (side)
        {
            case 0:
                return otherPieceSide == 2;
            case 1:
                return otherPieceSide == 3;
            case 2:
                return otherPieceSide == 0;
            case 3:
                return otherPieceSide == 1;
        }
        return false;
    }

    private void updateConnection(PuzzlePieceSide puzzlePieceSide)
    {
        if (puzzlePieceSide.isPuzzlePieceId(lookForPuzzleId))
        {
            if (puzzlePiece.getOnlyCorrectOnes())
            {
                if (piecesInCount == 1 && puzzlePieceSide.isOppositeSideTo(side))
                {
                    puzzlePiece.setConnection((PuzzlePiece.Side)side, true);
                }
                else
                {
                    puzzlePiece.setConnection((PuzzlePiece.Side)side, false);
                }
            }
            else
            {
                puzzlePiece.setConnection((PuzzlePiece.Side)side, true);
            }
        }
        else
        {
            puzzlePiece.setConnection((PuzzlePiece.Side)side, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var puzzlePieceSide = other.GetComponent<PuzzlePieceSide>();
        if (puzzlePieceSide)
        {
            piecesInCount++;
            updateConnection(puzzlePieceSide);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (piecesInCount == 1)
        {
            var puzzlePieceSide = other.GetComponent<PuzzlePieceSide>();
            if (puzzlePieceSide)
            {
                updateConnection(puzzlePieceSide);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var puzzlePieceSide = other.GetComponent<PuzzlePieceSide>();
        if (puzzlePieceSide)
        {
            piecesInCount--;
            updateConnection(puzzlePieceSide);
        }
    }

    public bool isPuzzlePieceId(int puzzlePieceId)
    {
        return puzzlePieceId == puzzlePiece.getPuzzlePieceId();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
