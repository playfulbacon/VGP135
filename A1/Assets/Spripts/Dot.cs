using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public enum DotType { a, b, c, d, e, f };
    public DotType dotType;

    public int column;
    public int row;
    public int targetX;
    public int targetY;
    public int previousColumn;
    public int previousRow;
    public bool isMatched = false;
    public float swipAngle = 0;
    public float swipResist = 0;
    public Dot currentDot;

    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private Vector2 tempPosition;
    private Dot otherDot;
    private Board1 board;
    private FindMatches findMatches;

    bool isTouched = false;

    // Start is called before the first frame update
    void Start()
    {
        findMatches = FindObjectOfType<FindMatches>();
        board = FindObjectOfType<Board1>();
        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
        row = targetY;
        column = targetX;
        previousRow = row;
        previousColumn = column;
    }

    // Update is called once per frame
    void Update()
    {
        targetX = column;
        targetY = row;
        if (Mathf.Abs(targetX - transform.position.x) > .1)
        {
            //Move Towards the target
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .6f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this;
            }
            findMatches.FindAllMatches();
        }
        else
        {
            //Directly set the position
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = tempPosition;

        }
        if (Mathf.Abs(targetY - transform.position.y) > .1)
        {
            //Move Towards the target
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .6f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this;
            }
            findMatches.FindAllMatches();

        }
        else
        {
            //Directly set the position
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = tempPosition;

        }

        if (Input.GetMouseButtonUp(0) && isTouched)
        {
            MouseButtonUp();
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse down");
        isTouched = true;
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void MouseButtonUp()
    {
        Debug.Log("mouse up");
        finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        calculateAngle();
        isTouched = false;
    }

    void calculateAngle()
    {
        if (Mathf.Abs(finalTouchPosition.y - firstTouchPosition.y) > swipResist || Mathf.Abs(finalTouchPosition.x - firstTouchPosition.x) > swipResist)
        {
            swipAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x- firstTouchPosition.x )*180/Mathf.PI;
            MovePieces();
        }
    }

    private void MovePieces()
    {
        if(swipAngle > -45 && swipAngle <= 45 && column < board.width - 1)
        {
            Debug.Log("Move right");
            //right
            otherDot = board.allDots[column + 1, row];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().column -= 1;
            column += 1;
        }
        else if(swipAngle > 45 && swipAngle <= 135 && column < board.hight -1)
        {
            //up
            Debug.Log("Move up");
            otherDot = board.allDots[column , row + 1];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().row -= 1;
            row += 1;
        }
        else if (swipAngle > 135 || swipAngle <= -135 && column > board.width)
        {
            //left
            Debug.Log("Move left");
            otherDot = board.allDots[column - 1, row];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().column += 1;
            column -= 1;
        }
        else if (swipAngle < -45 && swipAngle >= -135 && column > board.hight)
        {
            //Down
            Debug.Log("Move Down");
            otherDot = board.allDots[column , row-1];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().row += 1;
            row -= 1;
        }

        StartCoroutine(CheckMoveCo(otherDot));

    }


    public IEnumerator CheckMoveCo(Dot _otherDot)
    {
        yield return new WaitForSeconds(0.5f);
        if (_otherDot != null)
        {
            Debug.Log("other dot");
            if (!isMatched && !_otherDot.isMatched)
            {
                _otherDot.row = row;
                _otherDot.column = column;
                row = previousRow;
                column = previousColumn;
            }
            else
            {
                board.DestroyMatches();
            }
        }
    }


}
