using UnityEngine;
using System.Collections;

namespace LudumDare36 {
    public class ScreenChanger : MonoBehaviour {
        public GameScreen screen;

        public void Start() {
        }
        public void OnTriggerEnter2D(Collider2D other) {
            GameState.Instance.LoadScreen(screen);
        }
    }
}