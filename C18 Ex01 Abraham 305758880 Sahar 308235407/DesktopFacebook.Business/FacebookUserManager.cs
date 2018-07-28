using DesktopFacebook.Business.Settings;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFacebook.Business
{
    public class FacebookUserManager
    {
        private User m_NativeClient;

        public User NativeClient
        {
            get { return m_NativeClient; }
        }

        public LoginResult Login(string i_AccessToken = null)
        {
            FacebookService.s_FbApiVersion = 2.8f;

            LoginResult result;

            if(string.IsNullOrEmpty(i_AccessToken))
            {
                result = FacebookService.Login(ApplicationSettings.k_ApplicationId, ApplicationSettings.sr_ApplicationPermissions);
            }
            else
            {
                result = FacebookService.Connect(i_AccessToken);
            }

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_NativeClient = result.LoggedInUser;
            }

            return result;
        }

        public User FindFriendById(string i_FriendId)
        {
            User requestedFriend = null;
            foreach (User friend in m_NativeClient.Friends)
            {
                if (string.Compare(i_FriendId, friend.Id) == 0)
                {
                    requestedFriend = friend;
                    break;
                }
            }

            return requestedFriend;
        }

        public bool IsFriendLikedPost(Post i_Post, string i_FriendId )
        {
            bool result = false;

            foreach(User friend in  i_Post.LikedBy)
            {
                if(friend.Id == i_FriendId)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public Album FindAlbumById(string i_Id)
        {
            Album requestedAlbum = null;

            foreach (Album album in m_NativeClient.Albums)
            {
                if (string.Compare(album.Id, i_Id) == 0)
                {
                    requestedAlbum = album;
                    break;
                }
            }

            return requestedAlbum;
        }
    }
}
