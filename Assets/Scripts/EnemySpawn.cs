using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{   [SerializeField]
    private GameObject enemy; 
    [SerializeField]
    private float spawnInterval =3.5f; 
    [SerializeField]
    private int maxEnemy = 3; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval,enemy));
        
    }

  private IEnumerator spawnEnemy (float interval, GameObject monster)
  { maxEnemy--;
    yield return new WaitForSeconds(interval);
    GameObject newEnemy = Instantiate(monster, new Vector3(Random.Range(-5f,5), Random.Range(-6f, 6f),0),Quaternion.identity );
    if(maxEnemy >0)
    StartCoroutine(spawnEnemy(interval,enemy));
  }
}
