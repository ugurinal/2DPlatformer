using UnityEngine;
using UnityEngine.UI;

namespace Platformer2D.UserInterface
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private GameObject _pauseText;

        private bool isGamePaused;

        private void Start()
        {
            isGamePaused = false;
            _pauseText.SetActive(false);

            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                _pauseButton.gameObject.SetActive(false);
            }
            else
            {
                _pauseButton.onClick.RemoveAllListeners();
                _pauseButton.onClick.AddListener(PauseButton);
            }
        }

        private void PauseButton()
        {
            if (isGamePaused)
            {
                isGamePaused = false;
                _pauseText.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                isGamePaused = true;
                _pauseText.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}