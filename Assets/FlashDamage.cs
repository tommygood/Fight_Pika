using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDamage : MonoBehaviour {
    public JoyMove joy_move;
    
    public RectTransform fill;
    
    public void OnTriggerEnter2D(Collider2D other) { // 46.6 196.4
        joy_move.hp -= 1;
        // fill.offsetMax = new Vector2(fill.offsetMax.x-(150/joy_move.start_hp),fill.offsetMax.y);
    }
}
