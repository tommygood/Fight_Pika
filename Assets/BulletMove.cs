using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour { 
    public Rigidbody2D rb;
    
    public SpriteRenderer sprite_renderer;
    
    public Sprite BulletExplo;
    
    public GameObject Bullet;
    
    void Start() {
        rb.velocity = transform.right * 20f;
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            PikaBlood pika = other.GetComponent<PikaBlood>();
            WallMove wall_move = other.GetComponent<WallMove>();
            if (pika != null)
                pika.MakeDamage(1);
            if (wall_move != null)
                wall_move.MakeDamage(1);
            rb.velocity = transform.right * 0f;
            sprite_renderer.sprite = BulletExplo;
            Destroy(Bullet,0.2f);
        }
    }
}
