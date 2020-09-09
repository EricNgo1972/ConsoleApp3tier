﻿using Csla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SPC
{
    [Serializable]
    public class ContactInfo: Csla.ReadOnlyBase<ContactInfo>
    {
        public static readonly PropertyInfo<string> ContactCodeProperty = RegisterProperty<string>(c => c.ContactCode);
        public string ContactCode
        {
            get { return GetProperty(ContactCodeProperty); }
            private set { LoadProperty(ContactCodeProperty, value); }
        }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        public string Name
        {
            get { return GetProperty(NameProperty); }
            private set { LoadProperty(NameProperty, value); }
        }

        public static readonly PropertyInfo<string> ContactTypeProperty = RegisterProperty<string>(c => c.ContactType);
        public string ContactType
        {
            get { return GetProperty(ContactTypeProperty); }
            private set { LoadProperty(ContactTypeProperty, value); }
        }

        internal static ContactInfo GeneratedSampleContactInfo(int Index)
        {
            var rand = new Random();
            return new ContactInfo() { ContactCode = $"G{string.Format("{0:000}",Index)}", Name = $"Contact with auto generated name {rand.Next()}" , ContactType ="TEST" };
            
        }
    }


}