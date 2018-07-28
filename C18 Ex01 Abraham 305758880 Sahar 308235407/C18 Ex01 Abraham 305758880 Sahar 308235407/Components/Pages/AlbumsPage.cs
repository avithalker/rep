using System;
using System.Drawing;
using System.Windows.Forms;
using DesktopFacebook.Business;
using DesktopFacebook.Components.UserControls;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Components.Pages
{
    public partial class AlbumsPage : UserControl
    {
        private FacebookUserManager m_FacebookUserManager;
        private DataFetchIndicator m_DataFetchIndicator;

        public AlbumsPage(FacebookUserManager i_FacebookUserManager, DataFetchIndicator i_DataFetchIndicator)
        {
            InitializeComponent();
            m_FacebookUserManager = i_FacebookUserManager;
            m_DataFetchIndicator = i_DataFetchIndicator;
        }

        public void FetchUserAlbums()
        {
            int k_x = AlbumsPanel.Bounds.Left;
            int y = AlbumsPanel.Bounds.Top;
            TitledPictureControl albumControl = null;

            foreach (Album album in m_FacebookUserManager.NativeClient.Albums)
            {
                albumControl = addAlbumComponent(album, k_x, y);
                y += albumControl.Height + 10;
            }

            m_DataFetchIndicator.AreAlbumsWereFetch = true;
        }

        private TitledPictureControl addAlbumComponent(Album i_album, int i_x, int i_y)
        {
            TitledPictureControl albumControl = new TitledPictureControl(i_album.PictureAlbumURL, i_album.Name, i_album.Id);

            albumControl.Location = new Point(i_x, i_y);
            albumControl.Click += AlbumControl_Click;
            AlbumsPanel.Controls.Add(albumControl);
            return albumControl;
        }

        private void AlbumControl_Click(object sender, EventArgs e)
        {
            TitledPictureControl albumControl = sender as TitledPictureControl;
            Album album = m_FacebookUserManager.FindAlbumById(albumControl.Id);

            SelectedAlbumNameLabel.Text = album.Name;
            fillAlbumPicturePanel(album.Photos);
        }

        private void fillAlbumPicturePanel(FacebookObjectCollection<Photo> i_AlbumPhotos)
        {
            int xLocation = 0;
            int yLocation = 0;
            int marginSpace = 10;

            AlbumPicturesPanel.Controls.Clear();
            foreach (Photo albumPhoto in i_AlbumPhotos)
            {
                PictureBox photoPictureBox = new PictureBox();
                photoPictureBox.Size = new Size(120, 120);
                photoPictureBox.LoadAsync(albumPhoto.PictureNormalURL);
                photoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                photoPictureBox.Location = new Point(xLocation, yLocation);
                AlbumPicturesPanel.Controls.Add(photoPictureBox);

                xLocation += photoPictureBox.Width + marginSpace;
                if (xLocation >= AlbumPicturesPanel.Width - photoPictureBox.Width)
                {
                    xLocation = 0;
                    yLocation += photoPictureBox.Height + marginSpace;
                }
            }
        }
    }
}
