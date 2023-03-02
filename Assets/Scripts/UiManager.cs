using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;



public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Text _SurvivalTime,Infinishlinetime;
    float StartTime;
    [SerializeField]
    private Text Enemytext,_playertext, Bulletcount, Infinshname, BulletMax,Bombcound,DesignText;

    // bool run;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
       _playertext.text = Bgm.Instance._Playername;
       Infinshname.text = Bgm.Instance._Playername;
        //  _Playerfinsh.text=Menu._Scene1._PlayerName;

}
   
        // Update is called once per frame
        void Update()
    {
      

        time();
        BulletMax.text = Guns.Maxammo.ToString();
     Bulletcount.text=Guns.CurrentAmmoo.ToString();
        Bombcound.text = _CharecterController.Instance.Bombcount.ToString();
        Enemytext.text = Three_D_Enemy.increase.ToString();
    }
    void time()
    {
      //  run = true;
      
        float timing = Time.time - StartTime;
        string minutes = ((int)timing / 60).ToString();
        string Seconds = (timing % 60).ToString("f0");
        _SurvivalTime.text = minutes + ":" + Seconds;
        Infinishlinetime.text = minutes + ":" + Seconds;

    }
    public void Pause()
    {
        Time.timeScale = 0f;
      ///  PauseWindow.SetActive(true);
       
    }
    public void play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;

    }
    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene1");
    }
    public void mainmenu()
    {
        Destroy(Bgm.Instance.gameObject);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
     
    }
  
   
}
