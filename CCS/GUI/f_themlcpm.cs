﻿using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using Lotus;

namespace GUI
{
    public partial class f_themlcpm : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_loaicpm ndt = new t_loaicpm();

        public f_themlcpm()
        {
            InitializeComponent();
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtid.Text == "" || txtten.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hdlhd == 0)
                {
                    //khong cho trung ID va Ten
                    var Lst =
                        (from dt in db.dmpchis where dt.danhmuc == txtid.Text || dt.danhmuc_l == txtten.Text select dt)
                            .ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Loại này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        ndt.moi(txtid.Text.Trim(), txtten.Text);
                        Close();
                    }
                }
                else
                {
                    var Lst =
                        (from l in db.dmpchis where l.danhmuc_l == txtten.Text && l.danhmuc != txtid.Text select l)
                            .ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Loại này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        ndt.sua(txtid.Text, txtten.Text);
                        Close();
                    }
                }
            }
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void f_themkhuvuc_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Loại Chi Phí Máy");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            if (Biencucbo.hdlhd == 1)
            {
                txtid.Enabled = false;
            }
        }
    }
}