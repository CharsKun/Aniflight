using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{
    public Image Archer;
    public Button ArcherInteract;
    public Image Mage;
    public Button MageInteract;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Archer") >= 1)
        {
            Archer.GetComponent<Image>().color = new Color(1, 1, 1);
            ArcherInteract.GetComponent<Button>().interactable = true;
        }

        if(PlayerPrefs.GetInt("Mage") >= 1)
        {
            Mage.GetComponent<Image>().color = new Color(1, 1, 1);
            MageInteract.GetComponent<Button>().interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
