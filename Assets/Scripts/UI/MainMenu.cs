using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void Start_btn()
        {
            SceneManager.LoadScene("Main");
        }

        public void Exit_btn()
        {
            Application.Quit();
        }
    }
}
