 using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Emitters;
    [SerializeField] public byte NumberOfEmitters { get; private set; }
    [SerializeField] public byte PatternNumber { get; private set; }

    [SerializeField] List<BulletPattern> BulletPatterns;
    [SerializeField] List<GameObject> BulletPrefabs;

    void Awake()
    {
        SetDefaults();
    }

    // Use this for initialization
    void Start ()
    {
        //Emitter = transform.GetChild(0).GetComponent<BulletEmitter>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.GetChild(1).position += -transform.up;
	}

    void CreateEmitters()
    {
        GameObject o = Resources.Load("Prefabs/Bullet Emitter") as GameObject;

        o.transform.localPosition = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        //o.transform.localEulerAngles = new Vector3(transform.rotation.x + 154, transform.rotation.y + 10);

        for (int i = 0; i < NumberOfEmitters; i++)
        {
            //Emitters.Add(o);
            Instantiate(o, transform);
            
        }
    }

    void SetDefaults()
    {
        Emitters = new List<GameObject>();
        NumberOfEmitters = 3;

        PatternNumber = Convert.ToByte(DatabaseManager.ReturnQueriedData(DataQueryType.Enemies, gameObject.name, "PatternCount"));
        BulletPatterns = new List<BulletPattern>();

        CreateBulletPatterns();
        Debug.Log(BulletPatterns.Count);
        BulletPatterns[1].Give();
        CreateEmitters();
    }

    void CreateBulletPatterns()
    {
        for (int i = 0; i < PatternNumber; i++)
            BulletPatterns.Add(new BulletPattern(i + 1, gameObject.name));
    }
}
