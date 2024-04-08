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

    protected 
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<corpseList1.Length; i++)
        {
            corpseList1[i] = Instantiate(corpse1, Vector2.zero, Quaternion.identity);
        }

        for (int i = 0; i < corpseList2.Length; i++)
        {
            corpseList2[i] = Instantiate(corpse2, Vector2.zero, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void spawnCorpse(Vector3 position, float t, float s)
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
}
