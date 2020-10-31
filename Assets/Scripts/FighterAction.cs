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
    private GameObject meleeAttack;
    private GameObject magicAttack;

    public void SelectAttack(string btn)
    {
        GameObject victim = hero;
        if(tag == "Hero")
        {
            victim = enemy;
        }
        if (btn.CompareTo("melee") == 0)
        {
            currentAttack = meleeAttack;
            meleeAttack.GetComponent<AttackScript>().Attack(victim);
        } else if (btn.CompareTo("magic") == 0)
        {
            currentAttack = magicAttack;
            magicAttack.GetComponent<AttackScript>().Attack(victim);
        } else
        {
            Debug.Log("Run");
        }
    }
}
