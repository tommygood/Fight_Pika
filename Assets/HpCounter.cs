using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCounter : MonoBehaviour {
    public Text text;
    
    public JoyMove joy_move;
    
    void Update() {
        text.text = joy_move.hp.ToString();
        text.color = Color.yellow;
    }
}
