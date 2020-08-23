using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class UI_Controller : MonoBehaviour
{
    Lamp_Manager lm = new Lamp_Manager();

    public void OnClick_sw_clear()
    {
        lm.fnc_clear();
    }

    public void OnClick_sw_turnoff()
    {
        lm.fnc_turnoff();
    }

    public void OnClick_sw_turnon()
    {
        lm.fnc_turnon();
    }

    public void OnClick_sw_flashing()
    {
        lm.fnc_flashing();
    }

    public void OnClick_sw_intensityChg()
    {
        lm.fnc_intensityChg();
    }

}
