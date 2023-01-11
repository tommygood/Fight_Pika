using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagMove : MonoBehaviour { 
    private bool check_used = false;
    
    public bool check_py = false;
    
    public GameObject sword;
    
    public GameObject ak;
    
    private bool check_flag_pos = false; // make sure py drive the flag while stand on it
    
    void OnTriggerEnter2D(Collider2D other) { // 130.6 -67.5 134 -70 135.5 -67.5 132.2 -73.96 
        if (other.name == "Sword" && !check_used) {
            for (int i = 1;i < 11;i++)
                Invoke("Move",i*0.1f);
            for (int i = 11;i < 21;i++)
                Invoke("Move1",i*0.1f);
            for (int i = 21;i < 31;i++)
                Invoke("Move2",i*0.1f);
            Invoke("OnCheck",3f); // py can drive it
            check_used = true;
        }
        if (other.name == "Player" && check_flag_pos) {
            check_py = true;
            sword.SetActive(false);
            ak.SetActive(false);
        }
    }
    
    public void OnCheck() {
        check_flag_pos = true;
    }
    
    public void Move2() {
        transform.position = new Vector3(transform.position.x-0.32f,transform.position.y-0.666f,transform.position.z);
    }
    
    public void Move1() {
        transform.position = new Vector3(transform.position.x+0.15f,transform.position.y+0.25f,transform.position.z);
    }
    
    public void Move() {
        transform.position = new Vector3(transform.position.x+0.34f,transform.position.y-0.25f,transform.position.z);
    }
}
