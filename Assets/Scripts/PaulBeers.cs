using UnityEngine;

public class PaulBeers : MonoBehaviour
{
    public static PaulBeers Instance;
    [SerializeField] private int currentBeer;
    public const string prefBeers = "prefBeers";

    public void Awake()
    {
        Instance = this;

        currentBeer = PlayerPrefs.GetInt(prefBeers);
    }

    public void AddBeer(int beerToAdd)
    {
        currentBeer += beerToAdd;
    }

    public int GetBeerGainedAndSaveBeer()
    {
        int beerDrankThisGame = currentBeer - PlayerPrefs.GetInt(prefBeers);
        PlayerPrefs.SetInt(prefBeers, currentBeer);

        return beerDrankThisGame;
    }
}