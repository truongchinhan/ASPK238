﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTap.Bai06
{
    public enum Phai {Nữ,Nam };
    public class NhanVien1
    {
         #region Cách 1: Sử dụng delegate tự định nghĩa

        //--- Định nghĩa delegate XuLyThongBao
        public delegate void XuLyThongBao(string NoiDung);
        //---Khai báo event (sự kiện|biến cố) tên là TangLuong có kiểu delegate XuLyThongBao
        public event XuLyThongBao TangLuong;

        private double _HeSoLuong = 1;
        public double HeSoLuong
        {
            get { return _HeSoLuong; }
            set
            {
                if (value < 1)
                    throw new Exception("Hệ số lương phải >=1");
                else
                {
                    bool hslTang = true;
                    if (value <= _HeSoLuong) hslTang = false;
                    _HeSoLuong = value;
                    // Cách 1:
                    if (hslTang && TangLuong != null)
                    {
                        // Cho phát sinh sự kiện và gởi thông điệp ra bên ngoài
                        string noiDung = string.Format("Chúc mừng bạn {0} được tăng lương!", HoTen);
                        TangLuong(noiDung);
                    }
                }
            }
        }

        #endregion

        #region Auto-Implemented Properties
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public Phai GioiTinh { get; set; }
        #endregion

        #region Full properties


        private DateTime _NgaySinh;

        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }
        private DateTime _NgayVaoLam;

        public DateTime NgayVaoLam
        {
            get { return _NgayVaoLam; }
            set { _NgayVaoLam = value; }
        }

      
        #endregion
        
        #region Read Only Property
        /// <summary>
        /// Trả về số năm đã làm việc tại công ty
        /// </summary>
        public int ThamNien
        {
            get
            {
                int kq=0;
                int namHienHanh = DateTime.Today.Year;
                int namVaoLam = _NgayVaoLam.Year;
                kq = namHienHanh - namVaoLam;
                return kq;
            }
        }
        #endregion

        #region static property

        private static double _LuongCoBan=5000000;

        public static double LuongCoBan
        {
            get { return _LuongCoBan; }
            set { _LuongCoBan = value; }
        }
                
        #endregion

        #region Phương thức xử lý tính toán

        public double TinhLuong()
        {
            double kq = 0;
            kq = _HeSoLuong * _LuongCoBan;
            return kq;
        }
        public double TinhThuong()
        {
            double kq = 0;
            kq = ThamNien*500000;
            return kq;
        }

        public string XuatThongTin(string XuongDong="<br/>")
        {
            string kq = "";
            double luong = TinhLuong();
            double thuong = TinhLuong();
            double tong = luong + thuong;
            kq = string.Format("Nhân viên:{1}-{2}{0}Tiền thưởng:{3}{0}Tiền lương:{4}{0}Tổng cộng:{5}",
                XuongDong, MaSo, HoTen, thuong.ToString("#,##0VNĐ"), luong.ToString("#,##0VNĐ"), tong.ToString("#,##0VNĐ"));
            return kq;
        }
        #endregion

        #region Constructors - phương thức khởi tạo

        public NhanVien1(string MaSo,string HoTen, DateTime NgaySinh,DateTime NgayVaoLam, Phai GioiTinh, double HeSoLuong)
        {
            this.MaSo = MaSo;
            this.HoTen = HoTen;
            this.NgaySinh = NgaySinh;
            this.NgaySinh = NgaySinh;
            this.NgayVaoLam = NgayVaoLam;
            this.GioiTinh = GioiTinh;
            this.HeSoLuong = HeSoLuong;
        }

        public NhanVien1()
        {
            // Gán giá trị mặc định
            _NgayVaoLam = DateTime.Today;
        }

        #endregion
    
    }

}