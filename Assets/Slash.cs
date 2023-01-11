using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour {
    public GameObject SlashBlood;
    
    // public PikaBlood pika_blood;
    
    // public GameObject pika2;
    
    public GameObject Bridge;
    
    public GameObject Bridge1;
    
    public SlashBtOn slash_bt_on;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            SlashBlood.SetActive(true);
            // PikaBlood pika = other.GetComponent<PikaBlood>(); other == pika
            PikaBlood pika = other.GetComponent<PikaBlood>();
            pika.MakeDamage(1);
        }
        if (other.name == "Stick1" && slash_bt_on.check_sword_bt) {
            Bridge.transform.position = new Vector3(Bridge.transform.position.x,Bridge.transform.position.y-0.5f,Bridge.transform.position.z);
            Bridge.transform.Rotate(0f,0f,-3f);
            slash_bt_on.check_sword_bt = false;
        }
            
        if (other.name == "Stick" && slash_bt_on.check_sword_bt) {
            Bridge1.transform.position = new Vector3(Bridge1.transform.position.x,Bridge1.transform.position.y-0.5f,Bridge1.transform.position.z);
            Bridge1.transform.Rotate(0f,0f,-3f);
            slash_bt_on.check_sword_bt = false;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Enemy")
            SlashBlood.SetActive(false);
    }
}
