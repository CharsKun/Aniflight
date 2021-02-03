using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Linq;

public class StageController : MonoBehaviour
{
    public static StageController current;
    public Transform[] waypointGroups;

    private List<List<Vector2>> paths;
    private int pathCount;

    private bool bossSpawned = false;
    public GameObject boss;
    private GameObject a;
    public GameObject Victory;
    public GameObject Defeat;
    public GameObject hb,mb;
    public GameObject PauseButton;

    [Serializable]
    public struct MinionSpawnData
    {
        public GameObject minion;
        public float delay;
        public int amount;
        public float interval;
        public int waypointIndex;
    }

    [Serializable]
    public struct WaveData
    {
        public MinionSpawnData[] spawns;
        public float time;
    }

    public int WaveIndex { get; private set; }
    private float currentWaveTime;

    private float ItsTime=0f;
    private float ZaTime=3f;

    private float respawnTime = 1f;  
    private int count = 0 ;
    private float time;

    public float WaveProgress { get; private set; }

    public WaveData[] waves;

    private bool hehe=false;

    private int spawnCount;
    private float spawnTimer;

    public StageController()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        count = 0;
        //StartCoroutine(startWave());

        paths = new List<List<Vector2>>();

        foreach (var group in waypointGroups)
        {
            var path = new List<Vector2>();

            path.Add(group.position);
            int childCount = group.childCount;
            for (int i = 0; i < childCount; ++i)
            {
                var child = group.GetChild(i);
                path.Add(child.position);
            }

            paths.Add(path);
        }
        pathCount = paths.Count;
    }

    public List<Vector2> GetPath(int index)
    {
        if (index < 0 || index >= pathCount) return null;
        return paths[index];
    }

    private int GetWaveSpawnIndex(float time, MinionSpawnData data)
    {
        return (int)((time - data.delay)/data.interval);
    }

    public float SecondsToBeats(float seconds)
    {
        return seconds * 120f / 60;
    }


    // Update is called once per frame
    void Update()
    {  
        time += Time.deltaTime;
        currentWaveTime +=  SecondsToBeats(Time.deltaTime);
        
        if (WaveIndex < waves.Length)
        {
            var wave = waves[WaveIndex];
            float spawnEndTime = 0;
            
            foreach (var spawnData in wave.spawns)
            {
                spawnEndTime = Mathf.Max(spawnEndTime, spawnData.delay + (spawnData.interval * (spawnData.amount - 1)));
                spawnTimer += Time.deltaTime;
                if (spawnTimer-spawnData.delay>spawnData.interval && spawnCount < spawnData.amount)
                {
                    var e = Instantiate(spawnData.minion, waypointGroups[spawnData.waypointIndex].transform.position, Quaternion.identity);
                    e.GetComponent<MinionController>().pathIndex = spawnData.waypointIndex;
                    spawnCount++;
                    spawnTimer = 0;
                }
            }

            bool hasEnemy = FindObjectOfType<MinionController>() != null;
            
            if (WaveIndex < waves.Length - 1)
            {
                if (currentWaveTime >= spawnEndTime && !hasEnemy && currentWaveTime < waves[WaveIndex].time)
                {
                    currentWaveTime = waves[WaveIndex].time;
                }

                if (currentWaveTime >= waves[WaveIndex].time + 10f)
                {
                    WaveIndex++;
                    currentWaveTime = 0;
                    spawnCount = 0;
                }

                if (currentWaveTime <= waves[WaveIndex].time)
                {
                    WaveProgress = currentWaveTime / waves[WaveIndex].time;
                }
                else
                {
                    WaveProgress = 1f + ((currentWaveTime - waves[WaveIndex].time) / 10f);
                }
            }
            else
            {
                WaveProgress = currentWaveTime / spawnEndTime;
                /*if (WaveProgress > 1f)
                {
                    WaveProgress = 1f;
                    
                }*/

                if (bossSpawned == false && ItsTime >= ZaTime)
                {
                    a = Instantiate(boss) as GameObject;
                    a.transform.position = new Vector2(-0.02423012f, -1.798349f);
                    bossSpawned = true;
                }
                else if (bossSpawned == false && ItsTime < ZaTime)
                {
                    ItsTime += Time.deltaTime;
                }
                else 
                {
                    if (!hehe)
                    {
                        if (a.GetComponent<MovementBoss>().Health <= 0)
                        {
                            if (a.GetComponent<MovementBoss>().IDboss == 1)
                            {
                                Debug.Log("Boss1 mampud");
                                PlayerPrefs.SetInt("Stage2", 1);
                            }

                            if (a.GetComponent<MovementBoss>().IDboss == 2)
                            {
                                PlayerPrefs.SetInt("Stage3", 1);
                                PlayerPrefs.SetInt("Archer", 1);
                            }

                            if (a.GetComponent<MovementBoss>().IDboss == 3)
                            {
                                PlayerPrefs.SetInt("Stage4", 1);
                                PlayerPrefs.SetInt("Mage", 1);
                            }

                            if (a.GetComponent<MovementBoss>().IDboss == 4)
                            {
                                PlayerPrefs.SetInt("Stage5", 1);
                            }

                            Defeat.SetActive(false);
                            Victory.SetActive(true);
                            PauseButton.SetActive(false);
                            hehe = true;
                            Destroy(hb.gameObject);
                            Destroy(mb.gameObject);
                        }
                    }
                }



                /*if (currentWaveTime >= spawnEndTime && !hasEnemy)
                {
                    WaveIndex++;
                    currentWaveTime = 0;
                    spawnCount = 0;
                }*/
            } 
        }

        

    }
}
