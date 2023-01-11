using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBtOn : MonoBehaviour {
    public GameObject Py;
    
    public int jump_times = 0;
    
    public Vector3 start_pos;
    
    public JoyMove joy_move;
    
    public float ran_num;
    
    public Rigidbody2D rb;
    
    public void JumpBt() {
        if (jump_times < 1) { // two times jump
            rb.gravityScale = 0;
            if (!joy_move.is_snow) {
                for (int i = 0;i < 10;i++)
                    Invoke("Jump",(i+1f)*0.1f);
            }
            else if (joy_move.is_snow) {
                MakeRan();
                for (int i = 0;i < 10;i++)
                    Invoke("Jump2",(i+1f)*0.1f);
            }
            Invoke("Back",1f);
            jump_times++;
        }
    }
    
    public void Back() {
        rb.gravityScale = 1;
    }
    
    public void MakeRan() { // make py angle changed when jump on snow
        ran_num = (float)Random.Range(-40,40);
    }
    
    public void Jump2() {
        Py.transform.position = new Vector3(Py.transform.position.x,Py.transform.position.y+0.2f,Py.transform.position.z);
        Py.transform.Rotate(0f,0f,ran_num/3);
    }
    
    public void Jump() {
        Py.transform.position = new Vector3(Py.transform.position.x,Py.transform.position.y+0.2f,Py.transform.position.z);
    }
}
