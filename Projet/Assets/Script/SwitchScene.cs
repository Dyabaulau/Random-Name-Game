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
        public string Perso;
        
        public void Sceneload()
        {
            if (SceneManager.GetActiveScene().name == "DungeonSelect")
            {
                SceneManager.LoadScene(4);
                GetComponent<NetworkManager>().Scene = SceneManager.GetSceneByBuildIndex(Scene).name;
                
            }
            else
                SceneManager.LoadScene(Scene);
        }
    }
}
