using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBtOn : MonoBehaviour {
    public GameObject RtHand;
    
    public GameObject LtHand;
    
    public GameObject SwordBt;
    
    public GameObject AkBt;
    
    public GameObject bare_bt;
    
    public GameObject Sword;
    
    public GameObject SlashBt;
    
    public GameObject Py;
    
    public void sword_bt_on() { // r 1.42 1.55 -21 l 0.39 0.28 139
        Py.transform.eulerAngles = new Vector3(0f,0f,0f);
        SwordBt.SetActive(false);
        AkBt.SetActive(false);
        bare_bt.SetActive(false);
        Sword.SetActive(true);
        SlashBt.SetActive(true);
        RtHand.transform.position = new Vector3(RtHand.transform.position.x,RtHand.transform.position.y+0.7f,RtHand.transform.position.z);
        RtHand.transform.eulerAngles = new Vector3(0f,0f,140f);
        LtHand.transform.position = new Vector3(LtHand.transform.position.x-1f,LtHand.transform.position.y+0.5f,LtHand.transform.position.z);
        LtHand.transform.eulerAngles = new Vector3(0f,0f,139f);
    }
}
