using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject hero;

    [SerializeField]
    private GameObject meleePrefab;

    [SerializeField]
    private GameObject magicPrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;

    void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void SelectAttack(string btn)
    {
        GameObject victim = hero;
        if(tag == "Hero")
        {
            victim = enemy;
        }
        if (btn.CompareTo("Melee") == 0)
        {
            meleePrefab.GetComponent<AttackScript>().Attack(victim);
        } else if (btn.CompareTo("Magic") == 0)
        {
            magicPrefab.GetComponent<AttackScript>().Attack(victim);
        } else
        {
            Debug.Log("Run");
        }
    }
}
