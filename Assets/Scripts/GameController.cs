using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject warriorPrefab;
    [SerializeField] private Button startButton;
    [SerializeField] private Transform[] team1Positions;
    [SerializeField] private Transform[] team2Positions;

    [SerializeField] private Sprite[] warriorSprites;

    private List<Warrior> team1;
    private List<Warrior> team2;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        CreateTeam(team1Positions, team1, Color.blue, "Blue");
        CreateTeam(team2Positions, team2, Color.red, "Red");
    }

    private void CreateTeam(Transform[] teamPositions, List<Warrior> team, Color color, string teamTag)
    {
        if (team != null)
        {
            for (int i = 0; i < team.Count; i++)
            {
                Destroy(team[i].gameObject);
            }
            team.Clear();
        }

        var warriorFactory = new WarriorFactory();
        var warriorAI = new WarriorAI();
        List<IWarriorStats> warriorsStats = new List<IWarriorStats>();
        
        warriorsStats.Add(new WarriorStats(100, 1, 3, 2));
        warriorsStats.Add(new WarriorStats(100, 2, 1, 3));
        warriorsStats.Add(new WarriorStats(100, 3, 2, 1));

        team = new List<Warrior>();

        for (int i = 0; i < teamPositions.Length; i++)
        {
            var warrior = warriorFactory.CreateWarrior(warriorPrefab, warriorsStats[i], warriorAI, warriorSprites[i]);
            warrior.transform.position = teamPositions[i].position;
            team.Add(warrior.GetComponent<Warrior>());
        }    
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(StartGame);
    }
}
