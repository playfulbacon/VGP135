﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {

    private float delayTimer = 1;

	void Update () {
        delayTimer -= Time.deltaTime;
        if(delayTimer<= 0){
            Destroy(this.gameObject);
        }
	}
}
