using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingMove1 : MonoBehaviour {
    public int[] used_times = new int[10000];
    
    private bool check = true;
    
    public GameObject flag;
    
    public JoyMove joy_move;
    
    private float time_counter = 0f;
    
    void Update() {
        time_counter += Time.deltaTime;
        if (time_counter > 0.8f&& joy_move.check_floor2) { // 0.8/1
            check = true;
            time_counter = 0f;
        }
        Move();
        check = false;
    }
    
    public bool NotInTimes(int times) {
        for (int i = 0;i < used_times.Length;i++) {
            if (used_times[i] == times)
                return false;
        }
        return true;
    }
    
    public void Move() { // -15 -8 -59 |-49 -39 -41| -1.85 0.17 0.01
        if (check) {
            for (int i = 1;i < 11;i++)
                Invoke("Move1",i*0.05f);
            for (int i = 11;i < 21;i++)
                Invoke("Back",i*0.05f);
        }
    }
    
    public void Move1() {
        transform.Rotate(-3.4f,-3.1f,1.8f);
        // flag.transform.Rotate(0f,18f,0f);
    }
    
    public void Back() {
        transform.Rotate(3.4f,3.1f,-1.8f);
    }
}
