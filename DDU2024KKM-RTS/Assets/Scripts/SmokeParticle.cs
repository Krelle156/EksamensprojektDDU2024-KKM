using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeParticle : MonoBehaviour
{
    float timer = 0, startTime = 1;
    Vector3 startSize;
    SpriteRenderer sprite;

    public Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        startSize = Vector3.one;
        sprite = GetComponent<SpriteRenderer>();
    }

    public void spawn(Vector3 position, float t, float s)
    {
        startTime = t;
        timer = t;

        startSize = new Vector3(s,s,s);
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>=0)timer -= 1f * Time.deltaTime;
        transform.position += velocity;
        sprite.color = new Color(1,1,1,timer/startTime);

        Debug.Log(startSize);
        transform.localScale = startSize * (2 - (timer / startTime));
    }
}
