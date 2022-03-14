using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AIWars
{
    public class WarriorFactory
    {
        public GameObject CreateWarrior(GameObject warrior, IWarriorStats stats, Sprite sprite)
        {
            var newWarrior = GameObject.Instantiate(warrior);
            newWarrior.GetComponent<SpriteRenderer>().sprite = sprite;
            var warriorComponent = newWarrior.AddComponent<Warrior>();
            warriorComponent.SetStats(stats);
            return newWarrior;
        }
    }
}

