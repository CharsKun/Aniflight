using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour
{
    public GameObject minionPrefab;
    public GameObject GameManager;
    public float respawnTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnMinion()
    {
        GameObject a = Instantiate(minionPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-3.5f, 3.5f), 1);
    }
    IEnumerator startWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnMinion();
            
        }
    }
}
