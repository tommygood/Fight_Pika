using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliCameMove : MonoBehaviour {
    public GameObject Py;
    
    public GameObject Camera;
    
    public JoyMove joy_move;
    
    void Update() {
        /* if (!joy_move.is_snow && joy_move.check_star) {
            transform.position = new Vector3(Py.transform.position.x+2.8f,-2.7f,-10f);
        } */
        // Debug.Log(Camera.transform.position);
        if (joy_move.check_flag)
            transform.position = new Vector3(Py.transform.position.x+2.8f,Py.transform.position.y,-10f);
        if (joy_move.check_floor2) {
            // Debug.Log("joy_move.check_floor2 "+joy_move.check_floor2);
            transform.position = new Vector3(Py.transform.position.x+2.8f,-71f,transform.position.z);  
        }
        if (joy_move.check_star) {
            // Debug.Log("joy_move.check_star "+joy_move.check_star);
            transform.position = new Vector3(111f,-71f,transform.position.z);             
        }
        if (joy_move.is_snow) {
            transform.position = new Vector3(Py.transform.position.x+2.8f,Py.transform.position.y-2.7f,-10f);
        }
        if (joy_move.check_normal) {
            transform.position = new Vector3(Py.transform.position.x+2.8f,-2.7f,-10f);
        }
        if (JoyMove.check_star1)
            transform.position = new Vector3(Py.transform.position.x+3f,Py.transform.position.y+1.0f,-10f);
    }
}
