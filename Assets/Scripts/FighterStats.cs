using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FighterStats : MonoBehaviour, IComparable
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject healthFill;
    [SerializeField]
    private GameObject magicFill;

    [Header("Stats")]
    public float health;
    public float magic;
    public float melee;
    public float range;
    public float defense;
    public float speed;
    public float experience;

    private float startHealth;
    private float startMagic;

    [HideInInspector]
    public int nextActTurn;

    private bool isDead = false;

    // Resize health and magic bar
    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    private void Start()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        magicTransform = magicFill.GetComponent<RectTransform>();
        magicScale = magicFill.transform.localScale;

        startHealth = health;
        startMagic = magic;
    }

    public void ReceiveDamage(float damage)
    {
        health -= damage;
        anim.Play("Damage");

        // Set damage text

        if (health <= 0)
        {
            isDead = true;
            gameObject.tag = "Dead";
            Destroy(healthFill);
            Destroy(gameObject);
        } else
        {
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }
    }

    public void UpdateMagicFill(float cost)
    {
        magic -= cost;
        xNewMagicScale = magicScale.x * (magic / startMagic);
        magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
    }

    public int CompareTo(object otherStats)
    {
        int nex = nextActTurn.CompareTo(((FighterStats)otherStats).nextActTurn);
        return nex;
    }
}
