using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGame : MonoBehaviour
{
    public Camera mainCam;
    public Camera figthCam;
    public bool figthModeEnabled = false;
    public bool WoodQuestDone = false;
    void Start()
    {
        mainCam.enabled = true;
        figthCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        if (WoodQuestDone)
        {
            GameObject[] Woodies = GameObject.FindGameObjectsWithTag("Woodman");
            foreach (GameObject woodie in Woodies)
            {
                Destroy(woodie);
            }
            GameObject[] WoodiesActive = GameObject.FindGameObjectsWithTag("WoodmanActive");
            foreach (GameObject actwoodie in WoodiesActive)
            {
                actwoodie.GetComponent<BoxCollider2D>().enabled = true;
                actwoodie.GetComponent<Renderer>().enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCam.enabled = false;
            figthCam.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            mainCam.enabled = true;
            figthCam.enabled = false;
        }
    }
}
