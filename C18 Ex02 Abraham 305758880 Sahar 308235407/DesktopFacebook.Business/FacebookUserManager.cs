﻿using System;
using System.Collections.Generic;
using DesktopFacebook.Business.Settings;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Business
{
    public class FacebookUserManager
    {
        private User m_NativeClient;
        private UserSettings m_userSettings;

        public User NativeClient
        {
            get { return m_NativeClient; }
        }

        public FacebookUserManager()
        {
            LoadUserSettings();
        }

        public LoginResult Login(bool i_RememberUser = false)
        {
            FacebookService.s_FbApiVersion = ApplicationSettings.k_FacebookApiVersion;
            LoginResult result;

            if (string.IsNullOrEmpty(m_userSettings.UserLastAccessToken))
            {
                result = FacebookService.Login(ApplicationSettings.k_ApplicationId, ApplicationSettings.sr_ApplicationPermissions);
            }
            else
            {
                result = FacebookService.Connect(m_userSettings.UserLastAccessToken);
            }

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_NativeClient = result.LoggedInUser;
                m_userSettings.UserLastAccessToken = result.AccessToken;
                if (i_RememberUser == true)
                {
                    m_userSettings.SaveSettings();
                }
            }

            return result;
        }

        public void Logout()
        {
            m_userSettings.UserLastAccessToken = string.Empty;
            m_userSettings.SaveSettings();
            FacebookService.Logout(() => { });
        }

        public bool IsRecognizedUser()
        {
            return !string.IsNullOrEmpty(m_userSettings.UserLastAccessToken);
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

        public bool IsFriendLikedPost(Post i_Post, string i_FriendId)
        {
            bool result = false;

            foreach (User friend in i_Post.LikedBy)
            {
                if (friend.Id == i_FriendId)
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

        public List<Event> FindEventsByDate(DateTime i_EventDate)
        {
            List<Event> events = new List<Event>();

            foreach (Event userEvent in m_NativeClient.Events)
            {
                if (userEvent.StartTime.HasValue)
                {
                    if (userEvent.StartTime.Value.Date == i_EventDate.Date)
                    {
                        events.Add(userEvent);
                    }
                }
            }

            return events;
        }

        public Event.eRsvpType GetRsvpForEvent(string i_EventId)
        {
            Event.eRsvpType eventRsvp;

            if (isEventExistInCollection(i_EventId, m_NativeClient.EventsCreated))
            {
                eventRsvp = Event.eRsvpType.Attending;
            }
            else if (isEventExistInCollection(i_EventId, m_NativeClient.EventsDeclined))
            {
                eventRsvp = Event.eRsvpType.Declined;
            }
            else if (isEventExistInCollection(i_EventId, m_NativeClient.EventsMaybe))
            {
                eventRsvp = Event.eRsvpType.Maybe;
            }
            else
            {
                throw new Exception("Rsvp unknown!");
            }

            return eventRsvp;
        }

        public List<User> GetFriendsAsList()
        {
            List<User> friendList = new List<User>();

            foreach (User friend in m_NativeClient.Friends)
            {
                friendList.Add(friend);
            }

            return friendList;
        }

        private bool isEventExistInCollection(string i_EventId, FacebookObjectCollection<Event> i_Events)
        {
            bool isExist = false;
            foreach (Event userEvent in m_NativeClient.EventsCreated)
            {
                if (string.Compare(userEvent.Id, i_EventId) == 0)
                {
                    isExist = true;
                    break;
                }
            }

            return isExist;
        }

        private void LoadUserSettings()
        {
            m_userSettings = UserSettings.LoadSettings();
        }
    }
}
