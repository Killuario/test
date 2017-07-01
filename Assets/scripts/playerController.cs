using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    //public vars
    public float speed;
    public Text countText;
    public Text winText;
    //private vars
    private Rigidbody rb;
    private int count;
    //Initialization 
    void Start(){
        rb = GetComponent<Rigidbody>();
        countText = GameObject.FindGameObjectWithTag("countText").GetComponent<Text>();
        winText = GameObject.FindGameObjectWithTag("winText").GetComponent<Text>();
        speed = 10;
        count = 0;
        setCount(false);
    }
    //Called just before performing any physics calculations
    void FixedUpdate(){
        //apply force to the rigidbody equal to input times speed
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);
    }
    //Fires when two rigid bodies collide but one is set to Kinematic(ignores physics)
    private void OnTriggerEnter(Collider other){
        //if colliding with a pickUp object
        if (other.gameObject.CompareTag("pickUp")){
            other.gameObject.SetActive(false); //disable pickup
            setCount(true); //increment score and pass true for collision
        }
    }
    //Increment score
    void setCount(bool collision){
        //If a collision took place (with valid object) increment the score
        if (collision){
            count++;
        }
        //update label with new score
        countText.text = "Count: " + count.ToString();
        //check if a win, update speed and win label
        if (count >= 13){
            winText.text = "YOU WIN!";
            speed = 0;
        }else if(count == 0){
            winText.text = string.Empty;
        }
    }
}
