using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Components.UserControls.TitledPicture
{
    public class AlbumDescriptiveCover : IDescriptivePicture
    {
        Album m_Album;

        public AlbumDescriptiveCover(Album i_Album)
        {
            m_Album = i_Album;
        }

        public string PictureUrl
        {
            get
            {
                return m_Album.PictureAlbumURL;
            }
        }

        public string Description
        {
            get
            {
                return m_Album.Name;
            }
        }
    }
}
