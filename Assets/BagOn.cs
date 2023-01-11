using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagOn : MonoBehaviour {
    public GameObject AkBt;
    
    public GameObject bagbt;
    
    public GameObject SwordBt;
    
    public GameObject bare_bt;
    
    public void AkBtON() {
        bare_bt.SetActive(true);
        AkBt.SetActive(true);
        SwordBt.SetActive(true);
        bagbt.SetActive(false);       
    }
}
