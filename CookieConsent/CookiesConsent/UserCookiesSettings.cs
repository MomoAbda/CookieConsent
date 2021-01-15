using System;
using System.Collections.Generic;
using System.Linq;

namespace CookieConsent.CookiesConsent.Provider.OneTrust
{
    public class UserCookiesSettings : IUserCookiesSettings
    {
        public Dictionary<ICookiesGroup, bool> GroupsConsent { get; }

        public bool IsConsented(ICookiesGroup cookiesGroup)
        {
            if (cookiesGroup != null)
            {

                var findedGroup = GetGroupByName(cookiesGroup.Name);

                if (findedGroup != null)
                    return GroupsConsent.First(p => p.Key.Name == findedGroup.Name).Value;
            }

            return false;
        }

        public ICookiesGroup GetGroupByName(string name)
        {
            var groupExist = GroupsConsent.Any(p => p.Key.Name == name);
            if (groupExist)
                return GroupsConsent.FirstOrDefault(p => p.Key.Name == name).Key;

            return null;
        }

        public UserCookiesSettings(Dictionary<ICookiesGroup, bool> groupsConsent)
        {
            if (groupsConsent == null)
                throw new ArgumentException("Groups Consent is mandatory");

            GroupsConsent = groupsConsent;
        }
    }
}
