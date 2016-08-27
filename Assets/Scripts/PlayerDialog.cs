using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class PlayerDialog : MonoBehaviour {

    public GameObject panel;
    public Text text;

    public void ShowDialog(Investigatable obj) {
        panel.SetActive(true);
        text.text = obj.text;
    }
    public void HideDialog() {
        panel.SetActive(false);
    }
}
