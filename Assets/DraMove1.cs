using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DraMove1 : MonoBehaviour {
    private bool check_bound = true;
    
    private bool check1 = false;
    
    public GameObject fire;
    
    private bool check_fire = false;
    
    public JoyMove joy_move;
    
    public FlagMove flag_move;
    
    private bool check_used2 = true;
    
    public GameObject py;
    
    private float distance;
    
    private float distance1;
    
    private float time_counter = 0f;
    
    void Update() { // 136.66 -67.23 139.58 -71.94 | goal 161 159.1 -68.2
        if (joy_move.check_floor2 && !flag_move.check_py) {
            if (check_bound) {
                transform.Rotate(0f,-180f,-100f); // reverse
                for (int i = 1;i < 101;i++)
                    Invoke("Move",i*0.06f);
                check_bound = false;
            } 
            if (!(transform.position.x > 101.83f && transform.position.x < 113.8f) && check1) { // out of bounds
                check_bound = true;
                check1 = false;
            }
            if (transform.position.x >= 110f && check_fire)
                fire.SetActive(true);
        }
        if (flag_move.check_py) {
            time_counter += Time.deltaTime;
            if (time_counter > 2f) {
                fire.SetActive(true);
                Invoke("Unfire",2f);
                time_counter = 0f;
            }
            if (check_used2) {
                transform.eulerAngles = new Vector3(0f,-4f,-67.6f);
                distance = 158.4f - transform.position.x;
                for (int i = 1;i < 1001;i++) {
                    Invoke("Move1",i*0.015f);
                    check_used2 = false;
                }
                Invoke("EnCheckUp",15f); // make dranite up to the point
            }
        }
    }
    
    public void EnCheckUp() { // start to up to point
        distance1 = transform.position.y + 68.2f;
        for (int i = 1;i < 101;i++) 
            Invoke("Move2",i*0.02f);
    }
    
    public void Move2() {
        transform.position = new Vector3(159.1f,transform.position.y+(distance1/100f),transform.position.z);
    }
    
    public void Unfire() {
        fire.SetActive(false);
    }
    
    public void Move1() {
        transform.position = new Vector3(transform.position.x+(distance/1000f),py.transform.position.y+4.51f,transform.position.z);
    }
    
    public void Move() { 
        check1 = true; // can not entrue immediately
        if (transform.eulerAngles.y-180 < 0) {
            check_fire = false;
            fire.SetActive(false);
            transform.position = new Vector3(transform.position.x-0.12f,transform.position.y,transform.position.z);
        }
        else { // 113.83
            check_fire = true;
            transform.position = new Vector3(transform.position.x+0.12f,transform.position.y,transform.position.z);
        }
    }
}
