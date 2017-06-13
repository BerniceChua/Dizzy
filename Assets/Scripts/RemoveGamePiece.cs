using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGamePiece : MonoBehaviour {

    void OnEnable() {
        Invoke("Deactivate", 2.0f);
    }

    void Deactivate() {
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        CancelInvoke(); // prevents "double disabled" from "void OnEnable".
    }
}