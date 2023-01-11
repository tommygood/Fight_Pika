using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Math

public class PikaMove : MonoBehaviour {
    public Vector3 start_pos;
    
    public GameObject Py;
    
    public GameObject flash;
    
    public SpriteRenderer sr;
    
    public Sprite nor_pika;
    
    public Sprite pika_light;
    
    public bool check = false;
    
    public static int[] used_times = new int[100]; 
    
    public static int i = 0; // used_times's index
    
    void Start() {
        start_pos = transform.position;
    }
    
    void Update() {
        if (Math.Abs(transform.position.x-Py.transform.position.x) < 5) { // if range in 5 
            if ((int)Time.time % 3 == 0 && NotInTimes((int)Time.time)) { // pika attack 1/3sec
                used_times[i] = (int)Time.time;
                check = true;
                i++;
            }
            Movement();
            check = false;
        }
        else
            check = false;
    }
    
    public static bool NotInTimes(int times) { // can not use same sec, like 3.1,3.2,as int() it
        for (int i = 0;i < used_times.Length;i++) {
            if (times == used_times[i]) 
                return false;
            if (used_times[i] == 0)
                return true;
        }
        return true;
    }
    
    public void Movement() {
        if (check) {
            for (int i = 1;i < 11;i++)
                Invoke("Movement2",i*0.1f);
            Invoke("Light",1f); // light the pika
            Invoke("ThunderBolt",1.3f); // Thunderbolt
            Invoke("relocate",1.8f);
        }
    }
    
    public void relocate() {
        flash.SetActive(false);
        transform.position = start_pos;
        sr.sprite = nor_pika;
    }
    
    public void ThunderBolt() { // 1.2 1.8 -1
        //flash.transform.position = new Vector3(Py.transform.position.x+1.2f,Py.transform.position.y+1.8f,Py.transform.position.z-1f);
        flash.SetActive(true);
        // Debug.Log(flash.transform.position - Py.transform.position);
    }
    
    public void Light() {
        sr.sprite = pika_light;
    }
    
    public void Movement2() {
        transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+36f);
        transform.position = new Vector3(transform.position.x-0.2f,transform.position.y+0.4f,transform.position.z);
    }
}
