using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMove : MonoBehaviour {
    public GameObject Py;
    
    private bool check = true;
    
    private int count = 0;
    
    public void Update() {
        if (Input.touchCount > 0 && check) {
            count++;
            Touch touch = Input.GetTouch(0);
            // different type of screen input between phone and pc, so need to convert coordinate
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 1f; // do not use the z of phone  
            // transform.position = touchPos;
            Debug.Log(touchPos+" "+Input.touchCount+" "+count);
            check = false;
        }
    }        
}
