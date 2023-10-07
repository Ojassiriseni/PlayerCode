using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spongy : MonoBehaviour
{
    public float speed = 3.0f;
    public int lives = 3;
    public int score = 0;
    public Text scoreText;
    public Text timeText;
    public Text livesText;
    GameObject[] grimeObjects;
    GameObject[] acidObjects;
    GameObject[] collectableObjects;
    GameObject[] hazardObjects;
    public Grime grimePrefab;
    public Acid acidPrefab;
    public Collectable collectablePrefab;
    public Hazard hazardPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ObjectSpawn", 0, Random.Range(1.0f, 3.0f));

    }
    void ObjectSpawn()
    {
        int Ran = Random.Range(1, 7);
        if (Ran >= 2)
        {
            grimePrefab.SpawnGrime();
        }
        if (Ran >= 5)
        {
            acidPrefab.SpawnAcid();
        }
        if (Ran == 6)
        {
            collectablePrefab.SpawnCollectable();
        }
        if (Ran == 7 || Ran == 1)
        {
            hazardPrefab.SpawnHazard();
        }


    }
    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        timeText.text = Time.time.ToString("f1");
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
    }
    void MoveCharacter()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    void RemoveGrime()
    {
        grimeObjects = GameObject.FindGameObjectsWithTag("Grime");

        for (var i = 0; i < grimeObjects.Length; i++)
        {
            Destroy(grimeObjects[i]);
        }
    }
    void RemoveAcid()
    {
        acidObjects = GameObject.FindGameObjectsWithTag("Acid");

        for (var i = 0; i < acidObjects.Length; i++)
        {
            Destroy(acidObjects[i]);
        }
    }
    void RemoveCollectable()
    {
        collectableObjects = GameObject.FindGameObjectsWithTag("Collectable");

        for (var i = 0; i < collectableObjects.Length; i++)
        {
            Destroy(collectableObjects[i]);
        }
    }
    void RemoveHazard()
    {
        hazardObjects = GameObject.FindGameObjectsWithTag("Hazard");

        for (var i = 0; i < hazardObjects.Length; i++)
        {
            Destroy(hazardObjects[i]);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Acid(Clone)")
        {
            lives = lives - 1;
            Destroy(collision.gameObject);

            if (lives == 0)
            {
                RemoveAcid();
                RemoveGrime();
                RemoveCollectable();
                RemoveHazard();
                Time.timeScale = 0;
            }
        }
        if (collision.gameObject.name == "Hazard(Clone)")
        {
            lives = lives - 1;
            Destroy(collision.gameObject);

            if (lives == 0)
            {
                RemoveAcid();
                RemoveGrime();
                RemoveCollectable();
                RemoveHazard();
                Time.timeScale = 0;
            }
        }
        if (collision.gameObject.name == "Grime(Clone)")
        {
            score = score + 50;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Collectable(Clone)")
        {
            score = score + 50;
            Destroy(collision.gameObject);
        }
    }
}
