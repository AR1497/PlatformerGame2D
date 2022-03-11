using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoneyText.Coin += 1;
            Destroy(gameObject);
        }
    }
}
