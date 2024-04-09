using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParticleManager : MonoBehaviour
{

    [SerializeField] protected SmokeParticle smoke;
    [SerializeField] protected ExplosionEffect explosion;
    [SerializeField] protected CorpseScript corpse1, corpse2;

    protected static CorpseScript[] corpseList1 = new CorpseScript[20];
    protected static CorpseScript[] corpseList2 = new CorpseScript[20];
    protected static int corpseCount1, corpseCount2;

    protected static ExplosionEffect[] explodeList = new ExplosionEffect[10];
    protected static int explodeCount;

    protected static SmokeParticle[] smokeList = new SmokeParticle[40];
    protected static int smokeCount;

    private void Awake()
    {
        InstantiateCorpses();
        InstantiateExplosions();
        InstantiateSmoke();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SpawnCorpse(Vector3 position, float t, float s)
    {
        if(Random.value<0.5f)
        {
            corpseList1[corpseCount1].spawn(position, t, s);
            corpseCount1++;
            if (corpseCount1 >= corpseList1.Length) corpseCount1 = 0;
        } else
        {
            corpseList2[corpseCount2].spawn(position, t, s);
            corpseCount2++;
            if (corpseCount2 >= corpseList2.Length) corpseCount2 = 0;
        }
        
    }

    public static void SpawnExplosion(Vector3 position, float t, float s)
    {
        explodeList[explodeCount].spawn(position, t, s);
        explodeCount++;
        if (explodeCount >= explodeList.Length) explodeCount = 0;
    }

    public static void SpawnSmoke(Vector3 position, float t, float s)
    {
        smokeList[smokeCount].spawn(position, t, s);
        smokeCount++;
        if (smokeCount >= smokeList.Length) smokeCount = 0;
    }

    public void InstantiateCorpses()
    {
        for (int i = 0; i < corpseList1.Length; i++)
        {
            corpseList1[i] = Instantiate(corpse1, Vector2.zero, Quaternion.identity);
        }

        for (int i = 0; i < corpseList2.Length; i++)
        {
            corpseList2[i] = Instantiate(corpse2, Vector2.zero, Quaternion.identity);
        }
    }

    public void InstantiateExplosions()
    {
        for(int i = 0; i < explodeList.Length; i++)
        {
            explodeList[i] = Instantiate(explosion, Vector2.zero, Quaternion.identity);
        }
    }

    public void InstantiateSmoke()
    {
        for(int i = 0;i < smokeList.Length; i++)
        {
            smokeList[i] = Instantiate(smoke, Vector2.zero, Quaternion.identity);
        }
    }
}
