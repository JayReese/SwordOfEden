using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Emitters;
    byte NumberOfEmitters;

	// Use this for initialization
	void Start ()
    {
        //Emitter = transform.GetChild(0).GetComponent<BulletEmitter>();
        Emitters = new List<GameObject>();
        NumberOfEmitters = 3;

        CreateEmitters();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void CreateEmitters()
    {
        GameObject o = Resources.Load("Prefabs/Bullet Emitter") as GameObject;
        o.transform.localPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        for (int i = 0; i < NumberOfEmitters; i++)
        {
            Instantiate(o, transform);
            Emitters.Add(o);
        } 
    }
}
