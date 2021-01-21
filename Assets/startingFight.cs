using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingFight : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject theplayer;
    public float distance;
    public TheGame gameStatus;
    public BattleSystem battleSystem;

    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, theplayer.transform.position);
        if (distance <= 2f)
        {
            gameStatus.enableFightMode();
            battleSystem.StartBatte(myPrefab);
            gameObject.SetActive(false);
        }
    }
}
