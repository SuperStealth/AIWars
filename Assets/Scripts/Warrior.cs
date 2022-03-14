using UnityEngine;

namespace AIWars
{
    public class Warrior : MonoBehaviour
    {
        public IWarriorStats WarriorStats { get; private set; }

        private GameObject[] enemies;
        private GameObject currentEnemyGameObject;
        private Warrior currentEnemy;

        private void OnEnable()
        {
            if (gameObject.tag == "Red")
            {
                enemies = GameObject.FindGameObjectsWithTag("Blue");
            }
            else
            {
                enemies = GameObject.FindGameObjectsWithTag("Red");
            }
        }

        private void Update()
        {
            if (WarriorStats.Health < 0)
            {
                Destroy(gameObject);
            }
            if (currentEnemyGameObject == null)
            {
                currentEnemyGameObject = GetClosestEnemy();
                currentEnemy = currentEnemyGameObject.GetComponent<Warrior>();
            }
            if (Vector2.Distance(currentEnemy.transform.position, transform.position) > WarriorStats.Radius)
            {
                GoToEnemy();
            }
            else
            {
                Attack();
            }
        }

        private void GoToEnemy()
        {
            var heading = currentEnemy.transform.position - transform.position;
            var direction = heading / heading.magnitude;
            var movement = direction * WarriorStats.Speed * Time.deltaTime;
            transform.position = transform.position + movement;
        }

        private void Attack()
        {
            currentEnemy.WarriorStats.GetDamage(WarriorStats.Attack * Time.deltaTime);
        }

        private GameObject GetClosestEnemy()
        {
            GameObject enemy = null;
            float minDistance = float.MaxValue;

            for (int i = 0; i < enemies.Length; i++)
            {
                var distance = Vector2.Distance(enemies[i].transform.position, transform.position);
                if (distance < minDistance)
                {
                    enemy = enemies[i];
                    minDistance = distance;
                }
            }

            if (enemy == null)
            {
                return null;
            }
            else
            {
                return enemy;
            }
        }

        public void SetStats(IWarriorStats warriorStats)
        {
            WarriorStats = warriorStats;
        }

        public void Remove()
        {
            Destroy(gameObject);
        }
    }
}