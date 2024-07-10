using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EmailButton : MonoBehaviour
{
    public Button sendEmailButton;
    public string emailAddress = "tranquangtuananh2801@gmail.com";
    public string subject = "Hello from Unity";
    public string body = "Hello World";

    private void Start()
    {
        if (sendEmailButton != null)
        {
            sendEmailButton.onClick.AddListener(SendEmail);
        }
    }

    public void SendEmail()
    {
        string mailtoUrl = "mailto:" + emailAddress + "?subject=" + subject + "&body=" + body;
        Application.OpenURL(mailtoUrl);
    }
}
