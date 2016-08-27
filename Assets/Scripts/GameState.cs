using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace LudumDare36 {
    public class GameState : MonoBehaviour {

        private Player player;

        private static GameState _instance = null;
        public static GameState Instance {
            get { return _instance; }
        }

        public void LoadScreen(GameScreen screen) {
            
            Camera.main.transform.SetParent(screen.transform, false);
            player.MoveToScreen(screen);
        }

        private void init() {
            player = FindObjectOfType<Player>();
        }
        #region Unity Callbacks
        public void Awake() {
            // if there's already a singleton, remove ourselves
            if (_instance != null) {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }

        public void Start() {
            init();
            SceneManager.sceneLoaded += (Scene s, LoadSceneMode m) => {
                init();
            };
        }
        #endregion
    }
}