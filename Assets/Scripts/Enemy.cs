using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    BulletEmitter Emitter;

	// Use this for initialization
	void Start ()
    {
        Emitter = transform.GetChild(0).GetComponent<BulletEmitter>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
