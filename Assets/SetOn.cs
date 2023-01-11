using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOn : MonoBehaviour {
    public GameObject bag;
    
    public GameObject ShotBt;
    
    public bool CheckShotBt = false;
    
    public AkBtOn Ak_Bt_On;
    
    public FlagMove flag_move;
    
    public GameObject warn_panel;
    
    private bool check_panel = true;
    
    public void BagOn() {
        if (!flag_move.check_py)
            bag.SetActive(true);
        if (flag_move.check_py && check_panel) {
            warn_panel.SetActive(true);
            Invoke("UnPanel",2f);
            check_panel = false;
        }
    }
    
    public void UnPanel() {
        warn_panel.SetActive(false);
        check_panel = true;
    }
}
