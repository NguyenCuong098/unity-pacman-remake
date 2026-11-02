using UnityEngine;

public class Pellet : MonoBehaviour
{
    [SerializeField] private PelletType pelletType;

    public PelletType GetPelletType()
    {
        return pelletType;
    }
}
