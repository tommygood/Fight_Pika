using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFirst : MonoBehaviour {
    public JoyMove joy_move;
    
    public GameObject canvas;
    
    public GameObject canvas1;
    
    public GameObject loss_panel;
    
    public GameObject py;
    
    public GameObject big_rock;
    
    private Vector3 big_rock_pos;
    
    public GameObject bt_down1;
    
    public ShotOn shot_on;
    
    public RectTransform fill;
    
    public void Start() {
        big_rock_pos = big_rock.transform.position;
    }
    
    public void ChangeScene() {
        // SceneManager.LoadScene(2);
        joy_move.hp = joy_move.start_hp2; // reset
        joy_move.start_hp = joy_move.start_hp2;
        fill.offsetMax = new Vector2(-46.6f,fill.offsetMax.y);
        shot_on.bullet = 30;
        joy_move.check_die_time = true;
        canvas.SetActive(true);
        canvas1.SetActive(false);
        loss_panel.SetActive(false);
        if (joy_move.is_snow) { // clear 1
            py.transform.position = new Vector3(82.2f,6.1f,py.transform.position.z);
            joy_move.is_snow = false;
        }
        joy_move.check_normal = true;
        if (joy_move.check_floor2) {
            joy_move.check_normal = false;
            py.transform.position = new Vector3(102.5f,-62.7f,py.transform.position.z);
        }
        if (JoyMove.check_star1) {
            big_rock.transform.position = big_rock_pos; // back to start pos
            bt_down1.SetActive(true);
            py.transform.position = new Vector3(210f,-72.5f,transform.position.z);
        }
    }
}
