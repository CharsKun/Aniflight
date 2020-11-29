using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boss1;
    public int count = 0;
    public int maxCount = 0;
    public GameObject minionPrefab;
    public float respawnTime = 1f;
    private GameObject boss;
    public GameObject Victory;
    public int randomMinion;

    void Start()
    {
        boss = Instantiate(Boss1);
        boss.transform.position = new Vector2(-0.02423012f, -1.798349f);
        boss.SetActive(false);

        count = 0;
        StartCoroutine(startWave());
    }

    // Update is called once per frame
    void Update()
    {
        if (count == maxCount)
        {
            boss.SetActive(true);
        }

        if(boss.GetComponent<MovementBoss>().Health <= 0)
        {
            Victory.SetActive(true);
        }
    }
    private void spawnMinion()
    {
        GameObject a = Instantiate(minionPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-3.5f, 3.5f), 1);
        a.GetComponent<Minion>().ManagerGame = this.gameObject;
        randomMinion = Random.Range(1, 3);
    }
    IEnumerator startWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            if (count < maxCount)
            {
                spawnMinion();
            }
        }
    }
}
