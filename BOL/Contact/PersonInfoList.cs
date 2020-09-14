using Csla;
using Csla.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPC
{
    [Serializable]
    public class PersonInfoList : ReadOnlyListBase<PersonInfoList, PersonInfo>
    {
        public async static Task<PersonInfoList> GetInfoListAsync(Dictionary<string, string> filters)
        {
            return await DataPortal.FetchAsync<PersonInfoList>(new Criteria(filters));
        }

        public static PersonInfoList GetInfoList(Dictionary<string, string> filters)
        {
            return DataPortal.Fetch<PersonInfoList>(new Criteria(filters));
        }


        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>
        {
            public Criteria() { }

            public Criteria(Dictionary<string, string> pFilters)
            {
                Filters = new MobileDictionary<string, string>(pFilters ?? new Dictionary<string, string>());
            }

            public MobileDictionary<string, string> Filters { get; set; }
        }

        #region Data Access


        private void DataPortal_Fetch(Criteria criteria)
        {
            // TODO: load values into object

            IsReadOnly = false;
            for (int i = 0; i < 10; i++)
            {
                Add(PersonInfo.GeneratedSamplePersonInfo(i));
            }
            IsReadOnly = true;

        }

        #endregion
    }

    [Serializable]
    public class PersonInfo : ReadOnlyBase<PersonInfo>
    {
        public static readonly PropertyInfo<string> EmplCodeProperty = RegisterProperty<string>(c => c.EmplCode);
        public string EmplCode { get { return GetProperty(EmplCodeProperty); } private set { LoadProperty(EmplCodeProperty, value); } }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        public string Name { get { return GetProperty(NameProperty); } private set { LoadProperty(NameProperty, value); } }


        [Create, RunLocal]
        private void Create() { }

        internal static PersonInfo GeneratedSamplePersonInfo(int Index)
        {
            var rand = new Random();

            var ret = DataPortal.Create<PersonInfo>();
            ret.EmplCode = $"G{string.Format("{0:000}", Index)}";
            ret.Name = $"employee  with auto generated name {rand.Next()}";
            return ret;

        }
    }
}
