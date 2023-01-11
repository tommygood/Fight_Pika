using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoyMove : MonoBehaviour {
    public Vector3 lt_hand_pos;
    
    public Vector3 rt_hand_pos;
    
    public GameObject rt_hand;
    
    public GameObject lt_hand;
    
    public int KnockNum = 0;
    
    public int hp = 10;
    
    public Joystick joy;
    
    public GameObject Py;
    
    public GameObject RtLeg;
    
    public GameObject LtLeg;
    
    private bool check = true;
    
    private float speed = 0.05f;
    
    public JumpBtOn jump_bt_on;
    
    public GameObject big_square;
    
    public float die_delay_time; // the delay time of die and back to the start scene
    
    public bool check_die_time = true;
    
    public GameObject loss_panel;
    
    public bool is_snow = false;
    
    public GameObject board;
    
    public GameObject came;
    
    public bool check_star = false;
    
    public bool check_floor2 = false;
    
    public bool check_normal = true;
    
    public bool check_flag = false;
    
    public GameObject load_back;
    
    private bool check_tips = true;
    
    public Rigidbody2D rb;
    
    public GameObject plot_panel;
    
    public TextMove text_move;
    
    public FlagMove flag_move;
    
    public GameObject flag;
    
    public Collider2D bri_coli;
    
    public Collider2D bri_1_coli;
    
    public static bool check_star1 = false;
    
    private bool check_tips1 = true;
    
    public Rigidbody2D rock_rb;
    
    public bool check_rock = false;
    
    public bool check_on_rock = false;
    
    public GameObject canvas1;
    
    public WallMove wall_move;
    
    public WallMove wall_move1;
    
    public WallMove wall_move2;
    
    public WallMove wall_move3;
    
    public static bool test = true;
    
    public GameObject canvas;
    
    private Vector3 big_square_start_pos;
    
    public int start_hp;
    
    public int start_hp2;
    
    public RectTransform fill;
    
    /*public void Awake() {
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(Py);
        DontDestroyOnLoad(came);
    }*/
    
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "grass") {
            jump_bt_on.jump_times = 0;
        }
        if (other.tag == "Snow") {
            board.SetActive(true);
            is_snow = true;
            check_normal = false;
            jump_bt_on.jump_times = 0;
        }
        if (other.name == "Star") {            
            check_star = true;
            check_normal = false;
            is_snow = false;
            if (check_tips) {
                StartTips();
                Invoke("MoveToAir",6f);
                check_tips = false;
            }
            rb.gravityScale = 0;
            Invoke("BackGra",6f);
        }
        if (other.name == "Floor2") {
            check_normal = false;
            is_snow = false;
            board.SetActive(false);
            check_floor2 = true;
            check_star = false;
            bri_1_coli.isTrigger = false;
            bri_coli.isTrigger = false;
        }
        if (other.name == "Flag") {
            check_star = false;
            bri_1_coli.isTrigger = false;
            bri_coli.isTrigger = false;
            check_normal = false;
            is_snow = false;
            board.SetActive(false);
            check_floor2 = false;
            check_flag = true;
        }
        if (other.name == "Trap" || other.name == "Trap1") {
            transform.Rotate(0f,0f,-90f);
            hp = 0;
        }
        if (other.name == "Fire")
            hp -= 1;
        if (other.name == "Star1") {
            flag_move.check_py = false;
            check_star = false;
            bri_1_coli.isTrigger = false;
            bri_coli.isTrigger = false;
            check_normal = false;
            is_snow = false;
            board.SetActive(false);
            check_floor2 = false;
            check_flag = false;
            check_star1 = true;
            if (check_tips1) {
                StartTips();
                Invoke("MoveToAir1",6f);
            }
            check_tips1 = false;
        }
        if (other.name == "BigRock") {
            check_rock = true;
            if (!check_on_rock) {
                for (int i = 1;i < 101;i++)
                    Invoke("OnRockMove",i*0.02f);
                check_on_rock = true;
            }
            hp = 0;
        }
    }
    
    void Start() {
        rt_hand_pos = rt_hand.transform.position-Py.transform.position;
        lt_hand_pos = lt_hand.transform.position-Py.transform.position;
        //Debug.Log(rt_hand_pos-Py.transform.position);
        //Debug.Log(lt_hand_pos-Py.transform.position);
        RtLeg.transform.eulerAngles = new Vector3(0f,0f,0f);
        LtLeg.transform.eulerAngles = new Vector3(0f,0f,0f);
        big_square_start_pos = big_square.transform.position;
        start_hp = hp;
        start_hp2 = hp;
    }
    
    void Update() { // +(joy.Vertical)*speed
        if (hp < start_hp) {
            fill.offsetMax = new Vector2(fill.offsetMax.x-(150/start_hp2),fill.offsetMax.y);
            start_hp -= 1;
        }
        if (!is_snow && hp > 0 && !check_star && !check_on_rock) {
            if (!flag_move.check_py)
                Py.transform.position = new Vector3(Py.transform.position.x+(joy.Horizontal)*speed,Py.transform.position.y,1f);
            if (flag_move.check_py) {
                if (transform.position.y < -90f) { // out of down bounds
                    if (joy.Vertical > 0) { // still go down
                        Py.transform.position = new Vector3(Py.transform.position.x+(joy.Horizontal)*speed,Py.transform.position.y+(joy.Vertical)*speed,1f);
                        flag.transform.position = new Vector3(flag.transform.position.x+(joy.Horizontal)*speed,flag.transform.position.y+(joy.Vertical)*speed,flag.transform.position.z);
                    }
                    else {
                        Py.transform.position = new Vector3(Py.transform.position.x+(joy.Horizontal)*speed,Py.transform.position.y,1f);
                        flag.transform.position = new Vector3(flag.transform.position.x+(joy.Horizontal)*speed,flag.transform.position.y,flag.transform.position.z);
                    }
                }
                else {
                    Py.transform.position = new Vector3(Py.transform.position.x+(joy.Horizontal)*speed,Py.transform.position.y+(joy.Vertical)*speed,1f);
                    flag.transform.position = new Vector3(flag.transform.position.x+(joy.Horizontal)*speed,flag.transform.position.y+(joy.Vertical)*speed,flag.transform.position.z);
                }
            }
            if (joy.Horizontal < 0)
                Py.transform.eulerAngles = new Vector3(0f,180f,0f);
            if (joy.Horizontal > 0)
                Py.transform.eulerAngles = new Vector3(0f,0f,0f);
            if (joy.Horizontal != 0) {
                if (check && joy.Horizontal > 0)
                    Invoke("LegMove1",0.2f);
                else if (!check && joy.Horizontal > 0)
                    Invoke("LegMove2",0.2f);
                else if (check && joy.Horizontal < 0)
                    Invoke("LegMove3",0.2f);
                else if (!check && joy.Horizontal < 0)
                    Invoke("LegMove4",0.2f);
            }
        }
        else if (is_snow && hp > 0 && !check_on_rock) {
            Py.transform.position = new Vector3(Py.transform.position.x+(joy.Horizontal)*speed,Py.transform.position.y,1f);
            /*if (joy.Horizontal < 0) 
                Py.transform.eulerAngles = new Vector3(0f,180f,0f);
            if (joy.Horizontal > 0)
                Py.transform.eulerAngles = new Vector3(0f,0f,0f);*/
            if (joy.Horizontal != 0) {
                if (check && joy.Horizontal > 0)
                    Invoke("LegMove1",0.2f);
                else if (!check && joy.Horizontal > 0)
                    Invoke("LegMove2",0.2f);
                else if (check && joy.Horizontal < 0)
                    Invoke("LegMove3",0.2f);
                else if (!check && joy.Horizontal < 0)
                    Invoke("LegMove4",0.2f);
            }        
        }
        if (hp <= 0) { // py died
            loss_panel.SetActive(true);
            if (check_die_time) { // set the time py die
                die_delay_time = Time.time;
                check_die_time = false;
            }
            if (Time.time > die_delay_time+4f) { // after 3s py die, back to start scene
                canvas1.SetActive(true);
                check_on_rock = false;
            }
            wall_move.check_back = true;
            wall_move.check_used = true;
            wall_move1.check_back = true;
            wall_move1.check_used = true;
            wall_move2.check_back = true;
            wall_move2.check_used = true;
            wall_move3.check_back = true;
            wall_move3.check_used = true;
            big_square.transform.position = big_square_start_pos;
            big_square.SetActive(false);
        }
        if (text_move.check_end)
            plot_panel.SetActive(false);
    }
    
    public void OnRockMove() {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z-12f);
        transform.position = new Vector3(transform.position.x,transform.position.y-0.2f,transform.position.z);
    }
    
    public void MoveToAir1() {
        load_back.SetActive(false);
        transform.position = new Vector3(210f,-72.5f,transform.position.z);
        rock_rb.gravityScale = 1;
    }
    
    public void BackGra() {
        rb.gravityScale = 1;
    }
    
    public void StartTips() {
        load_back.SetActive(true);
    }
    
    public void MoveToAir() {
        load_back.SetActive(false);
        transform.position = new Vector3(105.6f,-58f,transform.position.z);
    }
    
    public void LegMove1() { 
        RtLeg.transform.eulerAngles = new Vector3(0f,0f,20f);
        LtLeg.transform.eulerAngles = new Vector3(0f,0f,20f);
        //RtLeg.transform.position = new Vector3(RtLeg.transform.position.x,RtLeg.transform.position.y-0.2f,RtLeg.transform.position.z);
        //LtLeg.transform.position = new Vector3(LtLeg.transform.position.x,LtLeg.transform.position.y-0.2f,LtLeg.transform.position.z);
        check = false;
    }
    
    public void LegMove2() {
        RtLeg.transform.eulerAngles = new Vector3(0f,0f,0f);
        LtLeg.transform.eulerAngles = new Vector3(0f,0f,0f);
        //RtLeg.transform.position = new Vector3(RtLeg.transform.position.x,RtLeg.transform.position.y+0.2f,RtLeg.transform.position.z);
        //LtLeg.transform.position = new Vector3(LtLeg.transform.position.x,LtLeg.transform.position.y+0.2f,LtLeg.transform.position.z);
        check = true;
    }
    
    public void LegMove3() {
        RtLeg.transform.eulerAngles = new Vector3(0f,180f,20f);
        LtLeg.transform.eulerAngles = new Vector3(0f,180f,20f);
        check = false;
    }
    
    public void LegMove4() {
        RtLeg.transform.eulerAngles = new Vector3(0f,360f,0f);
        LtLeg.transform.eulerAngles = new Vector3(0f,360f,0f);
        check = true;
    }
}
