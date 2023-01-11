using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkBtOn : MonoBehaviour {
    public GameObject AkBt;
    
    public GameObject ak;
    
    public GameObject sword_bt;
    
    public GameObject ShotBt;
    
    public GameObject bare_bt;
    
    public GameObject RtHand;
    
    public GameObject LtHand;
    
    public GameObject bullet_text;
    
    public void OffAkBt() {
        bare_bt.SetActive(false);
        sword_bt.SetActive(false);
        AkBt.SetActive(false);
        ak.SetActive(true);
        ShotBt.SetActive(true);
        bullet_text.SetActive(true);
        RtHand.transform.Rotate(0f,0f,45f);
        LtHand.transform.Rotate(0f,0f,45f);
        RtHand.transform.Rotate(0f,0f,45f);
        LtHand.transform.Rotate(0f,0f,45f);
        RtHand.transform.position = new Vector3(RtHand.transform.position.x+0.11f,RtHand.transform.position.y+0.6f,RtHand.transform.position.z);
        LtHand.transform.position = new Vector3(LtHand.transform.position.x+0.09f,LtHand.transform.position.y+0.6f,LtHand.transform.position.z);
    }
}
