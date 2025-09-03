using System.Collections.Generic;
using UnityEngine;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;

    public void ChangeColorByType(ArtManager.ArtType artType)
    {
        
        var colorSetup = colorSetups.Find(setup => setup.artType == artType);
        
        for (int i = 0 ; i < materials.Count; i++)
        {
            materials[i].SetColor("_Color", colorSetup.color);
        }
    }
}

[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;

    public Color color;
}
