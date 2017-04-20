
using System.Linq;
using UnityEngine;


namespace SmartHome.Simulator.Utility
{
    public class AddAllDoors : MonoBehaviour
    {

        h005_openDoor_S doorOpener;
        // Use this for initialization
        void Start()
        {
            doorOpener = GetComponent<h005_openDoor_S>();
            doorOpener.allDoor = FindObjectsOfType<h005_openAnim_S>().Select(door => door.gameObject).ToArray();

        }
    }
}