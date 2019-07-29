using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    [SerializeField] public Dictionary<string, Graph> spells;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spell manager started!");       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
