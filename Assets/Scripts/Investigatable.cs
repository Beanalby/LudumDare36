using UnityEngine;
using System.Collections;

public class Investigatable : MonoBehaviour {
    public string text;

    public GameObject CanInvestigatePrefab;
    private GameObject canInvestigateObj = null;
    
    public void OnTriggerEnter2D(Collider2D other) {
        canInvestigateObj = Instantiate(CanInvestigatePrefab);
        canInvestigateObj.transform.SetParent(transform, false);
        other.SendMessage("SetCanInvestigate", this);
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (canInvestigateObj != null) {
            Destroy(canInvestigateObj);
            canInvestigateObj = null;
            other.SendMessage("ClearCanInvestigate", this);
        }
    }
}
