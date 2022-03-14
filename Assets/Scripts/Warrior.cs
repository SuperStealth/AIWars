using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public IWarriorStats WarriorStats { get; private set; }

    public IWarriorAI WarriorAI { get; private set; }

    void Start()
    {
        WarriorAI.StartFight();
    }

    public void SetStats(IWarriorStats warriorStats)
    {
        WarriorStats = warriorStats;
    }

    public void SetAI(IWarriorAI warriorAI)
    {
        WarriorAI = warriorAI;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
