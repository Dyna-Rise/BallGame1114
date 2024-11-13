using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject statusImage; //Canvas下にあるStatusImageオブジェクトを参照
    public GameObject panel; //Canvas下にあるPanelオブジェクトを参照
    public GameObject retryButton; //Canvas下にあるRetryButtonオブジェクトを参照
    public GameObject nextButton; //Canvas下にあるNextButtonオブジェクトを参照

    public Sprite gameClearImage; //GameClearの絵を参照
    public Sprite gameOverImage; //GameOverの絵を参照

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        Invoke("StatusHidden", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.gameStatus == "Stop")
        {
            return;
        }

        if(PlayerController.gameStatus == "GameClear")
        {
            StatusDisplay();
            statusImage.GetComponent<Image>().sprite = gameClearImage;
            retryButton.GetComponent<Button>().interactable = false;
            PlayerController.gameStatus = "Stop";
        }

        if (PlayerController.gameStatus == "GameOver")
        {
            StatusDisplay();
            statusImage.GetComponent<Image>().sprite = gameOverImage;
            nextButton.GetComponent<Button>().interactable = false;
            PlayerController.gameStatus = "Stop";
        }
    }

    void StatusHidden()
    {
        statusImage.SetActive(false);
    }

    void StatusDisplay()
    {
        statusImage.SetActive(true);
        panel.SetActive(true);
    }
}
