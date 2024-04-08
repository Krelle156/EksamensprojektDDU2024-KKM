using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseScript : MonoBehaviour
{
    float timer = 0, startTime = 1;
    Vector3 startSize;
    SpriteRenderer sprite;

    void Start()
    {
        startSize = Vector3.one;
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1, 1, 1, 0);
    }

    public void spawn(Vector3 position, float t, float s)
    {
        startTime = t;
        timer = t;

        startSize = new Vector3(s, s, s);
        transform.position = position;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        sprite.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
