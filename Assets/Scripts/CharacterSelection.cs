using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject Knight;
    public GameObject Archer;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Character") == 1)
        {
            Knight.SetActive(true);
        }
        else
        {
            Archer.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
