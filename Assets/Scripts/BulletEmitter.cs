using UnityEngine;
using System.Collections;

public class BulletEmitter : MonoBehaviour
{
    [SerializeField]
    GameObject StoredBullet;

    // Use this for initialization
    void Start ()
    {
        StoredBullet = Resources.Load("Prefabs/Test Prefabs/testbullet") as GameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}