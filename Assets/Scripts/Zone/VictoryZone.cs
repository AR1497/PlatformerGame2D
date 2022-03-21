using UnityEngine;

internal class VictoryZone : MonoBehaviour
{
    [SerializeField]
    private GameObject gameVictory;

    void Start()
    {
        gameVictory.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterView>())
        {
            other.gameObject.SetActive(false);
            gameVictory.SetActive(true);
        }
    }
}
