/*
 * Copyright 2011 Joe Dluzen
 *
 * Author(s):
 *  Joe Dluzen (jdluzen@gmail.com)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Text;
using System.Net;

namespace Xamarin.Payments.Stripe {
    public class StripeInvoiceItemInfo : IUrlEncoderInfo {
        public string CustomerID { get; set; }
        
        public string InvoiceID { get; set; }

        public int Amount { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        #region IUrlEncoderInfo implementation
        public virtual void UrlEncode (StringBuilder sb)
        {
            sb.AppendFormat ("customer={0}&amount={1}&currency={2}&",
                System.Net.WebUtility.UrlEncode (CustomerID), Amount, System.Net.WebUtility.UrlEncode (Currency ?? "usd"));
            if (!string.IsNullOrEmpty (Description))
                sb.AppendFormat ("description={0}&", System.Net.WebUtility.UrlEncode (Description));
            if (!string.IsNullOrEmpty (InvoiceID))
                sb.AppendFormat ("invoice={0}&", System.Net.WebUtility.UrlEncode (InvoiceID));
        }
        #endregion
    }
}
