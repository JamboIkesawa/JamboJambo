using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;
using static Constants.Define;
using static Constants.StaticVar;
using UnityEngine.UI;

public class Lamp_Manager : MonoBehaviour
{
    [SerializeField]    private Material    color_LightOff      =   null;
    [SerializeField]    private Material    color_LightOn       =   null;
    [SerializeField]    private Material    color_LightOn_Half  =   null;
    [SerializeField]    private Text        txt_Status          =   null;

    private Material lmp_mat = null;
    private MeshRenderer lmp_mere = null;

    // Start is called before the first frame update
    void Start()
    {
        // 変数を初期化
        lamp.LampStatus = ST_TURNOFF;

        // UIを初期化
        txt_Status.text = Define.TXT_CLEAR;

        // ランプを初期化
        //lmp_mat = gameObject.GetComponent<Material>();
        //fnc_set_lmp(color_LightOff);
        lmp_mere = gameObject.GetComponent<MeshRenderer>();
        fnc_set_lmp_mere(color_LightOff);
    }

    // Update is called once per frame
    void Update()
    {
        switch(lamp.LampStatus)
        {
            case ST_TURNOFF:
                txt_Status.text = TXT_ST_TURNOFF;
                fnc_lmp_turnoff();
                break;
            case ST_TURNON:
                txt_Status.text = TXT_ST_TURNON;
                fnc_lmp_turnoff();
                break;
            case ST_FLASHING:
                txt_Status.text = TXT_ST_FLASHING;
                fnc_lmp_flashing();
                break;
            case ST_INTENSITY_CHG:
                txt_Status.text = TXT_ST_INTENSITY_CHG;
                fnc_lmp_intensityChg();
                break;
            default:
                // 処理なし
                break;
        }

        // ボタン入力があればエッジをクリアする
        if(button_edge.BtnEdge = CMN_TRUE)
        {
            fnc_clear_edge();
        }
        else
        {
            // 処理なし
        }
    }

    /* public関数 */
    
    public void fnc_clear()
    {
        Debug.Log("クリアがクリックされました。");
        fnc_sts_update(ST_TURNOFF, CMN_TRUE);
    }

    public void fnc_turnoff()
    {
        Debug.Log("通常消灯がクリックされました。");
        fnc_sts_update(ST_TURNOFF, CMN_TRUE);
    }

    public void fnc_turnon()
    {
        Debug.Log("通常点灯がクリックされました。");
        fnc_sts_update(ST_TURNON, CMN_TRUE);
    }

    public void fnc_flashing()
    {
        Debug.Log("点滅がクリックされました。");
        fnc_sts_update(ST_FLASHING, CMN_TRUE);
    }

    public void fnc_intensityChg()
    {
        Debug.Log("強度変更がクリックされました。");
        fnc_sts_update(ST_INTENSITY_CHG, CMN_TRUE);
    }
    /*************************************/

    /* private関数 */
    private void fnc_sts_update(int new_sts, bool btn_edge)
    {
        lamp.LampStatus = new_sts;
        button_edge.BtnEdge = btn_edge;
    }
    
    private void fnc_lmp_clear()
    {
        fnc_set_lmp(color_LightOff);
    }

    private void fnc_lmp_turnoff()
    {
        fnc_set_lmp(color_LightOff);
    }

    private void fnc_lmp_turnon()
    {
        fnc_set_lmp(color_LightOn);
    }

    private void fnc_lmp_flashing()
    {
        fnc_set_lmp(color_LightOn);
    }

    private void fnc_lmp_intensityChg()
    {
        fnc_set_lmp(color_LightOn_Half);
    }

    private void fnc_clear_edge()
    {
        button_edge.BtnEdge = CMN_FALSE;
    }

    private void fnc_set_lmp(Material set_mat)
    {
        lmp_mat = set_mat;
    }
    private void fnc_set_lmp_mere(Material set_mere)
    {
        lmp_mere.materials[0] = set_mere;
    }
    /*************************************/
}
