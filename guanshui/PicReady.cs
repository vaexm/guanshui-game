using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace guanshui
{
    //该类用来定义管子的属性。
    class PicReady
    {
        //定义了该类的一个构造函数
        public PicReady() { }
        public PicReady(int picnum)
            
        {
            PicNum = picnum;
            switch (picnum)
            {
                case 1: IsOpenL = IsOpenT = false; break;
                case 2: IsOpenR = IsOpenT = false; break;
                case 3: IsOpenR=IsOpenB=false;break;
                case 4: IsOpenB = IsOpenL = false; break;
                case 5: IsOpenR = false; break;
                case 6: IsOpenB = false; break;
                case 7: IsOpenL = false; break;
                case 8: IsOpenT = false; break;
                case 9: IsOpenB = IsOpenT = false; break;
                case 10:IsOpenR=IsOpenL=false;break;
                case 11:break;
                case 12: IsOpenL = IsOpenR = IsOpenT = IsOpenB = false; break;
            }


        }  
       
        private bool isOpenL = true;
        /// <summary>
        /// 获取或设置管子是否向左开通。
        /// </summary>
        public bool IsOpenL
        {
            get { return isOpenL; }
            set { isOpenL = value; }
        }
        private bool isOpenR = true;
        /// <summary>
        /// 获取或设置管子是否向右开通
        /// </summary>
        public bool IsOpenR
        {
            get { return isOpenR; }
            set { isOpenR = value; }
        }
        private bool isOpenT = true;
        /// <summary>
        /// 获取或设置管子是否向上开通。
        /// </summary>
        public bool IsOpenT
        {
            get { return isOpenT; }
            set { isOpenT = value; }
        }
        private bool isOpenB = true;
        /// <summary>
        /// 获取或设置管子是否向下开通。
        /// </summary>
        public bool IsOpenB
        {
            get { return isOpenB; }
            set { isOpenB = value; }
        }
        private int picNum = 0;
        /// <summary>
        /// 获取或设置管子的型号。
        /// </summary>
        public int PicNum
        {
            get { return picNum; }
            set { picNum = value; }
        }
        
    }
}
