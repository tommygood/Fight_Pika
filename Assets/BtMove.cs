using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BtMove : MonoBehaviour { 
    public Vector3 start_pos;
    
    public int bt_uses = 0;
    
    public GameObject stair;
    
    public GameObject stair1;
    
    public GameObject stair2;
    
    private float stair_length = -2.2f;
    
    private float stair1_length = -0.4f;
    
    private float stair2_length = 1.5f;
    
    private bool check = true;
    
    private bool check1 = true;
    
    private bool check2 = true;
    
    public GameObject py;
    
    public GameObject bt_down;
    
    public GameObject spring_down;
    
    private bool check_used = false;
    
    public void Start() {
        bt_down.transform.position = new Vector3(py.transform.position.x-5f,transform.position.y,transform.position.z);
        start_pos = transform.position; 
    }
    
    public void Update() { // -3.9
        if (bt_uses == 1 && check) { // -2.5, move once
            stair.SetActive(true);
            for (int i = 1;i < 11;i++)
                Invoke("MoveStair",i*0.1f);
            check = false;
        }
        if (bt_uses == 2 && check1) { // -0.4
            stair1.SetActive(true);
            for (int i = 1;i < 11;i++)
                Invoke("MoveStair1",i*0.1f);
            check1 = false;
        }
        if (bt_uses == 3 && check2) { // 1.5
            stair2.SetActive(true);
            spring_down.SetActive(true);
            for (int i = 1;i < 11;i++)
                Invoke("MoveStair2",i*0.1f);
            check2 = false;
        }
    }
    
    public void MoveStair() {
        stair.transform.position = new Vector3(stair.transform.position.x,stair.transform.position.y+(Math.Abs(-3.9f-stair_length))/10,stair.transform.position.z);
    }
    
    public void MoveStair1() {
        stair1.transform.position = new Vector3(stair1.transform.position.x,stair1.transform.position.y+(Math.Abs(-3.9f-stair1_length))/10,stair1.transform.position.z);
    }
    
    public void MoveStair2() {
        stair2.transform.position = new Vector3(stair2.transform.position.x,stair2.transform.position.y+(Math.Abs(-3.9f-stair2_length))/10,stair2.transform.position.z);
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            if (transform.position == start_pos && !check_used) { // check if bt back to the start_pos, then move
                for (int i = 1;i < 11;i++)
                    Invoke("Move",i*0.1f);
                for (int i = 11;i < 21;i++)
                    Invoke("Back",i*0.1f);
                check_used = true;
                Invoke("UnCheck",2f);
            }
            bt_uses++;
        }
    }
    
    public void UnCheck() {
        check_used = false;
    }
    
    public void Move() { // -5.75 -6.38
        transform.position = new Vector3(transform.position.x,transform.position.y-0.063f,transform.position.z);
    }
    
    public void Back() {
        transform.position = new Vector3(transform.position.x,transform.position.y+0.063f,transform.position.z);
    }
}
