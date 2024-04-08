using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParticleManager : MonoBehaviour
{

    [SerializeField] protected SmokeParticle smoke;
    [SerializeField] protected ExplosionEffect explosion;
    [SerializeField] protected CorpseScript corpse;

    protected static CorpseScript[] corpseList = new CorpseScript[20];
    protected static int corpseCount;

    protected 
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<corpseList.Length; i++)
        {
            corpseList[i] = Instantiate(corpse, Vector2.zero, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void spawnCorpse(Vector3 position, float t, float s)
    {
        corpseList[corpseCount].spawn(position, t, s);
        corpseCount++;
        if (corpseCount >= corpseList.Length) corpseCount = 0;
    }
}
