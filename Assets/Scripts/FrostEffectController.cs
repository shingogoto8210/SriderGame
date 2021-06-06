using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostEffectController : MonoBehaviour
{
    private FrostEffect frostEffect;
    void Start()
    {
        frostEffect = GetComponent<FrostEffect>();
        frostEffect.FrostAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(frostEffect.FrostAmount >= 0)
        {
            frostEffect.FrostAmount -= Time.deltaTime/20;
        }
        if (frostEffect.FrostAmount <= 0)
        {
            frostEffect.FrostAmount = 0;
        }
    }

    public void AddFrostAmount(float amount)
    {
        frostEffect.FrostAmount += amount;
    }
}
