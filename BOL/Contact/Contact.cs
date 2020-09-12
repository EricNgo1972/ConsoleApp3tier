using Csla;
using Csla.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SPC
{
    [Serializable]
    public class Contact : Csla.BusinessBase<Contact>
    {

        #region Properties

        public static readonly PropertyInfo<string> ContactCodeProperty = RegisterProperty<string>(c => c.ContactCode);
        public string ContactCode
        {
            get { return GetProperty(ContactCodeProperty); }
            set { SetProperty(ContactCodeProperty, value); }
        }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        public static readonly PropertyInfo<string> ContactTypeProperty = RegisterProperty<string>(c => c.ContactType);
        public string ContactType
        {
            get { return GetProperty(ContactTypeProperty); }
            set { SetProperty(ContactTypeProperty, value); }
        }

        #endregion
        

        #region Factory

        public static void NewContact(string pContactCode)
        {
            DataPortal.Create<Contact>(new Criteria() { ContactCode = pContactCode });
        }

        public static void GetContact(string pContactCode)
        {
            DataPortal.Fetch<Contact>(new Criteria() { ContactCode = pContactCode });
        }

        public static async Task<Contact> NewContactAsync()
        {
            return await DataPortal.CreateAsync<Contact>();
        }

        public static async Task<Contact> GetContactAsync(string pContactCode)
        {
            return await DataPortal.FetchAsync<Contact>(new Criteria() { ContactCode = pContactCode });
        }

        public static void DeleteContact(string pContactCode)
        {
            DataPortal.Delete<Contact>(new Criteria() { ContactCode = pContactCode });
        }

        #endregion

        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>
        {
            public static readonly PropertyInfo<string> ContactCodeProperty = RegisterProperty<string>(c => c.ContactCode);
            public string ContactCode
            {
                get { return ReadProperty(ContactCodeProperty); }
                set { LoadProperty(ContactCodeProperty, value); }
            }
        }

        #region Data Access


        private void DataPortal_Fetch(Criteria criteria)
        {
            // TODO: load values into object
            var msg = $"Fetching contact: {criteria.ContactCode}";

        }

        protected override void DataPortal_Insert()
        {
            // TODO: insert object's data
            var msg = $"Insert new contact: {ContactCode}-{Name}";
        }

        protected override void DataPortal_Update()
        {
            // TODO: update object's data
            var msg = $"Update contact : {ContactCode}-{Name}";
        }

        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria() { ContactCode = ContactCode });
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            // TODO: delete object's data
            var msg = $"Delete contact : {ContactCode}-{Name}";
        }


        #endregion


    }
}
