#region Copyright 2010 by Roger Knapp, Licensed under the Apache License, Version 2.0
/* Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion
using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using JiraSVN.Plugin.Properties;
using CSharpTest.Net.Serialization;

namespace JiraSVN.Plugin
{
    static class CertificateHandler
    {
        static readonly INameValueStore Storage;


        static CertificateHandler()
        {
            ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;
            Storage = new CSharpTest.Net.Serialization.StorageClasses.RegistryStorage();
        }

        public static void Hook()
        {
            Check.NotNull(Storage);
        }

        static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            WebRequest request = sender as WebRequest;
            if (request == null || certificate == null)
                return false;

            bool isAllowed;
            string allowed, urn = String.Format("{0}:{1}", request.RequestUri.Host, request.RequestUri.Port);
            if (Storage.Read(urn, certificate.GetCertHashString(), out allowed) && bool.TryParse(allowed, out isAllowed))
                return isAllowed;

            string sslErrorDesc = String.Empty;
            if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) == SslPolicyErrors.RemoteCertificateChainErrors)
                sslErrorDesc += Resources.RemoteCertificateChainErrors;
            else if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) == SslPolicyErrors.RemoteCertificateNameMismatch)
                sslErrorDesc += Resources.RemoteCertificateNameMismatch;
            else if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) == SslPolicyErrors.RemoteCertificateNotAvailable)
                sslErrorDesc += Resources.RemoteCertificateNotAvailable;

            sslErrorDesc = String.Format(Resources.SslErrorDescPromptFormat,
                urn, sslErrorDesc, certificate.Subject, certificate.GetCertHashString());

            DialogResult dr = MessageBox.Show(sslErrorDesc, "SSL Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            if (dr != DialogResult.Yes)
                return false;

            Storage.Write(urn, certificate.GetCertHashString(), true.ToString());
            return true;
        }
    }
}
