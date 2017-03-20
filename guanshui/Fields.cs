using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace guanshui
{
    class Fields
    {
        public Fields() { }
        public Fields(int fieldNum)
        { 
            if(fieldNum<7)
            {
                isLinkT = false;
            }
            if(fieldNum>41)
            {
                isLinkB = false;
            }
            if(fieldNum%7==0)
            {
                isLinkL = false;
            }
            if((fieldNum+1)%7==0)
            {
                isLinkR = false;
            }
        }
        private bool isLinkL = true;
        /// <summary>
        /// 获取或设置该块地左边是否有地
        /// </summary>
        public bool IsLinkL
        {
            get { return isLinkL; }
            set { isLinkL = value; }
        }
        private bool isLinkR = true;
        /// <summary>
        /// 获取或设置该块地右边是否有地
        /// </summary>
        public bool IsLinkR
        {
            get { return isLinkR; }
            set { isLinkR = value; }
        }
        private bool isLinkB = true;
        /// <summary>
        /// 获取或设置该块地下边是否有地
        /// </summary>
        public bool IsLinkB
        {
            get { return isLinkB; }
            set { isLinkB = value; }
        }
        private bool isLinkT = true;
        /// <summary>
        /// 获取或设置该块地上边是否有地
        /// </summary>
        public bool IsLinkT
        {
            get { return isLinkT; }
            set { isLinkT = value; }
        }
        private PicReady picReady = new PicReady(12);
        public PicReady PicReady
        {
            get { return picReady; }
            set { picReady = value; }
        }
        private bool isCover = false;
        public bool IsCover
        {
            get { return isCover; }
            set { isCover = value; }
        }
        private bool isWater = false;
        public bool IsWater
        {
            get { return isWater; }
            set { isWater = value; }
        }
        private Image clickImage;
        public Image ClickImage
        {
            get { return clickImage; }
            set { clickImage=value;}
        }
    }
}
