using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMove : MonoBehaviour {
    public Text text;
    
    private float time_count = 0f;
    
    private string word;
    
    private int i = 0;
    
    public bool check_end = false;
    
    public GameObject plot_text;
    
    void Start() {
        word = text.text; // restore
        text.text = ""; // clean
        text.color = Color.blue;
    }
    
    void Update() { // text.text.Substring(0,1)
        time_count += Time.deltaTime;
        if (time_count > 0.25f && !check_len()) {
            i++;
            text.text = word.Substring(0,i);
            time_count = 0f;
        }
    }
    
    public bool check_len() {
        if (i >= word.Length) {
            Invoke("Delay",1f);
            return true;
        }
        else 
            return false;
    }
    
    public void Delay() {
        plot_text.SetActive(false);
        check_end = true;
    }
}
