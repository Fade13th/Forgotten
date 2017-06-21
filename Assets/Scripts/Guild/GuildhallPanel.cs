using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuildhallPanel : MonoBehaviour {
    private CanvasGroup panel;

    void Start() {
        panel = GetComponent<CanvasGroup>();
    }

    public void Show() {
        panel.alpha = 1;
        panel.blocksRaycasts = true;
    }

    public void Hide() {
        panel.alpha = 0;
        panel.blocksRaycasts = false;
    }
}
