using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {
    //public vars
    public GameObject player;
    //private vars
    private Vector3 offset;
	//Initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("player");
        offset = transform.position - player.transform.position;
	}
	//LateUpdate is called once per frame, guarenteed to run after all items have been processed
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
