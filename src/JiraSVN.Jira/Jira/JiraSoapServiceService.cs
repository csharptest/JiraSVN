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
using System.Collections.Generic;

namespace CSharpTest.Net.SvnJiraIntegration.Jira
{
    /// <summary>
    /// ROK - Hack to fix the invalid return type of these methods
    /// </summary>
    partial class JiraSoapServiceService
    {
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace = "http://soap.rpc.jira.atlassian.com", ResponseNamespace = "http://localhost:8080/rpc/soap/jirasoapservice-v2")]
        [return: System.Xml.Serialization.SoapElementAttribute("addWorklogWithNewRemainingEstimateReturn")]
        public void addWorklogWithNewRemainingEstimateFixed(string in0, string in1, RemoteWorklog in2, string in3)
        {
            object[] results = this.Invoke("addWorklogWithNewRemainingEstimate", new object[] {
                        in0,
                        in1,
                        in2,
                        in3});
            //return ((RemoteWorklog)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace = "http://soap.rpc.jira.atlassian.com", ResponseNamespace = "http://localhost:8080/rpc/soap/jirasoapservice-v2")]
        [return: System.Xml.Serialization.SoapElementAttribute("addWorklogAndAutoAdjustRemainingEstimateReturn")]
        public void addWorklogAndAutoAdjustRemainingEstimateFixed(string in0, string in1, RemoteWorklog in2)
        {
            object[] results = this.Invoke("addWorklogAndAutoAdjustRemainingEstimate", new object[] {
                        in0,
                        in1,
                        in2});
            //return ((RemoteWorklog)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace = "http://soap.rpc.jira.atlassian.com", ResponseNamespace = "http://localhost:8080/rpc/soap/jirasoapservice-v2")]
        [return: System.Xml.Serialization.SoapElementAttribute("addWorklogAndRetainRemainingEstimateReturn")]
        public void addWorklogAndRetainRemainingEstimateFixed(string in0, string in1, RemoteWorklog in2)
        {
            object[] results = this.Invoke("addWorklogAndRetainRemainingEstimate", new object[] {
                        in0,
                        in1,
                        in2});
            //return ((RemoteWorklog)(results[0]));
        }
    }
}
