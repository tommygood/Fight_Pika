using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMove : MonoBehaviour {
    public int[] used_times = new int[100];
    
    private bool check = false;
    
    public GameObject dot1;
    
    public GameObject dot2;
    
    private int i = 0;
    
    void Update() {
        if ((int)Time.time % 1 == 0 && NotInTimes((int)Time.time)) {
            used_times[i] = (int)Time.time;
            check = true;
            i++;
        }
        Move();
        Back();
        check = false;
    }
    
    public void Back() {
        if (check) {
            Invoke("Move1",0.5f);
        }
    }
    
    public void Move1() {
        // transform.position = new Vector3(transform.position.x,transform.position.y-9f,transform.position.z);
        dot1.transform.position = new Vector3(dot1.transform.position.x,dot1.transform.position.y-18f,dot1.transform.position.z);
        dot2.transform.position = new Vector3(dot2.transform.position.x,dot2.transform.position.y-27f,dot2.transform.position.z);
    }
    
    public void Move2() {
        dot1.transform.position = new Vector3(dot1.transform.position.x,dot1.transform.position.y+18f,dot1.transform.position.z);
    }
    
    public void Move3() {
        dot2.transform.position = new Vector3(dot2.transform.position.x,dot2.transform.position.y+27f,dot2.transform.position.z);
    }
    
    public void Move() {
        if (check) {
            // transform.position = new Vector3(transform.position.x,transform.position.y+9f,transform.position.z);
            Invoke("Move2",0.2f);
            Invoke("Move3",0.4f);
        }
    }
    
    public bool NotInTimes(int times) {
        for (int i = 0;i < used_times.Length;i++) {
            if (used_times[i] == times)
                return false;
        }
        return true;
    }
}
