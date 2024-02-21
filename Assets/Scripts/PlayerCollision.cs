using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PLAYER COLLISION!");
        if (other.gameObject.name.StartsWith("Barrel"))
        {
            Debug.Log("GAME OVER!");
            GameOver();
        }
    }

    void GameOver()
    {
        PlayerLevelManager.Instance.ResetPlayer();
        SceneManager.LoadScene("Title");
    }
}
