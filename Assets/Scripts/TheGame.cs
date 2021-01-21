using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGame : MonoBehaviour
{
    public bool WoodQuestDone = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        if (WoodQuestDone)
        {
            GameObject[] Woodies = GameObject.FindGameObjectsWithTag("Woodman");
            foreach(GameObject woodie in Woodies)
            {
                Destroy(woodie);
            }
            GameObject[] WoodiesActive = GameObject.FindGameObjectsWithTag("WoodmanActive");
            foreach(GameObject actwoodie in WoodiesActive)
            {
                actwoodie.GetComponent<BoxCollider2D>().enabled = true;
                actwoodie.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
