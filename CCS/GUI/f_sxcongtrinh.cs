using System;
using System.Linq;
using System.Windows.Forms;
using ControlLocalizer;
using DAL;
using  BUS;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI.Report.Nhap
{
    public partial class f_sxcongtrinh : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick1;
        private bool doubleclick2;
        t_todatatable _tTodatatable = new t_todatatable();

        public f_sxcongtrinh()
        {
            InitializeComponent();
            danhmuc.Properties.DataSource = new KetNoiDBDataContext().accounts;
        }


        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Sắp Xếp Công Trình");

            changeFont.Translate(this);

            //translate text
        }


        private void gridView1_Click(object sender, EventArgs e)
        {
            doubleclick1 = false;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (doubleclick1)
            {
                try
                {
                    var dk = new sxcongtrinh();
                    dk.idct = gridView1.GetFocusedRowCellValue("id").ToString();
                    dk.idname = danhmuc.Text;
                    dk.id = gridView1.GetFocusedRowCellValue("key").ToString();
                    db.sxcongtrinhs.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lstnhan = from a in db.sxcongtrinhs
                        join b in db.congtrinhs
                            on a.idct equals b.id
                        where a.idname == danhmuc.Text
                        select new
                        {
                            a.id,
                            a.idct,
                            b.khuvuc,
                            b.loaict,
                            congtrinh = b.tencongtrinh
                        };
                    nhan.DataSource = _tTodatatable.addlst(lstnhan.ToList());
                    gridView1.DeleteSelectedRows();
                }
                catch
                {
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick1 = true;
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            doubleclick2 = true;
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            doubleclick2 = false;
        }

        private void gridView2_RowClick(object sender, RowClickEventArgs e)
        {
            if (doubleclick2)
            {
                try
                {
                    var dk = new sxcongtrinh();
                    var lst =
                        (from a in db.sxcongtrinhs where a.idname == danhmuc.Text select a).Single(
                            t => t.id == gridView2.GetFocusedRowCellValue("id").ToString());
                    db.sxcongtrinhs.DeleteOnSubmit(lst);
                    db.SubmitChanges();
                    var lstnhan = from a in db.sxcongtrinhs
                        join b in db.congtrinhs
                            on a.idct equals b.id
                        where a.idname == danhmuc.Text
                        select new
                        {
                            a.id,
                            a.idct,
                            congtrinh = b.tencongtrinh,
                            b.khuvuc,
                            b.loaict
                        };
                    nhan.DataSource = _tTodatatable.addlst(lstnhan.ToList());

                    var list1 = from a in db.congtrinhs
                        select new
                        {
                            a.id,
                            congtrinh = a.tencongtrinh,
                            key = a.id + danhmuc.Text
                        };
                    var lst3 = from a in list1 select a;
                    for (var j = 0; j < gridView2.DataRowCount; j++)
                    {
                        lst3 = from a in list1
                            where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                            select a;
                    }
                    ;
                    nguon.DataSource = _tTodatatable.addlst(lst3.ToList());
                }
                catch
                {
                }
            }
        }

        private void danhmuc_EditValueChanged(object sender, EventArgs e)
        {
            var lst = (from a in db.accounts select a).Single(t => t.id == danhmuc.Text);
            lblname.Text = lst.name;

            var lstnhan = from a in db.sxcongtrinhs
                join b in db.congtrinhs
                    on a.idct equals b.id
                where a.idname == danhmuc.Text
                select new
                {
                    a.id,
                    a.idct,
                    congtrinh = b.tencongtrinh,
                    b.khuvuc,
                    b.loaict
                };
            nhan.DataSource = _tTodatatable.addlst(lstnhan.ToList());

            var list1 = from a in db.congtrinhs
                select new
                {
                    a.id,
                    congtrinh = a.tencongtrinh,
                    key = a.id + danhmuc.Text,
                    a.khuvuc,
                    a.loaict
                };
            nguon.DataSource = _tTodatatable.addlst(list1.ToList());
            for (var i = gridView1.DataRowCount - 1; i >= 0; i--)
            {
                for (var j = 0; j < gridView2.DataRowCount; j++)
                {
                    if (gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "id").ToString())
                    {
                        gridView1.DeleteRow(i);
                        break;
                    }
                }
            }
            ;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < gridView1.RowCount; i++)
            {
                var dk = new sxcongtrinh();

                dk.idct = gridView1.GetRowCellValue(i, "id").ToString();
                dk.idname = danhmuc.Text;
                dk.id = gridView1.GetRowCellValue(i, "key").ToString();
                db.sxcongtrinhs.InsertOnSubmit(dk);
                db.SubmitChanges();
            }
            for (var i = gridView1.RowCount; i > 0; i--)
            {
                gridView1.DeleteSelectedRows();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }
    }
}