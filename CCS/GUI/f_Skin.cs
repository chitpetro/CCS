using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace GUI
{
    public partial class f_Skin : Form
    {
        private KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly ImageCollection img;
        private readonly t_skinabc sk = new t_skinabc();

        public f_Skin()
        {
            InitializeComponent();
            img = new ImageCollection();
            imageComboBoxEdit1.Properties.SmallImages = img;
            for (var i = 0; i < SkinManager.Default.Skins.Count; i++)
            {
                var skinName = SkinManager.Default.Skins[i].SkinName;
                img.AddImage(SkinCollectionHelper.GetSkinIcon(skinName, SkinIconsSize.Small), skinName);
                imageComboBoxEdit1.Properties.Items.Add(new ImageComboBoxItem(skinName, i));
                //if (skinName == Properties.Settings.Default.theme)
                //{
                //    imageComboBoxEdit1.SelectedIndex = i;
                //}
            }

            //defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Properties.Settings.Default.theme);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (imageComboBoxEdit1.Text == "")
                return;
            sk.sua(Biencucbo.skin);
            var frm = new f_main();
            frm.Refresh();
            Close();
        }

        private void f_Skin_Load(object sender, EventArgs e)
        {
            var lst = (from a in new KetNoiDBDataContext().skins select a).Single(t => t.trangthai == true);
            Biencucbo.skin = lst.tenskin;
            //defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
            //LanguageHelper.Translate(this); 
            //Biencucbo.skin2 = Biencucbo.skin; 
        }

        private void Skinht_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Biencucbo.skin = Biencucbo.skin2;
            var frm = new f_main();
            frm.Refresh();
            Close();
        }

        private void imageComboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Biencucbo.skin = imageComboBoxEdit1.Text;
            var frm = new f_main();
            frm.Refresh();
        }
    }
}