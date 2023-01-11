/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraMove : MonoBehaviour {
    void Update() {
        while (!(transform.position.x < 102.1f || transform.position.x > 114.1f)) { // not out of bounds
            for (int i = 1;i < 11;i++)
                Invoke("Move",i*0.1f);
        }
    }
    
    public void Move() { // 
        transform.position = new Vector3(transform.position.x+1.2f,transform.position.y,transform.position.z);
    }
}*/
