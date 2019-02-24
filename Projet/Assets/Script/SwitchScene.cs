using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BestMasterYi
{
    public class SwitchScene : MonoBehaviour
    {
        public int Scene;

        public void Sceneload(int Scene)
        {
            if (SceneManager.GetActiveScene().name == "DungeonSelect")
            {
                SceneManager.LoadScene(3);
                GetComponent<NetworkManager>().Scene = SceneManager.GetSceneByBuildIndex(Scene).name;
            }
            else
                SceneManager.LoadScene(Scene);
        }
    }
}
