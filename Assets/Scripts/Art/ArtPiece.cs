using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public GameObject currentArtModel;

    public void changeArtModel(GameObject artModel)
    {
        if (currentArtModel != null) Destroy(currentArtModel);

        currentArtModel = Instantiate(artModel, transform);
        currentArtModel.transform.localPosition = Vector3.zero;

    }
}
