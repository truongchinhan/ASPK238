using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTap.Demo
{
    public class SinhVien
    {

        #region Properties

        private string _MaSo;
        public string MaSo
        {
            get { return _MaSo; }
            set { _MaSo = value; }
        }

        private string _HoTen;
        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        #endregion


        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public SinhVien() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maSo"></param>
        /// <param name="hoTen"></param>
        public SinhVien(string maSo, string hoTen)
        {
            this.MaSo = maSo;
            this.HoTen = hoTen;
        }




        #endregion



    }
}