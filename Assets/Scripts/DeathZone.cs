using UnityEngine;

internal class DeathZone : MonoBehaviour
{
    public GameObject gameOver;

    void Start()
    {
        gameOver.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterView>())
        {
            other.gameObject.SetActive(false);
            gameOver.SetActive(true);
        }
    }
}
