using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {
    public JoyMove joy_move;
    
    public Text score_text;
    
    void Update() {
        score_text.text = joy_move.KnockNum.ToString();
        score_text.color = Color.red;
    }
}
