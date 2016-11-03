using UnityEngine;
using System.Collections;
using System;

public class BulletEmitter : MonoBehaviour
{
    [SerializeField] GameObject StoredBullet;
    [SerializeField] Vector3 FocalPoint, TranslationVector;
    [SerializeField] float MovementSpeed, RotationAmount;

    // Use this for initialization
    void Start ()
    {
        StoredBullet = Resources.Load("Prefabs/Test Prefabs/testbullet") as GameObject;
        //Instantiate(StoredBullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180));
        InvokeRepeating("CreateBullet", 0.5f, 0.05f);
        SetDefaults();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
    }

    void Movement()
    {
        Rotation();
        Spin();
    }

    private void Rotation()
    {
        TranslationVector = Quaternion.AngleAxis(Time.deltaTime * (MovementSpeed * 10), Vector3.forward) * TranslationVector;

        transform.position = FocalPoint + TranslationVector;
    }

    private void Spin()
    {
        transform.Rotate(0, 0, RotationAmount * Time.deltaTime * 30f);
    }

    private void Translation()
    {
        // To be implemented at some point.
    }

    void CreateBullet()
    {
        Instantiate(StoredBullet, transform.position, transform.rotation);
    }

    void SetDefaults()
    {
        MovementSpeed = 20.0f;
        RotationAmount = transform.rotation.z;
        FocalPoint = transform.parent.transform.position;
        TranslationVector = transform.position - FocalPoint;
    }
}