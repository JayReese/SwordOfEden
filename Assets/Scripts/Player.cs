using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    float MovementSpeed,
        VerticalMovement, HorizontalMovement;
    [SerializeField]
    Vector3 MovementVector;
    [SerializeField]
    float MouseMovementX, RotationParameter;
    [SerializeField]
    bool RotatingMovement;

	// Use this for initialization
	void Start ()
    {
        RotatingMovement = false;
        MovementSpeed = 3f;  
	}
	
	// Update is called once per frame
	void Update ()
    {
        Rotate();
        Move();
	}

    private void Rotate()
    {
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, -Input.GetAxisRaw("Mouse X") * 10f));
    }

    void Move()
    {
        MovementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.position += transform.up * Input.GetAxisRaw("Vertical") * 0.05f;
    }
}
