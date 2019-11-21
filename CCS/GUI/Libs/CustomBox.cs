using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Lotus.Libraries
{
    public partial class CustomBox : XtraMessageBoxForm
    {
        private readonly MsgBox.DialogButton[] _buttons;

        public CustomBox()
        {
            InitializeComponent();
        }

        public CustomBox(MsgBox.DialogButton[] buttons)
        {
            InitializeComponent();
            _buttons = buttons;
        }

        protected override string GetButtonText(DialogResult target)
        {
            var button = _buttons.FirstOrDefault(b => b.Button == target);
            if (string.IsNullOrEmpty(button.ButtonText)) return base.GetButtonText(target);
            return button.ButtonText;
        }
    }
}