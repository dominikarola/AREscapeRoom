using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField]
    private int puzzleId;

    [SerializeField]
    [Tooltip("Id of puzzle that should be on the right side of this puzzle.\nSet to -1 if no puzzle is necessary.")]
    private int rightPuzzleId = -1;
    public bool hasRight { get; set; }

    [SerializeField]
    [Tooltip("Id of puzzle that should be on the left side of this puzzle.\nSet to -1 if no puzzle is necessary.")]
    private int leftPuzzleId = -1;
    public bool hasLeft { get; set; }

    [SerializeField]
    [Tooltip("Id of puzzle that should be on the upper side of this puzzle.\nSet to -1 if no puzzle is necessary.")]
    private int upperPuzzleId = -1;
    public bool hasUpper { get; set; }

    [SerializeField]
    [Tooltip("Id of puzzle that should be on the lower side of this puzzle.\nSet to -1 if no puzzle is necessary.")]
    private int lowerPuzzleId = -1;
    public bool hasLower { get; set; }

    [SerializeField]
    [Tooltip("Only correct pieces can be next to this one")]
    private bool onlyCorrectOnes = true;

    public enum Side
    {
        LEFT=0, UPPER,RIGHT,LOWER
    };

    public void setConnection(Side side, bool isConnected)
    {
        switch (side)
        {
            case Side.RIGHT:
                hasRight = isConnected;
                break;
            case Side.LEFT:
                hasLeft = isConnected;
                break;
            case Side.UPPER:
                hasUpper= isConnected;
                break;
            case Side.LOWER:
                hasLower = isConnected;
                break;
        }
    }

    public int puzzleIdForSide(Side side)
    {
        switch (side)
        {
            case Side.RIGHT:
                return rightPuzzleId;
            case Side.LEFT:
                return leftPuzzleId;
            case Side.UPPER:
                return upperPuzzleId;
            case Side.LOWER:
                return lowerPuzzleId;
        }
        return -1;
    }

    bool isCorrect()
    {
        if (hasLeft && hasUpper && isHavingRight() && hasLower)
        {
            return true;
        }
        return false;
    }

    public int getPuzzlePieceId()
    {
        return puzzleId;
    }

    bool isHavingRight()
    {
        return rightPuzzleId >= 0 && hasRight || rightPuzzleId < 0;
    }
    bool isHavingLeft()
    {
        return leftPuzzleId >= 0 && hasLeft || leftPuzzleId < 0;
    }
    bool isHavingLower()
    {
        return lowerPuzzleId >= 0 && hasLower || lowerPuzzleId < 0;
    }
    bool isHavingUpper()
    {
        return upperPuzzleId >= 0 && hasUpper || upperPuzzleId < 0;
    }

    public bool getOnlyCorrectOnes()
    {
        return onlyCorrectOnes;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = isHavingLeft() ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position + Vector3.left * 0.15f, 0.01f);

        Gizmos.color = isHavingRight() ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position + Vector3.right * 0.15f, 0.01f);
        
        Gizmos.color = isHavingLower() ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position + Vector3.back * 0.15f, 0.01f);

        Gizmos.color = isHavingUpper() ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position + Vector3.forward * 0.15f, 0.01f);
    }

    // Returns true if all sides of the pices are correctly matched
    public bool isGood()
    {
        return isHavingLeft() && isHavingLower() && isHavingRight() && isHavingUpper();
    }
}
