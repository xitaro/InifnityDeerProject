using UnityEngine;
using UnityEngine.UI;
//using Photon.Pun;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;

    //private PhotonView view;

    private void Awake()
    {
       // view = GetComponent<PhotonView>();
    }

    public void SetHealth(int health)
    {
        //view.RPC("SetHealthRPC", RpcTarget.All, health);
        slider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        SetHealth(health);
    }

    /*[PunRPC]
    private void SetHealthRPC(int health)
    {
        slider.value = health;
    }*/
}
