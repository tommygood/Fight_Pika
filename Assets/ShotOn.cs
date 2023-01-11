using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotOn : MonoBehaviour {
    public GameObject Bullet;
    
    public GameObject Ak;
    
    public GameObject RtHand;
    
    public GameObject LtHand;
    
    public GameObject Py;
    
    public Vector3 start_pos;
    
    private bool check = true;
    
    public int bullet = 30;
    
    public void Shoot() {
        // Instantiate(object,position,rotation);
        if (bullet > 0) {
            Instantiate(Bullet,Ak.transform.position,Ak.transform.rotation);
            MoveAk();
            MoveHand();       
            bullet--;
        }
    }
    
    public void MoveAk() {
        start_pos = Ak.transform.position;
        Ak.transform.position = new Vector3(Ak.transform.position.x,Random.Range(start_pos.y+0.1f,start_pos.y+0.2f),Ak.transform.position.z);
        Invoke("MoveAk2",0.1f);
    }
    
    public void MoveAk2() { // 0.7 -0.3 -1
        if (Py.transform.eulerAngles.y == 0f) 
            Ak.transform.position = new Vector3(Py.transform.position.x+0.7f,Py.transform.position.y-0.3f,Py.transform.position.z-1);
        else // if Py reverse, gun's x pos need to add reverse 
            Ak.transform.position = new Vector3(Py.transform.position.x-0.7f,Py.transform.position.y-0.3f,Py.transform.position.z-1);
    }
    
    public void MoveHand() {
        if (check) {
            RtHand.transform.Rotate(0f,0f,15f);
            check = false;
        }
        else {
            RtHand.transform.Rotate(0f,0f,-15f);
            check = true;
        }
    }
}
