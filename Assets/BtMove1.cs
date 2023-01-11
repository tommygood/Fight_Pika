using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtMove1 : MonoBehaviour {
    private bool check_used = false;
    
    private Vector3 start_pos;
    
    public GameObject BigSquare;
    
    public GameObject bt1;
    
    void Start() {
        start_pos = transform.position;
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            if (transform.position == start_pos && !check_used) { // check if bt back to the start_pos, then move
                BigSquare.SetActive(true);
                for (int i = 1;i < 11;i++)
                    Invoke("Move",i*0.1f);
                for (int i = 11;i < 21;i++)
                    Invoke("Back",i*0.1f);
                check_used = true;
                Invoke("UnCheck",2f);
            }
        }
    }
    
    public void UnCheck() {
        check_used = false;
        bt1.SetActive(false);
    }
    
    public void Move() { // -5.75 -6.38
        transform.position = new Vector3(transform.position.x,transform.position.y-0.063f,transform.position.z);
    }
    
    public void Back() {
        transform.position = new Vector3(transform.position.x,transform.position.y+0.063f,transform.position.z);
    }
}
