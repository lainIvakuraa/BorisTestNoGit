using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Скрипт загрузки сцены уровня 1
public class StartButton : MonoBehaviour
{
    [SerializeField] string StageScene = "Stage1";

    public void StartGameplay() {
        SceneManager.LoadScene("Essential", LoadSceneMode.Single); //загружаем главную сцену
        //SceneManager.LoadScene("Stage1", LoadSceneMode.Additive); // добавляем саб-сцену 1-ого уровня игры
        SceneManager.LoadScene(StageScene, LoadSceneMode.Additive);
    }
}
