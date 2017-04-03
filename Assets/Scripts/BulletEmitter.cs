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
    
    
    void Awake()
    {
        //Debug.Log(CameraExtensions.OrthographicBounds(Camera.main));

        StoredBullet = Resources.Load("Prefabs/Test Prefabs/testbullet") as GameObject;
        //BulletOrientations = new List<Vector3>();
        //transform.Rotate(new Vector3(0, 0, 360f));

        //CreateOrientations();
        //ExtraBulletPrefabCount = 40;
        //PrefabCountIndexOffset = ExtraBulletPrefabCount;
        //BulletPrefabs = new List<GameObject>();
        //CreateBullet();

        


        SetDefaults();

        //Debug.Log(DatabaseManager.ReturnQueriedData(DataQueryType.Enemies, transform.parent.gameObject.name, "Strength", "Stats"));

        
    }

    // Use this for initialization
    void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Prefabs/Test Prefabs/testbullet") as Sprite;
        //Instantiate(StoredBullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180));
        //InvokeRepeating("SpawnBullet", 0.5f, 0.03f);
        //RotCounter = 7.0f;
        //RotationDirection = 1;
        //SetDefaults();

        //foreach (Vector3 v in BulletOrientations)
        //    Debug.Log(v.z);

        //Meme = 0;

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

    //private void ChangeRot()
    //{
    //    RotCounter = 7.0f;
    //    RotationDirection *= -1;
    //}

    void Movement()
    {
        //Rotation();
        //Spin();
    }


    // Spawns the bullet.
    void SpawnBullet()
    {
        //transform.GetChild(BulletPrefabCount - PrefabCountIndexOffset).gameObject.SetActive(true);
        //PrefabCountIndexOffset--;
    }

    //private void Rotation()
    //{
    //    MaintainOrientation();
    //    TranslationVector = Quaternion.AngleAxis(Time.deltaTime * (MovementSpeed * 10), Vector3.forward * RotationDirection) * TranslationVector;

    //    transform.position = FocalPoint + TranslationVector;
    //}

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
        //int count = 1;

        //for(int i = 0; i < ExtraBulletPrefabCount; i++)
        //{
        //    GameObject o = Instantiate(StoredBullet);
        //    o.transform.parent = transform;
        //    o.SetActive(false);
        //    //o.transform.eulerAngles = BulletOrientations[count - 1];
        //    //o.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + BulletOrientations[count - 1].z));
        //    //Debug.Log(count);
        //    //BulletPrefabs.Add(o);

        //    //if (count < NumberOfSpawners)
        //    //    count++;
        //    //else
        //    //    count = 1;
        //}

    }

    void SetDefaults()
    {
        
    }

    void CreateOrientations()
    {
        //DegreeOfSeparation = 360;
        //NumberOfSpawners = 2;
        //float newsep = DegreeOfSeparation / NumberOfSpawners;

        //for (int i = 1; i < NumberOfSpawners + 1; i++)
        //    BulletOrientations.Add(new Vector3(0, 0, (newsep * i) - newsep));
    }

    public void AddBackToIndex()
    {
        //PrefabCountIndexOffset++;
    }
}