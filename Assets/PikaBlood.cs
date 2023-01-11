using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikaBlood : MonoBehaviour {
    public int Blood;
    
    public SpriteRenderer sr;
    
    public Sprite explo;
    
    public GameObject Pika;
    
    public JoyMove joy_move;
    
    public GameObject Bt;
    
    public bool check_bt = false;
    
    void Start() {
        Blood = 10;
        if (transform.position.x == 43.4f)
            check_bt = true;
    }
    
    public void MakeDamage(int damage) {
        Blood -= damage;
        if (Blood <= 0) {            
            if (check_bt)
                Bt.SetActive(true);
            sr.sprite = explo;
            Destroy(Pika,0.8f);
            Invoke("GetScore",0.799f); // before destroy little bit,as the KnockNum can not plus shoot on explo 
        }
    }
    
    void GetScore() {
        joy_move.KnockNum += 1;
    }
}
