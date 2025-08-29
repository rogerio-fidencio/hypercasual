using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType 
    {
        CUBE,
        SPHERE,
        CYLINDER
    }

    public List<ArtSetup> artSetups;

   public ArtSetup getArtSetupByArtType(ArtManager.ArtType artType)
    {
        return artSetups.Find(i => i.artType == artType);
    }
}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;

    public GameObject model;
}
