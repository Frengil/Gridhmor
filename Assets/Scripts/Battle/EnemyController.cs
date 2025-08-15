using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy[] enemyPrefabs;

    public void createSingleEnemy(int id, Vector2 startingPosition)
    {
        int difficulty = LevelController.instance.levelDifficulty;


        Enemy enemyGo = Instantiate(enemyPrefabs[id], startingPosition, Quaternion.identity);


        enemyGo.setDifficultyOfEnemy(difficulty);
    }

    public void createEnemyGroup(int amount)
    {
        Vector2 position = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        for (int i = 0; i < amount; i++)
        {
            Vector2 startingPosVariance = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            createSingleEnemy(0, position + startingPosVariance);
        }
    }

    void Start()
    {
        createEnemyGroup(5);
        createEnemyGroup(5);
        createEnemyGroup(5);
    }

    void Update()
    {

    }
}
