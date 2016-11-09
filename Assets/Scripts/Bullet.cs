using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Vector3 Direction, StartPosition, StartRotation;
	// Use this for initialization
	void Start ()
    {
	    Direction = new Vector2(transform.up.x, transform.up.y);
    }

    void OnEnable()
    {
        Debug.Log("Bullet spawned");
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.up * Time.deltaTime * 6f;
	}
}
