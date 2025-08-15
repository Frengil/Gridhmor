using UnityEngine;

public class LevelController : MonoBehaviour
{

    public static LevelController instance;
    public int levelDifficulty { private set; get; }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void startLevel(int difficulty)
    {
        this.levelDifficulty = difficulty;
    }
}
