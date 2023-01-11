using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCounter : MonoBehaviour {
    public ShotOn shot_on;
    
    public Text text;
    
    void Update() {
        text.text = shot_on.bullet.ToString();
        text.color = Color.yellow;
    }
}
