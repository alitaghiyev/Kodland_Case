using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text HpText;

    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject Victory;

    private int _enemyCount = 0;
    #region Singleton
    public static GameManager i;
    private void Awake()
    {
        i = this;
    }
    #endregion

    void Start()
    {
        GetEnemyCount();
    }
    public void Win()
    {
        Victory.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        GameTimeControl(0);
    }

    public void Lost()
    {
        GameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        GameTimeControl(0);
    }

    public void SetHealthText(float currentHealth)
    {
        HpText.text = currentHealth.ToString();
    }

    private void GetEnemyCount()
    {
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void SetEnemyCount()
    {
        if (_enemyCount > 1)
        {
            _enemyCount--;
            //_enemyCount = _enemyCount - 1;
        }
        else
        {
            Win();
        }
    }
    public void GameTimeControl(int currentTime)
    {
        Time.timeScale = currentTime;
    }
}
