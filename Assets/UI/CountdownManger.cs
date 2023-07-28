using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public WindowsFactory windowsFactory;
    public Text countdownText;
    public Text scoreText;
    public Text endScreen;

    private ScoreManager scoreManager;
    private float currentTime;

    public float startingTime = 15f; // The starting time value for the countdown

    private void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        endScreen.gameObject.SetActive(false);
        currentTime = startingTime;
        UpdateCountdownText();
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f; 
                windowsFactory.DestroyAllWindows();

                EndScreen();
            }

            UpdateCountdownText(); // Update the countdown text on the UI every frame
        }
    }

    private void UpdateCountdownText()
    {
        countdownText.text = "Time: " + currentTime.ToString("0");
    }

    private void EndScreen()
    {
        endScreen.gameObject.SetActive(true);
        endScreen.text = "You got:\n" + scoreManager.GetScore().ToString() + " points";
        countdownText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }
}
