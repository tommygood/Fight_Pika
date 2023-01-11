using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameMove1 : MonoBehaviour {
    public GameObject py;
    
    void Update() {
        if (JoyMove.check_star1)
            transform.position = py.transform.position; 
    }
}
