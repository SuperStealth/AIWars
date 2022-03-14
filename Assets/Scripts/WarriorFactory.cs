using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorFactory
{
    public GameObject CreateWarrior(GameObject warrior, IWarriorStats stats, IWarriorAI aI, Sprite sprite)
    {
        var newWarrior = GameObject.Instantiate(warrior);
        newWarrior.GetComponent<SpriteRenderer>().sprite = sprite;
        var warriorComponent = newWarrior.AddComponent<Warrior>();
        warriorComponent.SetStats(stats);
        warriorComponent.SetAI(aI);
        return newWarrior;
    }
}
