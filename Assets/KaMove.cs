using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KaMove : MonoBehaviour {
    public GameObject py;
    
    public bool check_times = true;
    
    public Vector3 start_pos;
    
    public int[] used_times = new int[100];
    
    public int i = 0;
    
    public JoyMove joy_move;
    
    public int hp = 10;
    
    public GameObject pikaka;
    
    public bool is_snow = false;
    
    private bool check_hurt = true;
    
    public RectTransform fill;
    
    void Start() {
        start_pos = transform.position;
    }
    
    void Update() {
        if (hp <= 0)
            pikaka.SetActive(false);
        if (Math.Abs(transform.position.x - py.transform.position.x) < 5) {
            if ((int)Time.time % 3 == 0 && NotInTimes((int)Time.time)) { // pika attack 1/3sec
                used_times[i] = (int)Time.time;
                check_times = true;
                i++;
                check_hurt = true;
            }
            Movement();
            check_times = false;
        }
        else
            check_times = false;
    }
    
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && check_hurt) {
            joy_move.hp -= 1;
            // fill.offsetMax = new Vector2(fill.offsetMax.x-(150/joy_move.start_hp),fill.offsetMax.y);
            check_hurt = false;
        }
        if (other.tag == "Snow") {
            is_snow = true;
        }
        if (other.tag == "grass")
            Debug.Log(2);
    }
    
    public bool NotInTimes(int times) { // can not use same sec, like 3.1,3.2,as int() it
        for (int i = 0;i < used_times.Length;i++) {
            if (times == used_times[i]) 
                return false;
            if (used_times[i] == 0)
                return true;
        }
        return true;
    }
    
    public void Back() { // back to start_pos, and as it cut 10 parts 
        transform.position = new Vector3(transform.position.x+(Math.Abs(transform.position.x-start_pos.x)/10.0f),transform.position.y-(Math.Abs(transform.position.y-start_pos.y))/10.0f,transform.position.z);
    }
    
    public void Movement() {
        if (check_times) {
            for (int i = 1;i < 11;i++) {
                if (!is_snow)
                    Invoke("Movement2",i*0.05f);
                else
                    Invoke("Movement3",i*0.05f);
            }
            for (int i = 11;i < 21;i++)
                Invoke("Back",i*0.05f);
        }
    }
    
    public void Movement2() {
        transform.position = new Vector3(transform.position.x-0.5f,transform.position.y,transform.position.z);
    }
    
    public void Movement3() { // 70.05 -12.16 67.32 -10.91
        transform.position = new Vector3(transform.position.x-0.273f,transform.position.y+0.125f,transform.position.z);
    }
}
