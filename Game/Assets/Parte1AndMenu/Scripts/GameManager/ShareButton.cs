using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareButton : MonoBehaviour
{
    private string Message;

    public void ShareResults()
    {
        Message = "Ao guarda un po', ho appena totalizzato " + PlayerPrefs.GetInt("score", 0).ToString() + " punti al gioco più bello del mondo, so popo forte, prova anche tu UniverSea!";
        StartCoroutine(WaitAndShare());
    }
    private IEnumerator WaitAndShare()
    {
        yield return new WaitForEndOfFrame();
        Texture2D s = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        s.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        s.Apply();
        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, s.EncodeToPNG());

        Destroy(s);
        new NativeShare().AddFile(filePath).SetSubject("UniverSea").SetText(Message).Share();
    }
}
