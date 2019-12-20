using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalDamage : MonoBehaviour
{
    public float Damage = 0;
    public float time;
    public Text dps;
    // Start is called before the first frame update
    void Start()
    {
        Damage = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.smoothDeltaTime;
        Dps(time, Damage);
    }

    void Dps(float time, float Dam)
    {
        int damage = (int)(Dam / time);
        dps.text = damage.ToString();
    }
}
