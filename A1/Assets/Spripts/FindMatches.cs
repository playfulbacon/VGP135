using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FindMatches : MonoBehaviour
{

    private Board1 board;
    public List<Dot> currentMatches = new List<Dot>();

    // Use this for initialization
    void Start()
    {
        board = FindObjectOfType<Board1>();
    }

    public void FindAllMatches()
    {
        StartCoroutine(FindAllMatchesCo());
    }

    private void AddToListAndMatch(Dot dot)
    {
        if (!currentMatches.Contains(dot))
        {
            currentMatches.Add(dot);
        }
        dot.GetComponent<Dot>().isMatched = true;
    }

    private void GetNearbyPieces(Dot dot1, Dot dot2, Dot dot3)
    {
        AddToListAndMatch(dot1);
        AddToListAndMatch(dot2);
        AddToListAndMatch(dot3);
    }

    private IEnumerator FindAllMatchesCo()
    {
        yield return new WaitForSeconds(.2f);
        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.hight; j++)
            {
                Dot currentDot = board.allDots[i, j];

                if (currentDot != null)
                {
                    Dot currentDotDot = currentDot.GetComponent<Dot>();
                    if (i > 0 && i < board.width - 1)
                    {
                        Dot leftDot = board.allDots[i - 1, j];

                        Dot rightDot = board.allDots[i + 1, j];


                        if (leftDot != null && rightDot != null)
                        {
                            Dot rightDotDot = rightDot.GetComponent<Dot>();
                            Dot leftDotDot = leftDot.GetComponent<Dot>();
                            if (leftDot.tag == currentDot.tag && rightDot.tag == currentDot.tag)
                            {
                                GetNearbyPieces(leftDot, currentDot, rightDot);
                            }
                        }

                    }

                    if (j > 0 && j < board.hight - 1)
                    {
                        Dot upDot = board.allDots[i, j + 1];

                        Dot downDot = board.allDots[i, j - 1];


                        if (upDot != null && downDot != null)
                        {
                            Dot downDotDot = downDot.GetComponent<Dot>();
                            Dot upDotDot = upDot.GetComponent<Dot>();
                            if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag)
                            {
                                GetNearbyPieces(upDot, currentDot, downDot);
                            }
                        }
                    }


                }
            }
        }

    }

    public void MatchPiecesOfColor(string color)
    {
        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.hight; j++)
            {
                //Check if that piece exists
                if (board.allDots[i, j] != null)
                {
                    //Check the tag on that dot
                    if (board.allDots[i, j].tag == color)
                    {
                        //Set that dot to be matched
                        board.allDots[i, j].GetComponent<Dot>().isMatched = true;
                    }
                }
            }
        }
    }

    List<Dot> GetColumnPieces(int column)
    {
        List<Dot> dots = new List<Dot>();
        for (int i = 0; i < board.hight; i++)
        {
            if (board.allDots[column, i] != null)
            {
                dots.Add(board.allDots[column, i]);
                board.allDots[column, i].GetComponent<Dot>().isMatched = true;
            }
        }
        return dots;
    }

    List<Dot> GetRowPieces(int row)
    {
        List<Dot> dots = new List<Dot>();
        for (int i = 0; i < board.width; i++)
        {
            if (board.allDots[i, row] != null)
            {
                dots.Add(board.allDots[i, row]);
                board.allDots[i, row].GetComponent<Dot>().isMatched = true;
            }
        }
        return dots;
    }

}
