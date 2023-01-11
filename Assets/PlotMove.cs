using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotMove : MonoBehaviour {
    public bool check_use = true;
    
    public TextMove text_move;
    
    public GameObject plot_text1;
    
    public GameObject continue_text;
    
    public void Update() {
        if (text_move.check_end && check_use) {
            continue_text.SetActive(true);
            if (Input.touchCount > 0) {
                plot_text1.SetActive(true);
                check_use = false;
                continue_text.SetActive(false);
            }
            // Touch touch = Input.GetTouch(0);
            // different type of screen input between phone and pc, so need to convert coordinate
            // Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            // touchPos.z = 1f; // do not use the z of phone  
            // transform.position = touchPos;
        }
    }        
}
