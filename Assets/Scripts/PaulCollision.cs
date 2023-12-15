using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Entity"))
        {
            switch (collision.GetComponent<EntityType>().entityType)
            {
                case EntityType.EntityTypes.elixir:
                    //add score
                    PaulBeers.Instance.AddBeer(1);
                    Destroy(collision.gameObject);
                    break;
                
                case EntityType.EntityTypes.elixir2:
                    //add score
                    PaulBeers.Instance.AddBeer(1);
                    Destroy(collision.gameObject);
                    break;

                case EntityType.EntityTypes.roadkill:
                    //lose
                    //Destroy(collision.gameObject);
                    //PaulBeers.Instance.RemoveLife(1); => should remove 1 heart (of 3), if hearts == 0, then FinishGameManager.Instance.FinishGame();
                    if (PaulLife.Instance.GetLives() == 1)
                        FinishGameManager.Instance.FinishGame();
                    Destroy(collision.gameObject);
                    PaulLife.Instance.RemoveLife();
                    break;
            }
        }
    }
}
