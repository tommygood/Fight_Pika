using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushroomMove : MonoBehaviour {
    public GameObject py;
    
    public GameObject rushroom;
    
    private bool check_used = true;
    
    private bool check_used2 = true;
    
    public JoyMove joy_move;
    
    public SpriteRenderer sr;
    
    public Sprite explo;
    
    void Update() { // 145.2 -67.2 -71.9
        if ((transform.position.x - py.transform.position.x) < 3f && check_used && joy_move.check_flag) {
            for (int i = 1;i < 11;i++)
                Invoke("Move",i*0.1f);
            Invoke("Unrush",1.01f);
            check_used = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player" && check_used2) {
            joy_move.hp -= 1;
            check_used2 = false;
            sr.sprite = explo;
        }
    }
    
    public void Unrush() {
        rushroom.SetActive(false);
    }
    
    public void Move() {
        rushroom.transform.position = new Vector3(rushroom.transform.position.x,rushroom.transform.position.y-0.57f,rushroom.transform.position.z);
    }
}
