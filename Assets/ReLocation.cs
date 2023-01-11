using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReLocation : MonoBehaviour {
   public JoyMove joy_move;
   
   public GameObject lt_hand;
   
   public GameObject rt_hand;
   
   public GameObject bare_bt;
   
   public GameObject ak_bt;
   
   public GameObject sword_bt;
   
   public GameObject slash_bt;
   
   public GameObject shot_bt;
   
   public GameObject ak;
   
   public GameObject sword;
   
   public GameObject Py;
   
   public GameObject bullet_text;
   
   public void re_location() {
       bare_bt.SetActive(false);
       ak_bt.SetActive(false);
       sword_bt.SetActive(false);
       ak.SetActive(false);
       sword.SetActive(false);
       shot_bt.SetActive(false);
       slash_bt.SetActive(false);
       bullet_text.SetActive(false);
       Py.transform.eulerAngles = new Vector3(0f,0f,0f);
       lt_hand.transform.position = joy_move.lt_hand_pos + Py.transform.position;
       rt_hand.transform.position = joy_move.rt_hand_pos + Py.transform.position;
       lt_hand.transform.eulerAngles = new Vector3(0f,0f,0f);
       rt_hand.transform.eulerAngles = new Vector3(0f,0f,0f);
   }
}
