using Csla;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPC
{
    [Serializable]
    public class PersonInfoList: ReadOnlyListBase<PersonInfoList,PersonInfo>
    {
        public async static Task<PersonInfoList> GetInfoListAsync(Dictionary<string, string> filters)
        {
            return await DataPortal.FetchAsync<PersonInfoList>(new Criteria() { Filters = filters });

        }
        public static PersonInfoList GetInfoList(Dictionary<string, string> filters)
        {
            return DataPortal.Fetch<PersonInfoList>(new Criteria() { Filters = filters });

        }


        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>
        {
            public static readonly PropertyInfo<Dictionary<string, string>> FiltersProperty = RegisterProperty<Dictionary<string, string>>(c => c.Filters);
            public Dictionary<string, string> Filters
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
        public string EmplCode
        {
            get { return GetProperty(EmplCodeProperty); }
            private set { LoadProperty(EmplCodeProperty, value); }
        }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        public string Name
        {
            get { return GetProperty(NameProperty); }
            private set { LoadProperty(NameProperty, value); }
        }

    //    [Create, RunLocal]
        private void Create() { }

        internal static PersonInfo GeneratedSamplePersonInfo(int Index)
        {
            var rand = new Random();

            //var ret = DataPortal.Create<PersonInfo>();
            //ret.EmplCode = $"G{string.Format("{0:000}", Index)}";
            //ret.Name = $"employee  with auto generated name {rand.Next()}";
            //return ret;
            
            return   new PersonInfo() { EmplCode = $"E{string.Format("{0:000}",Index)}", Name = $"employee with auto generated name {rand.Next()}"  };
        }
    }
}
