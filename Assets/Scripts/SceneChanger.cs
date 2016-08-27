using UnityEngine;
using System.Collections;

namespace LudumDare36 {
    public class SceneChanger : MonoBehaviour {
        public string scene;

        public void OnTriggerEnter2D(Collider2D other) {
            Debug.Log("+++ Entered by " + other.name);
        }
    }
}