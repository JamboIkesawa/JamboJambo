using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;
using static Constants.Define;
using static Constants.StaticVar;
using UnityEngine.UI;

public class Lamp_Manager : MonoBehaviour
{
    [SerializeField]    private List<Material> colors           =   null;
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
        lmp_mere = gameObject.GetComponent<MeshRenderer>();
        fnc_set_lmp_mere(colors[CL_LIGHTOFF]);
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
                fnc_lmp_turnon();
                break;
            case ST_FLASHING:
                txt_Status.text = TXT_ST_FLASHING;
                fnc_lmp_flashing();
                break;
            case ST_INTENSITY_CHG:
                txt_Status.text = TXT_ST_INTENSITY_CHG;
                fnc_lmp_intensityChg(button_edge.BtnEdge);
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

#region public function
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
#endregion

#region private function
    /* private関数 */
    private void fnc_sts_update(int new_sts, bool btn_edge)
    {
        lamp.LampStatus = new_sts;
        button_edge.BtnEdge = btn_edge;
    }
    
    private void fnc_lmp_clear()
    {
        fnc_set_lmp_mere(colors[CL_LIGHTOFF]);
    }

    private void fnc_lmp_turnoff()
    {
        fnc_set_lmp_mere(colors[CL_LIGHTOFF]);
    }

    private void fnc_lmp_turnon()
    {
        fnc_set_lmp_mere(colors[CL_LIGHTON]);
    }

    private void fnc_lmp_flashing()
    {
        fnc_set_lmp_mere(colors[CL_LIGHTON]);
    }

    private void fnc_lmp_intensityChg(bool btn_edge)
    {
        if(btn_edge == CMN_TRUE)
        {
            fnc_set_lmp_mere(colors[btn_clk_cnt]);
            if(btn_clk_cnt < colors.Count)
            {
                btn_clk_cnt = 0;
            }
            else
            {
                btn_clk_cnt++;
            }
        }
        else
        {
            // 処理なし
        }
    }

    private void fnc_clear_edge()
    {
        button_edge.BtnEdge = CMN_FALSE;
    }

    private void fnc_set_lmp_mere(Material set_mere)
    {
        lmp_mere.materials[0].color = set_mere.color;
    }
    /*************************************/
#endregion
}
