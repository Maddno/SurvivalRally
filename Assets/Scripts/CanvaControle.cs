using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvaControle : MonoBehaviour
{
    [Header("Game Start")]
    [SerializeField] private int priorityAmount = 10;
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject gameCanvas;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverCanvas;

    [Header("Game Win")]
    [SerializeField] private GameObject gameWinCanvas;

    public static bool isPaused;

    private void Awake()
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        gameOverCanvas.SetActive(false);
        gameWinCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        virtualCamera.Priority -= priorityAmount;
        gameCanvas.SetActive(true);
        startCanvas.SetActive(false);
        isPaused = false;
    }

    public void GameOver()
    {
        gameCanvas.SetActive(false);
        StartCoroutine(WaitAndLoad(gameOverCanvas, 1.5f));
        if (gameOverCanvas.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }

    public void GameWin()
    {
        gameCanvas.SetActive(false);
        StartCoroutine(WaitAndLoad(gameWinCanvas, 1.5f));
        if(gameWinCanvas.activeInHierarchy)
        {
            Time.timeScale = 0f;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(GameObject canva, float delay)
    {
        yield return new WaitForSeconds(delay);
        canva.SetActive(true);
    }

}
