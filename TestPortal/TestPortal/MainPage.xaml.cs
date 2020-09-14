using SPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestPortal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            
                var login = new ClaimsPrincipal(new ClaimsIdentity());
                Csla.ApplicationContext.User = login;

                var list = await PersonInfoList.GetInfoListAsync(null);

                var list2 =  PersonInfoList.GetInfoList(null);

           
        }
    }
}
