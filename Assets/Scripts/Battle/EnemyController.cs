using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy[] enemyPrefabs;

    public void createEnemy(int id)
    {
        int difficulty = LevelController.instance.levelDifficulty;
        int enemyId = 0;
        Vector3 position = new Vector3(Random.Range(-13f, 13f), Random.Range(-13f, 13f), 0);

        Enemy enemyGo = Instantiate(enemyPrefabs[enemyId], position, Quaternion.identity);


        enemyGo.setDifficultyOfEnemy(difficulty);
    }

    void Start()
    {
        createEnemy(0);
        createEnemy(0);
        createEnemy(0);
    }

    void Update()
    {

    }
}
