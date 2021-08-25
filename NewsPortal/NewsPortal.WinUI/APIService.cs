using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Model;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using NewsPortal.WebAPI.Model;
using NewsPortal.Model.Request;

namespace NewsPortal.WinUI
{
    class APIService
    {
        private string _ruta;
        public static string Username;
        public static string Password;
        public APIService(string ruta)
        {
            _ruta = ruta;
        }

        public async Task<MUser> Authenticate(UserAuthenticationRequest request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/User/Authenticate";
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<MUser>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                if (errors != null) {
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                }
                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(MUser);
            }
        }
        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_ruta}";

            if (search != null)
            {
                url += "?";
           //     url += await search.ToQueryString();

            }

            var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return result;

        }

        public async Task<T> GetById<T>(int? id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_ruta}/{id}";
            var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return result;
        }

        public async Task<T> Update<T>(int? id, object request)
        {

            var url = $"{Properties.Settings.Default.APIUrl}/{_ruta}/id?={id}";
            return await url.PutJsonAsync(request).ReceiveJson<T>();


        }

        //public async Task<T> Insert<T>(object request)
        //{
        //    try
        //    {
        //        var url = $"{Properties.Settings.Default.APIUrl}/{_ruta}";
        //        return await url.PostJsonAsync(request).ReceiveJson<T>();
        //    }
        //    catch (FlurlHttpException ex)
        //    {
        //        if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
        //        {
        //            MessageBox.Show("Niste authentificirani!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        }
        //        if (ex.Call.HttpStatus == System.Net.HttpStatusCode.ServiceUnavailable)
        //        {
        //            MessageBox.Show("Problemi sa serverom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        }
        //        if (ex.Call.HttpStatus == System.Net.HttpStatusCode.NotFound)
        //        {
        //            MessageBox.Show("Resurs ne postoji!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        }
        //        if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
        //        {
        //            MessageBox.Show("Problemi sa serverom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        }
        //        if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
        //        {
        //            MessageBox.Show("Nemate pravo pristupa!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        }
        //        if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
        //        {
        //            MessageBox.Show("Greška napravljena prema serveru!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        }
        //        return default(T);

        //    }
        //}
    }

}
