using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bgm : MonoBehaviour
{
    public static Bgm Instance;
    [SerializeField]
    private InputField Username;
    [SerializeField]
    private GameObject feildout,usernameobg;
    public string _Playername;
    public int Mousensitivity;
    // public int Mousensitivity;
    [SerializeField]
    private Text yourname;
    // Start is called before the first frame update
    void Start()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }
 
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            yourname.text = Username.text;
            feildout.SetActive(true);
            usernameobg.SetActive(false);
            _Playername = Username.text;
       

        }
    }
    public void playertag()
    {
        _Playername = Username.text;
    }
}
