using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLights : MonoBehaviour
{

    GameObject player;
    Vector3 heightChange = new Vector3(0.0f, 0.5f, 0.0f);
    bool active;
    float frames;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (active && this.gameObject.transform.GetChild(0).transform.localScale.y > 1.0f)
        {
            frames += 1;
            if (frames >= 30)
            {
                player.transform.localPosition -= heightChange / 2;
                this.gameObject.transform.GetChild(0).transform.localScale -= heightChange;
                frames = 0;
            }

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
