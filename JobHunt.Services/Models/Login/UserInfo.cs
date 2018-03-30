using System;
using System.Collections.Generic;
using System.Security.Principal;


namespace JobHunt.Services.Models.Login
{
    [Serializable]
    public class UserInfo : IComparable, IEquatable<UserInfo>
    {
        /// <summary>
        /// Unique User Id
        /// </summary>
        public Guid Id { get; internal set; }

        /// <summary>
        /// Unique User SId
        /// </summary>
        public byte[] SId { get; internal set; }

        /// <summary>
        /// User account name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// User display name
        /// </summary>
        public string DisplayName { get; internal set; }

        /// <summary>
        /// Distinguished Name
        /// </summary>
        public string DistinguishedName { get; internal set; }

        /// <summary>
        /// User email address
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        /// User Telephone number
        /// </summary>
        public string PhoneNo { get; internal set; }

        /// <summary>
        /// Group or User
        /// </summary>
        public PrincipalType PrincipalType { get; internal set; }

        /// <summary>
        /// Group user belong to
        /// </summary>
        public IList<string> MemberOf { get; internal set; }

        private string _accountName;

        /// <summary>
        /// Department name of user
        /// </summary>
        public string Department { get; internal set; }

        /// <summary>
        /// Company name of user
        /// </summary>
        public string Company { get; internal set; }

        /// <summary>
        /// Office name of user
        /// </summary>
        public string Office { get; internal set; }

        /// <summary>
        /// Get account domain nam
        /// </summary>
        public string AccountName
        {
            get
            {
                if (_accountName == null)
                {
                    if (SId != null)
                    {
                        try
                        {
                            var sid = new SecurityIdentifier(SId, 0);

                            _accountName = sid.Translate(typeof(NTAccount)).ToString();
                            if (_accountName.Contains("\\"))
                            {
                                _accountName = _accountName.Remove(0, _accountName.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                            }
                        }
                        catch (IdentityNotMappedException)
                        {
                            _accountName = Name;
                        }
                    }
                }

                return _accountName;
            }

            internal set { _accountName = value; }
        }

        private string _sIdString;

        /// <summary>
        /// Get account domain nam
        /// </summary>
        public string SIdString
        {
            get
            {
                if (_sIdString == null)
                {
                    if (SId != null)
                    {
                        var sid = new SecurityIdentifier(SId, 0);

                        _sIdString = sid.ToString();
                    }
                }

                return _sIdString;
            }
        }

        public string ThumbnailPhoto { get; set; }

        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// get display name of UserInfo
        /// </summary>
        /// <returns>return display user name</returns>
        public override string ToString()
        {
            return DisplayName;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return -1;

            if (!(obj is UserInfo))
                throw new ArgumentException("Object is not a User Info.");

            var p2 = (UserInfo)obj;

            return Id.CompareTo(p2.Id);
        }

        public bool Equals(UserInfo other)
        {
            return other != null && Id.Equals(other.Id);
        }
    }

    /// <summary>
    /// Type of Pricipal
    /// </summary>
    public enum PrincipalType
    {
        /// <summary>
        /// AD Group
        /// </summary>
        Group,

        /// <summary>
        /// AD User
        /// </summary>
        Person
    }
}
