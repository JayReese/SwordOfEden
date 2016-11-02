using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    Vector3 Direction;
	// Use this for initialization
	void Start ()
    {
	    Direction = new Vector2(transform.up.x, transform.up.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += Direction * Time.deltaTime * 6f;
	}
}
