using System.Windows.Forms;

namespace DesktopFacebook.Components.UserControls
{
    public partial class TitledPictureControl : UserControl
    {
        private string m_Id;

        public string Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public TitledPictureControl(string i_ImageUrl,string i_Title,string i_Id)
        {
            InitializeComponent();
            m_Id = i_Id;
            TitleLabel.Text = i_Title;
            if(!string.IsNullOrEmpty(i_ImageUrl))
            {
                PhotoPictureBox.LoadAsync(i_ImageUrl);
            }
        }
    }
}
