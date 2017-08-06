using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLights : MonoBehaviour {

    GameObject player;
    Vector3 heightChange = new Vector3(0.0f, 0.05f, 0.0f);
    bool active;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (active && player.transform.localPosition.y > this.transform.localPosition.y + this.gameObject.transform.GetChild(0).transform.localPosition.y + transform.localScale.y / 2)
        {
            player.transform.localPosition += heightChange / 2;
            this.gameObject.transform.GetChild(0).transform.localScale += heightChange;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
            active = true;
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
            active = false;
    }
}
