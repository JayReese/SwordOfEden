using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	    //Direction = new Vector2(transform.up.x, transform.up.y);
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

    void OnBecameInvisible()
    {
        Debug.Log("Obj invis");
        Reset(transform.parent.gameObject);
    }

    void Reset(GameObject emitter)
    {
        emitter.GetComponent<BulletEmitter>().AddBackToIndex();
        gameObject.SetActive(false);
    }


}
