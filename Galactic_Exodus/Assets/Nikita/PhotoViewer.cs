using UnityEngine;
using UnityEngine.UI;

public class PhotoViewer : MonoBehaviour
{
    public GameObject photoPanel;
    public Image photoImage;
    public Sprite[] photos;

    private int currentIndex = 0;

    public void OpenPhotos()
    {
        currentIndex = 0;
        photoImage.sprite = photos[currentIndex];
        photoPanel.SetActive(true);
    }

    public void NextPhoto()
    {
        currentIndex++;
        if (currentIndex < photos.Length)
        {
            photoImage.sprite = photos[currentIndex];
        }
        else
        {
            ClosePhotos();
        }
    }

    public void ClosePhotos()
    {
        photoPanel.SetActive(false);
    }
}
