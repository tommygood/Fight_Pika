using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorMove : MonoBehaviour {
    public GameObject py;
    
    private bool check = true;
    
    void Update() { // 0.59 -0.03 0.02, -92.54,106.57 100.6
        if (Math.Abs(py.transform.position.x-transform.position.x) <= 8 && check) {
            for (int i = 1;i < 101;i++)
                Invoke("Move",i*0.01f);
            check = false;
        }
    }
    
    public void Move() { // 106.742 -> 107 ,-17.57 -> -18.34
        transform.position = new Vector3(transform.position.x+0.00558f,transform.position.y-0.007f,transform.position.z);
        transform.Rotate(0f,-0.925f,0f);
    }
}
