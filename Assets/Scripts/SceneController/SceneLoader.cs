using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2D.Utility
{
    public class SceneLoader : MonoBehaviour
    {
        public void ChangeScene()
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;

            if (buildIndex == 0)
                SceneManager.LoadScene(1);
            else
                SceneManager.LoadScene(0);
        }
    }
}