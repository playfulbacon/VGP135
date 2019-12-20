using System.Collections;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public IEnumerator ScaleUp(GameObject ball)
    {
        Vector3 add = new Vector3(5.5f, 5.5f, 5.5f);
        ball.transform.localScale = new Vector3(ball.transform.localScale.x + add.x,
                                                ball.transform.localScale.y + add.y,
                                                ball.transform.localScale.z + add.z);
        yield return new WaitForSeconds(5f);
        // after 5 seconds come back to original size
        ball.transform.localScale = new Vector3(ball.transform.localScale.x - add.x,
                                                ball.transform.localScale.y - add.y,
                                                ball.transform.localScale.z - add.z);
    }


    public IEnumerator Shrinking(GameObject ball)
    {
        Vector3 add = new Vector3(-0.5f, -0.5f, -0.5f);
        ball.transform.localScale = new Vector3(ball.transform.localScale.x + add.x,
                                                ball.transform.localScale.y + add.y,
                                                ball.transform.localScale.z + add.z);
        yield return new WaitForSeconds(5f);
        // after 5 seconds come back to original size
        ball.transform.localScale = new Vector3(ball.transform.localScale.x - add.x,
                                                ball.transform.localScale.y - add.y,
                                                ball.transform.localScale.z - add.z);
    }

}
