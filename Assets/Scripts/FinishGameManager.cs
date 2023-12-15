using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishGameManager : MonoBehaviour
{
   public static FinishGameManager Instance;

   [SerializeField] private GameObject gameOverPanel;
   [SerializeField] private TextMeshProUGUI beerText;
   [SerializeField] private TextMeshProUGUI youLostText;   

   private void Awake()
   {
    Instance = this;
   }

   public void FinishGame()
   {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

        bool isNewHighscore = KMManager.Instance.CheckNewHighscore();
        if (isNewHighscore)
          youLostText.text = "New Highscore!";

        int beerDrankThisGame = PaulBeers.Instance.GetBeerGainedAndSaveBeer();
        beerText.text = "Beers: " + beerDrankThisGame;
   }

   public void RestartGame()
   {
      Time.timeScale = 1;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
