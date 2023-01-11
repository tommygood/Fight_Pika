using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBtOn : MonoBehaviour {
    public GameObject LtHand;
    
    public GameObject RtHand;
    
    public GameObject Sword;
    
    public bool check_sword_bt = false;
    
    public void slash_bt_on() { // 220 95
        check_sword_bt = true;
        Movement();
    }
    
    public void Movement() {
        float x = 0;
        for (int i = 1;i < 10;i++) // these 2 for loop's i range must be same,or the angles change 
            Invoke("Movement2",x+i*0.04f);
        for (int i = 11;i < 20;i++)
            Invoke("Movement3",x+i*0.04f);
        for (int i = 21;i < 30;i++)
            Invoke("Movement2",x+i*0.04f);
    }
    
    public void Movement2() {
        LtHand.transform.eulerAngles = new Vector3(LtHand.transform.eulerAngles.x,LtHand.transform.eulerAngles.y,LtHand.transform.eulerAngles.z+15f);
        RtHand.transform.eulerAngles = new Vector3(RtHand.transform.eulerAngles.x,RtHand.transform.eulerAngles.y,RtHand.transform.eulerAngles.z+15f);
    }
    
    public void Movement3() {
        LtHand.transform.eulerAngles = new Vector3(LtHand.transform.eulerAngles.x,LtHand.transform.eulerAngles.y,LtHand.transform.eulerAngles.z-30f);
        RtHand.transform.eulerAngles = new Vector3(RtHand.transform.eulerAngles.x,RtHand.transform.eulerAngles.y,RtHand.transform.eulerAngles.z-30f);
    }
}
