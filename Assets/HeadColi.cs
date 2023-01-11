using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadColi : MonoBehaviour {
    public GameObject py;
    
    public JoyMove joy_move;
    
    private bool check_back = true;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Snow" && check_back) {
            joy_move.hp -= 1;
            for (int i = 1;i < 11;i++)
                Invoke("Move",i*0.1f);
            check_back = false;
            Invoke("Back",1.1f);
        }
    }
    
    public void Back() {
        transform.position = new Vector3(py.transform.position.x,py.transform.position.y+0.2f,py.transform.position.z);
        check_back = true;
    }
    
    public void Move() {
        transform.position = new Vector3(transform.position.x+0.1f,transform.position.y-0.1f,transform.position.z);
    }
}
