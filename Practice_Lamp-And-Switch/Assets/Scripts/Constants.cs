using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Constants
{
    public static class Define
    {
        // 
        public const bool CMN_TRUE = true;
        public const bool CMN_FALSE = false;

        // 点滅間隔
        public const float FLASHING_INTERVAL = 0.75f;

        // 状態
        public const int ST_TURNOFF = 0;        // 通常消灯
        public const int ST_TURNON = 1;         // 通常点灯
        public const int ST_FLASHING = 2;       // 点滅
        public const int ST_INTENSITY_CHG = 3;  // 強度変更

        // 色
        public const int CL_LIGHTOFF = 0;
        public const int CL_LIGHTON = 1;
        public const int CL_LIGHTON_HALF = 2;

        // UI
        public const string TXT_CLEAR = "";
        public const string TXT_ST_TURNOFF = "通常消灯";
        public const string TXT_ST_TURNON = "通常点灯";
        public const string TXT_ST_FLASHING = "点滅";
        public const string TXT_ST_INTENSITY_CHG = "強度変更";

    }

    public static class StaticVar
    {
        public static Lamp lamp = new Lamp();
        public static Lamp lamp_old = new Lamp();   // 不要のため未使用

        public static Edge button_edge = new Edge();
    }

    public class Lamp
    {
        private int sts_Lamp;

        public int LampStatus{
            get{ return sts_Lamp; }
            set{ sts_Lamp = value; }
        }
    }

    public class Edge
    {
        private bool btn_edge;

        public bool BtnEdge
        {
            get{ return btn_edge; }
            set{ btn_edge = value; }
        }
    }

}
