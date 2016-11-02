using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    float MovementSpeed,
        VerticalMovement, HorizontalMovement;
    [SerializeField]
    Vector3 MovementVector;

	// Use this for initialization
	void Start ()
    {
        MovementSpeed = 3f;  
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
	}

    void Move()
    {
        MovementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.position += MovementVector * MovementSpeed * Time.deltaTime;
    }
}
