using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour {
    public int hp = 3;
    
    public bool check_used = true;
    
    public JoyMove joy_move;
    
    private Vector3 start_angle;
    
    private Vector3 start_pos;
    
    public bool check_back = true;
    
    private bool check_pos = true;
    
    public GameObject wall;
    
    public float count_time;
    
    void Update() {
        if (check_pos) { // find start position
            start_pos = transform.position;
            start_angle = transform.eulerAngles;
            check_pos = false;
        }
        if (hp <= 0 && check_used) {
            count_time = 0;
            for (int i = 1;i < 101;i++)
                Invoke("Move",i*0.01f);
            check_used = false;
            // Invoke("GetPos",1f);
        }
        if (joy_move.hp <= 0 && check_back) {
            count_time += Time.deltaTime;
            if (count_time >= 4f) {
                transform.position = start_pos;
                transform.eulerAngles = start_angle;
            }
            check_back = false;
            hp = 3;
        }
    }
    
    public void GetPos() {
        Debug.Log(transform.position);
    }
    
    public void Move() { // 0 51.4 -3.3 |86.6 -39.9 -91.4|) 296.5 -77.8 39.4 |296 -91.9 40.1
        transform.eulerAngles = new Vector3(transform.eulerAngles.x+0.866f,transform.eulerAngles.y-0.913f,transform.eulerAngles.z-0.881f);
        transform.position = new Vector3(transform.position.x,transform.position.y-0.181f,transform.position.z);
    }
    
    public void MakeDamage(int damage) {
        hp -= damage;
    }
}
