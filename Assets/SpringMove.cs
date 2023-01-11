using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMove : MonoBehaviour {
    private Vector3 start_pos;
    
    private bool check = true;
    
    public GameObject py;
    
    void Start() {
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    void OnTriggerEnter2D(Collider2D other) { // 53.8 0.92 80 0.8
        if (other.name == "Player" && transform.position == start_pos && check) {
            for (int i = 1;i < 11;i++)
                Invoke("Move",i*0.05f);
            for (int i = 11;i < 21;i++)
                Invoke("Back",i*0.05f);
            for (int i = 21;i < 31;i++)
                Invoke("PyMove",i*0.05f);
        }
    }
    
    public void PyMove() {
        py.transform.position = new Vector3(py.transform.position.x+2.62f,py.transform.position.y-0.012f,py.transform.position.z);
    }
    
    public void Move() {
        transform.position = new Vector3(transform.position.x,transform.position.y-0.08f,transform.position.z);
        check = false;
    }
    
    public void Back() {
        transform.position = new Vector3(transform.position.x,transform.position.y+0.08f,transform.position.z);
        check = true;
    }
}
