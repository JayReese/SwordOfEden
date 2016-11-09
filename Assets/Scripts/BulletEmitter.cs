using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BulletEmitter : MonoBehaviour
{
    [SerializeField]
    GameObject StoredBullet;
    [SerializeField]
    Vector3 FocalPoint, TranslationVector;
    [SerializeField]
    float MovementSpeed,
        RotationAmount, RotationTime,
        Meme, RotCounter, RotationDirection,
        DegreeOfSeparation, NumberOfSpawners;
    const float MaxMeme = 360f;
    [SerializeField]
    List<Vector3> BulletOrientations;
    [SerializeField]
    List<GameObject> BulletPrefabs;


    void Awake()
    {
        StoredBullet = Resources.Load("Prefabs/Test Prefabs/testbullet") as GameObject;
        BulletOrientations = new List<Vector3>();
        //transform.Rotate(new Vector3(0, 0, 360f));

        CreateOrientations();
        BulletPrefabs = new List<GameObject>();
        CreateBullet();
    }

    // Use this for initialization
    void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Prefabs/Test Prefabs/testbullet") as Sprite;
        //Instantiate(StoredBullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180));
        //InvokeRepeating("CreateBullet", 0.5f, 0.05f);
        RotCounter = 7.0f;
        RotationDirection = 1;
        //SetDefaults();

        //foreach (Vector3 v in BulletOrientations)
        //    Debug.Log(v.z);

        Meme = 0;

        //TranslationVector = Quaternion.AngleAxis(20, Vector3.forward) * TranslationVector;
        //transform.position = FocalPoint + TranslationVector;
        //transform.Rotate(0, 0, transform.rotation.z + 25f);

        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Meme <= MaxMeme)
        //    Meme = Time.time * RotationTime;

        //if (RotCounter > 0)
        //    RotCounter -= Time.deltaTime * 2f;
        //else
        //    ChangeRot();
            

        Movement();
        //Debug.Log(string.Format("Clamp: {0}, Meme: {1}", Mathf.Clamp(Time.time * RotationTime, 0, 360), Meme));
        //transform.LookAt(transform.parent.transform);

    }

    private void ChangeRot()
    {
        RotCounter = 7.0f;
        RotationDirection *= -1;
    }

    void Movement()
    {
        //Rotation();
        //Spin();
    }

    private void Rotation()
    {
        MaintainOrientation();
        TranslationVector = Quaternion.AngleAxis(Time.deltaTime * (MovementSpeed * 10), Vector3.forward * RotationDirection) * TranslationVector;

        transform.position = FocalPoint + TranslationVector;
    }

    private void Spin()
    {
        //transform.Rotate(0, 0, transform.rotation.z + Meme);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + Time.deltaTime * 10f);
    }

    private void Translation()
    {
        // To be implemented at some point.
    }

    private void MaintainOrientation()
    {
        Vector3 dir = transform.parent.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    void CreateBullet()
    {
        int count = 1;

        for(int i = 0; i < (int)Math.Pow(NumberOfSpawners, 3); i++)
        {
            GameObject o = Instantiate(StoredBullet);
            o.transform.parent = transform;
            o.SetActive(false);
            o.transform.eulerAngles = BulletOrientations[count - 1];
            Debug.Log(count);
            //BulletPrefabs.Add(o);

            if (count < NumberOfSpawners)
                count++;
            else
                count = 1;
        }
    }

    void SetDefaults()
    {
        MovementSpeed = 15f;
        RotationTime = 30f;
        RotationAmount = transform.rotation.z;
        FocalPoint = transform.parent.transform.position;
        TranslationVector = transform.position - FocalPoint;
    }

    void CreateOrientations()
    {
        DegreeOfSeparation = 180;
        NumberOfSpawners = 4;
        float newsep = DegreeOfSeparation / NumberOfSpawners;

        for (int i = 1; i < NumberOfSpawners + 1; i++)
            BulletOrientations.Add(new Vector3(0, 0, (newsep * i) - newsep));
    }
}