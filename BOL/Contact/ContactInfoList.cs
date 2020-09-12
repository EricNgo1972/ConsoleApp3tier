using Csla;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SPC
{
    [Serializable]
    public class ContactInfoList : Csla.ReadOnlyListBase<ContactInfoList, ContactInfo>
    {

        public async static Task<ContactInfoList> GetInfoListAsync(Dictionary<string, string> filters)
        {
            return await DataPortal.FetchAsync<ContactInfoList>(new Criteria() { Filters = filters});
            
        }
        public static ContactInfoList GetInfoList(Dictionary<string, string> filters)
        {
            return  DataPortal.Fetch<ContactInfoList>(new Criteria() { Filters = filters});

        }


        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>
        {
            public static readonly PropertyInfo<Dictionary<string,string>> FiltersProperty = RegisterProperty<Dictionary<string,string>>(c => c.Filters);
            public Dictionary<string,string> Filters
            {
                get { return ReadProperty(FiltersProperty); }
                set { LoadProperty(FiltersProperty, value); }
            }
        }

        #region Data Access


        private void DataPortal_Fetch(Criteria criteria)
        {
            // TODO: load values into object

            IsReadOnly = false;
            for (int i = 0; i < 30; i++)
            {
                Add(ContactInfo.GeneratedSampleContactInfo(i));
            }
            IsReadOnly = true;

        }

        #endregion

    }
}
